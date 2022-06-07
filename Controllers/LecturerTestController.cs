using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Psychology.Data.Interfaces;
using Psychology.Data.Models;
using Psychology.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Psychology.Controllers
{
    [Authorize(Roles = "Lecturer")]
    public class LecturerTestController : Controller
    {
        private readonly ITestRepository _Test;
        private readonly IPassageDataRepository _PassageData;
        private readonly ITestQuestionRepository _TestQuestion;
        private readonly IQuestionRepository _Question;
        private readonly IAnswerRepository _Answer;
        private readonly ICriteriaRepository _Criteria;
        private string BlockTest;       // блок характеристик теста
        private string BlockQuestion;   // блок вопросов
        private string BlockCriteria;   // блок критериев
        private int Type;               // тип теста
        private int Size;               // размер теста
        private int Scale;              // количество ответов на вопрос

        public LecturerTestController(ITestRepository _Test, IPassageDataRepository _PassageData, ITestQuestionRepository _TestQuestion, IQuestionRepository _Question, IAnswerRepository _Answer, ICriteriaRepository _Criteria)
        {
            this._Test = _Test;
            this._TestQuestion = _TestQuestion;
            this._Question = _Question;
            this._Answer = _Answer;
            this._Criteria = _Criteria;
            this._PassageData = _PassageData;
        }
        // -- список тестов --
        public ViewResult Index()
        {
            var Model = new LecturerTestViewModel
            {
                SortDesc = true,
                SortDate = true,
                ListTest = _Test.List.OrderByDescending(i => i.Id),
                Message = ""
            };
            return View(Model);
        }
        // -- сортировка списка тестов --
        [HttpGet]
        public ViewResult ChangeListTest(string Find, bool SortDate, bool SortDesc)
        {
            var Model = new LecturerTestViewModel
            {
                SortDate = SortDate,
                SortDesc = SortDesc,
                Message = Find
            };
            if (String.IsNullOrEmpty(Find))
            {
                Model.ListTest = _Test.List;
                Model.Message = "";
            }
            else
                Model.ListTest = _Test.List.Where(i => i.Name.ToLower().Contains(Find.ToLower()));
            if (SortDate)
            {
                if (SortDesc)
                    Model.ListTest = Model.ListTest.OrderByDescending(i => i.Id);
                else
                    Model.ListTest = Model.ListTest.OrderBy(i => i.Id);
            }
            else
            {
                if (SortDesc)
                    Model.ListTest = Model.ListTest.OrderByDescending(i => i.Name);
                else
                    Model.ListTest = Model.ListTest.OrderBy(i => i.Name);
            }
            return View("Index", Model);
        }
        // -- редактирование теста --
        [HttpGet]
        public ViewResult UpdateTest(long Id) 
        {
            var Model = new LecturerTestViewModel
            {
                Test = _Test.List.First(i => i.Id == Id),
                Delete = !_PassageData.List.Any(i => i.TestId == Id)
            };
            return View(Model);
        }
        [HttpPost]
        public IActionResult UpdateTest(LecturerTestViewModel Model) 
        {
            Model.Test.Name = Model.Test.Name.Trim();
            Model.Test.Description = Model.Test.Description.Trim();
            Model.Test.Instruction = Model.Test.Instruction.Trim();
            Model.Test.Processing = Model.Test.Processing.Trim();
            try
            {
                _Test.Update(Model.Test);
                _Test.Save();
            }
            catch (Exception)
            {
                Model.Message = "Тест с таким наименованием уже есть в базе";
                return View(Model);
            }
            return RedirectToAction("Index");
        }
        // -- удаление теста --
        [HttpPost]
        public IActionResult DeleteTest(LecturerTestViewModel Model) 
        {
            var ListTestQuestion = _TestQuestion.List.Where(i => i.TestId == Model.Test.Id).ToList();

            var ListId = ListTestQuestion.Select(i => i.Id).ToList();
            foreach (var Id in ListId)
                _TestQuestion.Delete(Id);
            _TestQuestion.Save();
            
            ListId = ListTestQuestion.Select(i => i.QuestionId).Distinct().ToList();
            foreach (var Id in ListId)
            {
                _Question.Delete(Id);
                _Question.Save();
            }

            ListId = ListTestQuestion.Select(i => i.AnswerId).Distinct().ToList();
            foreach (var Id in ListId)
            {
                _Answer.Delete(Id);
                _Answer.Save();
            }

            var ListCriteria = _Criteria.List.Where(i => i.TestId == Model.Test.Id).ToList();
            foreach (var Criteria in ListCriteria)
                _Criteria.Delete(Criteria.Id);
            _Criteria.Save();

            _Test.Delete(Model.Test.Id);
            _Test.Save();

            return RedirectToAction("Index");
        }
        // -- список вопросов --
        [HttpGet]
        public ViewResult ListQuestion(long Id) 
        {
            var Model = new LecturerUpdateQuestionViewModel
            {
                TestId = Id,
                ListQuestion = _TestQuestion.List.Where(i => i.TestId == Id).OrderBy(i => i.NumQuestion).Select(i => i.Question).Distinct()
            };
            return View(Model); 
        }
        // -- редактирование вопроса --
        [HttpGet]
        public ViewResult UpdateQuestion(long TestId, long QuestionId) 
        {
            var Model = new LecturerUpdateQuestionViewModel
            {
                TestId = TestId,
                Type = _Test.List.First(i => i.Id == TestId).Type,
                Question = _Question.List.First(i => i.Id == QuestionId),
            };
            if (Model.Type == 3)
                Model.ListAnswer = _TestQuestion.List.Where(i => i.TestId == TestId && i.QuestionId == QuestionId).OrderBy(i => i.NumAnswer).Select(i => i.Answer).ToList();
            return View(Model);
        }
        [HttpPost]
        public IActionResult UpdateQuestion(LecturerUpdateQuestionViewModel Model) 
        {
            Model.Question.Text = Model.Question.Text.Trim();
            _Question.Update(Model.Question);
            _Question.Save();
            if (Model.Type == 3)
                foreach (var Answer in Model.ListAnswer)
                {
                    Answer.Text = Answer.Text.Trim();
                    _Answer.Update(Answer);
                    _Answer.Save();
                }
            return RedirectToAction("ListQuestion", new { Id = Model.TestId}); 
        }
        // -- список критериев --
        [HttpGet]
        public ViewResult ListCriteria(long Id) 
        {
            var Model = new LecturerUpdateCriteriaViewModel
            {
                ListCriteria = _Criteria.List.Where(i => i.TestId == Id).OrderBy(i => i.Id)
            };
            return View(Model); 
        }
        // -- редактирование критерия --
        [HttpGet]
        public ViewResult UpdateCriteria(long Id) 
        {
            Criteria Criteria = _Criteria.List.First(i => i.Id == Id);
            Test Test = _Test.List.First(i => i.Id == Criteria.TestId);
            var Model = new LecturerUpdateCriteriaViewModel
            {
                Criteria = Criteria,
                Scale = Test.Scale,
                Size = Test.Size
            };
            return View(Model);
        }
        [HttpPost]
        public IActionResult UpdateCriteria(LecturerUpdateCriteriaViewModel Model) 
        {
            Model.Criteria.Name = Model.Criteria.Name.Trim();
            _Criteria.Update(Model.Criteria);
            _Criteria.Save();
            return RedirectToAction("ListCriteria", new { Id = Model.Criteria.TestId });
        }
        [HttpPost]
        public IActionResult DeleteParameter(LecturerUpdateCriteriaViewModel Model)
        {
            Model.Criteria.ListNumQuestion.RemoveAt(Model.Index);
            Model.Criteria.ListNumAnswer.RemoveAt(Model.Index);
            return View("UpdateCriteria", Model);
        }
        [HttpPost]
        public IActionResult AddParameter(LecturerUpdateCriteriaViewModel Model)
        {
            for (int i = 0; i < Model.Criteria.ListNumQuestion.Count; i++)
                if (Model.Criteria.ListNumQuestion[i] == Model.NumQuestion && Model.Criteria.ListNumAnswer[i] == Model.NumAnswer)
                    return View("UpdateCriteria", Model);
            Model.Criteria.ListNumQuestion.Add(Model.NumQuestion);
            Model.Criteria.ListNumAnswer.Add(Model.NumAnswer);
            return View("UpdateCriteria", Model);
        }
        // -- добавление теста --
        [HttpGet]
        public ViewResult AddTest() 
        {
            var Model = new LecturerAddTestViewModel();
            return View(Model); 
        }
        [HttpPost]
        public IActionResult AddTest(LecturerAddTestViewModel Model) 
        {
            try
            {
                ReadFile(Model.Path);
                CheckBlockTest();
                CheckBlockQuestion();
                CheckBlockCriteria();
                UploadingTest();
                UploadingTestQuestion();
                UploadingBlockCriteria();
                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                Model.Message = Ex.Message;
            }
            return View(Model);
        }
        // -- проверка файла на наличие разделов (блок характеристик теста, блок вопросов, блок критериев) --
        public void ReadFile(string File)
        {
            StreamReader SR = new StreamReader(File);
            string Line = "";
            // заполнение блока теста
            while (Line.Trim() != "#тест_начало" && !SR.EndOfStream)
            {
                BlockTest += Line + '\n';
                Line = SR.ReadLine();
            }
            if (SR.EndOfStream)
                throw new Exception("Нет тега \"#тест_начало\" или нарушена структура шаблона!");
            // заполнение блока вопросов
            Line = "";
            while (Line.Trim() != "#тест_конец" && !SR.EndOfStream)
            {
                BlockQuestion += Line + '\n';
                Line = SR.ReadLine();
            }
            if (SR.EndOfStream)
                throw new Exception("Нет тега \"#тест_конец\" или нарушена структура шаблона!");
            // заполнение блока критериев
            while (Line.Trim() != "#критерии_начало" && !SR.EndOfStream)
            {
                Line = SR.ReadLine();
            }
            if (SR.EndOfStream)
                throw new Exception("Нет тега \"#критерии_начало\" или нарушена структура шаблона!");
            Line = "";
            while (Line.Trim() != "#критерии_конец" && !SR.EndOfStream)
            {
                BlockCriteria += Line + '\n';
                Line = SR.ReadLine();
            }
            if (Line.Trim() != "#критерии_конец")
                throw new Exception("Нет тега \"#критерии_конец\" или нарушена структура шаблона!");
            SR.Close();
        }
        // -- проверка блока характеристик теста --
        public void CheckBlockTest()
        {
            string[] Line = BlockTest.Split('\n');
            string Temp;
            int i = 0;
            // проверка тега "#название:"
            while (i < Line.Length && !Line[i].Contains("#название:"))
                i++;
            if (i == Line.Length)
                throw new Exception("Нет тега \"#название:\" или нарушена структура шаблона!");
            else if (Line[i].Trim().Length < 12)
                throw new Exception("Тег \"#название:\" не заполнен!");
            // проверка тега "#описание:"
            while (i < Line.Length && !Line[i].Contains("#описание:"))
                i++;
            if (i == Line.Length)
                throw new Exception("Нет тега \"#описание:\" или нарушена структура шаблона!");
            // проверка тега "#тип:"
            while (i < Line.Length && !Line[i].Contains("#тип:"))
                i++;
            if (i == Line.Length)
                throw new Exception("Нет тега \"#тип:\" или нарушена структура шаблона!");
            Temp = Line[i].Remove(0, 5).Trim();
            if (!Temp.All(char.IsDigit))
                throw new Exception("Неккоректный тип теста!");
            Type = Int32.Parse(Temp);
            if (Type < 1 || Type > 3)
                throw new Exception("Неккоректный тип теста!");
            // проверка тега "#размер:"
            while (i < Line.Length && !Line[i].Contains("#размер:"))
                i++;
            if (i == Line.Length)
                throw new Exception("Нет тега \"#размер:\" или нарушена структура шаблона!");
            Temp = Line[i].Remove(0, 8).Trim();
            if (!Temp.All(char.IsDigit))
                throw new Exception("Неккоректный размер теста!");
            Size = Int32.Parse(Temp);
            // проверка тега "#шкала:"
            while (i < Line.Length && !Line[i].Contains("#шкала:"))
                i++;
            if (i == Line.Length)
                throw new Exception("Нет тега \"#шкала:\" или нарушена структура шаблона!");
            Temp = Line[i].Remove(0, 7).Trim();
            if (!Temp.All(char.IsDigit))
                throw new Exception("Неккоректная шкала теста!");
            Scale = Int32.Parse(Temp);
            // проверка тега "#перемешивание:"
            while (i < Line.Length && !Line[i].Contains("#перемешивание:"))
                i++;
            if (i == Line.Length)
                throw new Exception("Нет тега \"#перемешивание:\" или нарушена структура шаблона!");
            if (Line[i].Remove(0, 15).Trim() != "+" && Line[i].Remove(0, 15).Trim() != "-")
                throw new Exception("Неккоректное значение перемешивания теста!");
            // проверка тега "#инструкция:"
            while (i < Line.Length && !Line[i].Contains("#инструкция:"))
                i++;
            if (i == Line.Length)
                throw new Exception("Нет тега \"#инструкция:\" или нарушена структура шаблона!");
            // проверка тега "#обработка:"
            while (i < Line.Length && !Line[i].Contains("#обработка:"))
                i++;
            if (i == Line.Length)
                throw new Exception("Нет тега \"#обработка:\" или нарушена структура шаблона!");
        }
        // -- подсчёт количества вопросов --
        public int TestSize()
        {
            string[] Line = BlockQuestion.Split('\n');
            int Size = 0;
            foreach (string i in Line)
                if (i.Contains("+в:") && i.Trim().Length > 3)
                    Size++;
            return Size;
        }
        // -- проверка блока вопросов --
        public void CheckBlockQuestion()
        {
            string[] Line = BlockQuestion.Split('\n');
            int Size = TestSize();
            if (this.Size != Size)
                throw new Exception("Неверно указан размер теста или не все вопросы были добавлены!");
            Size = 0;
            if (Type != 1)
                for (int i = 0; i < Line.Length; i++)
                    if (Line[i].Contains("+в:"))
                    {
                        Size++;
                        int Scale = 0;
                        do
                        {
                            if (Line[i].Contains("-о:"))
                                Scale++;
                            i++;
                        }
                        while (i < Line.Length && !Line[i].Contains("+в:"));
                        if (Scale != this.Scale)
                            throw new Exception("В вопросе №" + Size + " количество вариантов ответа не равно " + this.Scale + "!");
                        i--;
                    }
        }
        // -- проверка критериев на наличие списка номеров вопросов --
        public bool CheckCriteriaQuestion()
        {
            string[] Line = BlockCriteria.Split('\n');
            for (int i = 0; i < Line.Length; i++)
                if (Line[i].Contains("+к:"))
                {
                    if (Line[i + 1].Contains("-в:"))
                    {
                        if (Line[i].Trim().Length < 4 || Line[i + 1].Trim().Length < 4)
                            return false;
                    }
                    else
                        return false;
                }
            return true;

        }
        // -- проверка блока критериев --
        public void CheckBlockCriteria()
        {
            if (!CheckCriteriaQuestion())
                throw new Exception("Какой-то критерий или список пуст/отстутствует!");
            string[] Line = BlockCriteria.Split('\n');

            if (Type == 1)
            {
                for (int i = 0; i < Line.Length; i++)
                {
                    if (Line[i].Contains("-в:"))
                    {
                        string[] NumberQuestion = Line[i].Remove(0, 3).Trim().Split(' ');
                        for (int j = 0; j < NumberQuestion.Length; j++)
                            if (!NumberQuestion[j].All(char.IsDigit) || Int32.Parse(NumberQuestion[j]) > this.Size || Int32.Parse(NumberQuestion[j]) < 1)
                                throw new Exception("Неккоректный номер вопроса в одном из критериев! Строка: \"" + Line[i] + "\"");
                    }
                }
            }
            else
            {
                for (int i = 0; i < Line.Length; i++)
                {
                    if (Line[i].Contains("-в:"))
                    {
                        string[] NumberQuestion = Line[i].Remove(0, 3).Trim().Split(' ');
                        for (int j = 0; j < NumberQuestion.Length; j++)
                            if (!NumberQuestion[j].Contains('(') || !NumberQuestion[j].Contains(')'))
                                throw new Exception("Неккоректный номер вопроса(ответа) в одном из критериев! Строка: \"" + Line[i] + "\" ");
                            else
                            {
                                int OpenPar = NumberQuestion[j].IndexOf('('),
                                    ClosePar = NumberQuestion[j].IndexOf(')');
                                if (!NumberQuestion[j].Substring(0, OpenPar).All(char.IsDigit) || !NumberQuestion[j].Substring(OpenPar + 1, ClosePar - 1 - OpenPar).All(char.IsDigit))
                                    throw new Exception("Неккоректный номер вопроса(ответа) в одном из критериев! Строка: \"" + Line[i] + "\" ");
                                else
                                {
                                    int Question = Int32.Parse(NumberQuestion[j].Substring(0, OpenPar)),
                                        Answer = Int32.Parse(NumberQuestion[j].Substring(OpenPar + 1, ClosePar - 1 - OpenPar));
                                    if (Question > this.Size || Question < 1 || Answer > this.Scale || Answer < 1)
                                        throw new Exception("Неккоректный номер вопроса(ответа) в одном из критериев! Строка: \"" + Line[i] + "\"");
                                }
                            }
                    }

                }
            }


        }
        // -- загрузка блока характеристик теста --
        public void UploadingTest()
        {
            string[] Line = BlockTest.Split('\n');
            string Name, Description, Instruction, Processing;
            bool Mix;
            int i = 0;
            // получение названия
            while (!Line[i].Contains("#название:"))
                i++;
            Name = Line[i].Remove(0, 10).Trim();
            // получение описания
            while (!Line[i].Contains("#описание:"))
                i++;
            Description = Line[i].Remove(0, 10).Trim();
            i++;
            while (!Line[i].Contains("#тип:"))
            {
                Description += Line[i] + '\n';
                i++;
            }
            // получение перемешивание
            while (!Line[i].Contains("#перемешивание:"))
                i++;
            if (Line[i].Remove(0, 15).Trim() == "+")
                Mix = true;
            else
                Mix = false;
            // получение инструкции
            while (!Line[i].Contains("#инструкция:"))
                i++;
            Instruction = Line[i].Remove(0, 12).Trim();
            i++;
            while (!Line[i].Contains("#обработка:"))
            {
                Instruction += Line[i] + '\n';
                i++;
            }
            // получение обработки
            Processing = Line[i].Remove(0, 11).Trim();
            i++;
            while (i < Line.Length)
            {
                Processing += Line[i] + '\n';
                i++;
            }
            // сохраняем данные
            if (!_Test.List.Any(i => i.Name == Name))
            {
                _Test.Create(Name, Description, this.Type, this.Size, this.Scale, Instruction, Processing, true, Mix, long.Parse(User.Identity.Name));
                _Test.Save();
            }
            else
                throw new Exception("Тест с таким наименованием был добавлен ранее!");

        }
        // -- загрузка вопросов --
        public void UploadingQuestion()
        {
            string[] Line = BlockQuestion.Split('\n');
            foreach (string i in Line)
                if (i.Contains("+в:"))
                {
                    _Question.Create(i.Remove(0, 3).Trim());
                    _Question.Save();
                }
        }
        // -- загрузка ответов --
        public void UploadingAnswer()
        {
            switch(Type)
            {
                case 1:
                    for (int i = 1; i <= Scale; i++)
                    {
                        _Answer.Create(i.ToString());
                        _Answer.Save();
                    }
                    break;
                case 2:
                        _Answer.Create("Да");
                        _Answer.Save();
                        _Answer.Create("Нет");
                        _Answer.Save();
                    break;
                default:
                    string[] Line = BlockQuestion.Split('\n');
                    foreach (string i in Line)
                        if (i.Contains("-о:"))
                        {
                            _Answer.Create(i.Remove(0, 3).Trim());
                            _Answer.Save();
                        }
                    break;
            }
        }
        // -- загрузка блока вопросов --
        public void UploadingTestQuestion()
        {
            UploadingQuestion();
            UploadingAnswer();
            string[] Line = BlockQuestion.Split('\n');
            long TestId = _Test.List.OrderBy(i => i.Id).Last().Id;
            switch(Type)
            {
                case 1:
                    int NumQuestion = 1;
                    var ListAnswer = new List<long>();
                    for (int i = 1; i <= Scale; i++)
                        ListAnswer.Add(_Answer.List.FirstOrDefault(q => q.Text == i.ToString()).Id);
                    foreach (string i in Line)
                    {
                        if (i.Contains("+в:"))
                        {
                            for (int j = 1; j <= Scale; j++)
                            {
                                _TestQuestion.Create(TestId, _Question.List.FirstOrDefault(q => q.Text == i.Remove(0, 3).Trim()).Id, ListAnswer[j - 1], NumQuestion, j);
                            }
                            NumQuestion++;
                        }
                    }
                    break;
                case 2:
                    NumQuestion = 1;
                    ListAnswer = new List<long>();
                    ListAnswer.Add(_Answer.List.FirstOrDefault(q => q.Text == "Да").Id);
                    ListAnswer.Add(_Answer.List.FirstOrDefault(q => q.Text == "Нет").Id);
                    foreach (string i in Line)
                    {
                        if (i.Contains("+в:"))
                        {
                            for (int j = 1; j <= 2; j++)
                            {
                                _TestQuestion.Create(TestId, _Question.List.FirstOrDefault(q => q.Text == i.Remove(0, 3).Trim()).Id, ListAnswer[j - 1], NumQuestion, j);
                            }
                            NumQuestion++;
                        }
                    }
                    break;
                default:
                    NumQuestion = 1;
                    for (int i = 0; i < Line.Length; i++)
                    {
                        if (Line[i].Contains("+в:"))
                        {
                            int NumAnswer = 1;
                            long QuestionId = _Question.List.FirstOrDefault(q => q.Text == Line[i].Remove(0, 3).Trim()).Id;
                            do
                            {
                                if (Line[i].Contains("-о:"))
                                {
                                    _TestQuestion.Create(TestId, QuestionId, _Answer.List.FirstOrDefault(q => q.Text == Line[i].Remove(0, 3).Trim()).Id, NumQuestion, NumAnswer);
                                    NumAnswer++;
                                }
                                i++;
                            }
                            while (i < Line.Length && !Line[i].Contains("+в:"));
                            i--;
                            NumQuestion++;
                        }
                    }
                    break;
            }
            _TestQuestion.Save();
        }
        // -- загрузка блока критериев --
        public void UploadingBlockCriteria()
        {
            string[] Line = BlockCriteria.Split('\n');
            long TestId = _Test.List.OrderBy(i => i.Id).Last().Id;
            List<int> ListNumQuestion = new List<int>(), ListNumAnswer = new List<int>();
            if (Type == 1)
            {
                for (int i = 0; i < Line.Length; i++)
                {
                    if (Line[i].Contains("+к:"))
                    {
                        string Name = Line[i].Remove(0, 3).Trim();
                        i++;
                        // разбитие строки на массивы номеров вопросов и ответов
                        string[] Question = Line[i].Remove(0, 3).Trim().Split(' ');
                        for (int j = 0; j < Question.Length; j++)
                            ListNumQuestion.Add(Int32.Parse(Question[j]));
                        // сохраняем данные
                        _Criteria.Create(Name, TestId, ListNumQuestion, ListNumAnswer);
                        _Criteria.Save();
                        ListNumQuestion = new List<int>();
                    }
                }
            }
            else
            {
                for (int i = 0; i < Line.Length; i++)
                {
                    if (Line[i].Contains("+к:"))
                    {
                        string Name = Line[i].Remove(0, 3).Trim();
                        i++;
                        // разбитие строки на массивы номеров вопросов и ответов
                        string[] Question = Line[i].Remove(0, 3).Trim().Split(' ');
                        for (int j = 0; j < Question.Length; j++)
                        {
                            int OpenPar = Question[j].IndexOf('('), ClosePar = Question[j].IndexOf(')');
                            ListNumQuestion.Add(Int32.Parse(Question[j].Substring(0, OpenPar)));
                            ListNumAnswer.Add(Int32.Parse(Question[j].Substring(OpenPar + 1, ClosePar - 1 - OpenPar)));
                        }
                        // сохраняем данные
                        _Criteria.Create(Name, TestId, ListNumQuestion, ListNumAnswer);
                        _Criteria.Save();
                        ListNumQuestion = new List<int>();
                        ListNumAnswer = new List<int>();
                    }
                }
            }
        }
    }
}
