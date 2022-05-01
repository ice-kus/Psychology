using Microsoft.AspNetCore.Mvc;
using Psychology.Data.Interfaces;
using Psychology.Data.Models;
using Psychology.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Psychology.Controllers
{
    [Authorize]
    public class StudentTestController : Controller
    {
        private readonly ITestRepository _Test;
        private readonly ITestQuestionRepository _TestQuestion;
        private readonly IStatisticsRepository _Statistics;
        private readonly IStatisticsQuestionRepository _StatisticsQuestion;
        private readonly ICriteriaRepository _Criteria;
        private readonly IResultRepository _Result;

        public StudentTestController(ITestRepository _Test, ITestQuestionRepository _TestQuestion, IStatisticsRepository _Statistics, IStatisticsQuestionRepository _StatisticsQuestion, ICriteriaRepository _Criteria, IResultRepository _Result)
        {
            this._Test = _Test;
            this._TestQuestion = _TestQuestion;
            this._Statistics = _Statistics;
            this._StatisticsQuestion = _StatisticsQuestion;
            this._Criteria = _Criteria;
            this._Result = _Result;
        }
        // -- список тестов --
        public ViewResult Index()
        {
            var Model = new StudentTestViewModel
            {
                SortDesc = true,
                SortDate = true,
                ListTest = _Test.List.Where(i => i.Availability).OrderByDescending(i => i.Id)
            };
            return View(Model);
        }
        // -- сортировка списка тестов --
        [HttpPost]
        public IActionResult SortListTest(StudentTestViewModel Model)
        {
            if (Model.SortDate)
            {
                if (Model.SortDesc)
                    Model.ListTest = _Test.List.OrderByDescending(i => i.Id);
                else
                    Model.ListTest = _Test.List.OrderBy(i => i.Id);
            }
            else
            {
                if (Model.SortDesc)
                    Model.ListTest = _Test.List.OrderByDescending(i => i.Name);
                else
                    Model.ListTest = _Test.List.OrderBy(i => i.Name);
            }
            return View("Index", Model);
        }
        // -- информация о тесте --
        [HttpGet]
        public ViewResult InfoTest(long Id)
        {
            var Model = new StudentTestViewModel
            {
                Test = _Test.List.First(i => i.Id == Id)
            };
            return View(Model);
        }
        // -- подтверждение прохождения --
        [HttpPost]
        public ActionResult InfoTest(StudentTestViewModel TestModel)
        {
            Random RND = new Random();

            var Model = new StudentPassingTestViewModel
            {
                TestId = TestModel.Test.Id,
                NumQuestion = 0,
                TestSize = TestModel.Test.Size
            };

            Model.ListMix = new List<int>();
            for (int i = 1; i <= Model.TestSize; i++)
                Model.ListMix.Add(i);
            if (TestModel.Test.Mix)
                Model.ListMix = Model.ListMix.OrderBy(i => RND.Next()).ToList();

            Model.ListTestQuestion = _TestQuestion.List.Where(i => i.TestId == Model.TestId && i.NumQuestion == Model.ListMix[Model.NumQuestion]).OrderBy(i => i.NumAnswer);
            
            var Date = DateTime.Now;
            _Statistics.Create(long.Parse(User.Identity.Name), Model.TestId, Date);
            _Statistics.Save();

            Model.StatisticsId = _Statistics.List.FirstOrDefault(i => i.StudentId == long.Parse(User.Identity.Name) && i.TestId == Model.TestId && i.Date == Date).Id;
            
            return View("PassingTest", Model);
        }
        // -- прохождение теста --
        [HttpPost]
        public ActionResult PassingTest(StudentPassingTestViewModel Model, int NumAnswer)
        {
            _StatisticsQuestion.Create(Model.StatisticsId, Model.ListMix[Model.NumQuestion], NumAnswer);
            _StatisticsQuestion.Save();

            Model.NumQuestion++;
            Model.ListTestQuestion = _TestQuestion.List.Where(i => i.TestId == Model.TestId && i.NumQuestion == Model.ListMix[Model.NumQuestion]).OrderBy(i => i.NumAnswer);
            
            if (Model.NumQuestion < Model.TestSize)
                return View(Model);
            else
                return RedirectToAction("GetResult", new { StatisticsId = Model.StatisticsId, TestId = Model.TestId });
        }
        // -- получение и сохранение результата --
        public ActionResult GetResult (long StatisticsId, long TestId)
        {
            var Test = _Test.List.First(i => i.Id == TestId);
            var ListCriteria = _Criteria.List.Where(i => i.TestId == TestId);
            var ListStatisticsQuestion = _StatisticsQuestion.List.Where(i => i.StatisticsId == StatisticsId).ToList();
            if (Test.Type == 1)
            {
                foreach (var Criteria in ListCriteria)
                {
                    int Points = 0;
                    foreach (var NumQuestion in Criteria.ListNumQuestion)
                        Points += ListStatisticsQuestion.First(j => j.NumQuestion == NumQuestion).NumAnswer;
                    _Result.Create(StatisticsId, Criteria.Id, Points);
                }
            }
            else
            {
                foreach(var Criteria in ListCriteria)
                {
                    int Points = 0;
                    for (int i = 0; i < Criteria.ListNumQuestion.Count; i++)
                        if (ListStatisticsQuestion.Any(j => j.NumQuestion == Criteria.ListNumQuestion[i] && j.NumAnswer == Criteria.ListNumAnswer[i]))
                            Points++;
                    _Result.Create(StatisticsId, Criteria.Id, Points);
                }

            }
            _Result.Save();
            return RedirectToAction("ViewResult", "Result", new { StatisticsId = StatisticsId });
        }
    }
}
