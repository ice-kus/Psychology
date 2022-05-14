using Microsoft.AspNetCore.Mvc;
using Psychology.Data.Interfaces;
using Psychology.Data.Models;
using Psychology.ViewModels;
using System.Linq;

namespace Psychology.Controllers
{
    public class LecturerResultController : Controller
    {
        private readonly IPassageDataRepository _PassageData;
        private readonly IPassageDataQuestionRepository _PassageDataQuestion;
        private readonly IGroupRepository _Group;
        private readonly IStudentRepository _Student;
        private readonly ITestRepository _Test;
        private readonly ICriteriaRepository _Criteria;
        private readonly IResultRepository _Result;
        private readonly ITestQuestionRepository _TestQuestion;
        public LecturerResultController(ICriteriaRepository _Criteria, ITestQuestionRepository _TestQuestion, IResultRepository _Result, ITestRepository _Test, IStudentRepository _Student, IPassageDataRepository _PassageData, IPassageDataQuestionRepository _StatisticsQuestion, IGroupRepository _Group)
        {
            this._PassageData = _PassageData;
            this._PassageDataQuestion = _StatisticsQuestion;
            this._Group = _Group;
            this._Student = _Student;
            this._Test = _Test;
            this._Result = _Result;
            this._TestQuestion = _TestQuestion;
            this._Criteria = _Criteria;
        }
        public ViewResult Index()
        {
            var Model = new LecturerListResultViewModel
            {
                ListGroup = _Group.List.OrderBy(i => i.Name),
                SortDesc = true,
                SortDate = true
            };
            Model.GroupId = Model.ListGroup.First().Id;
            Model.ListStudent = _Student.List.Where(i => i.GroupId == Model.GroupId);
            Model.StudentId = Model.ListStudent.First().Id;
            Model.ListPassageData = _PassageData.List.Where(i => i.Full == true && i.StudentId == Model.StudentId).OrderByDescending(i => i.Date);
            return View(Model);
        }

        public ViewResult Recalculation()
        {
            var Model = new LecturerRecalculationViewModel
            {
                ListGroup = _Group.List.OrderBy(i => i.Name),
                ListTest = _Test.List.OrderBy(i => i.Name)
            };
            return View(Model);
        }
        [HttpPost]
        public IActionResult Recalculation(LecturerRecalculationViewModel Model)
        {

            var ListStudent = _Student.List.Where(i => i.GroupId == Model.GroupId).ToList();
            var Test = _Test.List.First(i => i.Id == Model.TestId);
            var ListCriteria = _Criteria.List.Where(i => i.TestId == Model.TestId).OrderBy(i => i.Id);

            var ListPassageData = _PassageData.List.Where(i => ListStudent.Any(j => j.Id == i.StudentId) && i.Full == true && i.TestId == Model.TestId).Select(i => i.Id).ToList();

            foreach(var PassageData in ListPassageData)
            {
                var ListPassageDataQuestion = _PassageDataQuestion.List.Where(i => i.PassageDataId == PassageData).ToList();
                var ListResult = _Result.List.Where(i => i.PassageDataId == PassageData).ToList();
                if (Test.Type == 1)
                {
                    foreach (var Criteria in ListCriteria)
                    {
                        int Points = 0;
                        foreach (var NumQuestion in Criteria.ListNumQuestion)
                            Points += ListPassageDataQuestion.First(j => j.NumQuestion == NumQuestion).NumAnswer;
                        Result Result = ListResult.FirstOrDefault(j => j.CriteriaId == Criteria.Id);
                        Result.Points = Points;
                        _Result.Update(Result);
                    }
                }
                else
                {
                    foreach (var Criteria in ListCriteria)
                    {
                        int Points = 0;
                        for (int i = 0; i < Criteria.ListNumQuestion.Count; i++)
                            if (ListPassageDataQuestion.Any(j => j.NumQuestion == Criteria.ListNumQuestion[i] && j.NumAnswer == Criteria.ListNumAnswer[i]))
                                Points++;
                        Result Result = ListResult.FirstOrDefault(j => j.CriteriaId == Criteria.Id);
                        Result.Points = Points;
                        _Result.Update(Result);
                    }
                }
                _Result.Save();
            }

            return RedirectToAction("ChangeListInSearchByTest", new { GroupId = Model.GroupId, TestId = Model.TestId, SortDesc = true, SortDate = true }) ;
        }

        [HttpGet]
        public ViewResult SearchByTest()
        {
            var Model = new LecturerListResultViewModel
            {
                ListGroup = _Group.List.OrderBy(i => i.Name),
                ListTest = _Test.List.OrderBy(i => i.Name),
                SortDesc = true,
                SortDate = true
            };
            Model.GroupId = Model.ListGroup.First().Id;
            Model.TestId = Model.ListTest.First().Id;
            var ListStudent  = _Student.List.Where(i => i.GroupId == Model.GroupId).ToList();
            Model.ListPassageData = _PassageData.List.Where(i => i.TestId == Model.TestId && i.Full == true && ListStudent.Any(j => j.Id == i.StudentId)).OrderByDescending(i => i.Date);
            return View(Model);
        }
        [HttpGet]
        public ViewResult ChangeListInSearchByStudent(long GroupId, long StudentId, bool SortDesc, bool SortDate, bool ChangeGroup)
        {
            var Model = new LecturerListResultViewModel
            {
                SortDesc = SortDesc,
                SortDate = SortDate,
                ListGroup = _Group.List.OrderBy(i => i.Name),
                GroupId = GroupId,
                ListStudent = _Student.List.Where(i => i.GroupId == GroupId)
            };
            if (ChangeGroup)
                Model.StudentId = Model.ListStudent.First().Id;
            else
                Model.StudentId = StudentId;

            if (SortDate)
            {
                if (SortDesc)
                    Model.ListPassageData = _PassageData.List.Where(i => i.Full == true && i.StudentId == Model.StudentId).OrderByDescending(i => i.Date);
                else
                    Model.ListPassageData = _PassageData.List.Where(i => i.Full == true && i.StudentId == Model.StudentId).OrderBy(i => i.Date);
            }
            else
            {
                if (SortDesc)
                    Model.ListPassageData = _PassageData.List.Where(i => i.Full == true && i.StudentId == Model.StudentId).OrderByDescending(i => i.Test.Name);
                else
                    Model.ListPassageData = _PassageData.List.Where(i => i.Full == true && i.StudentId == Model.StudentId).OrderBy(i => i.Test.Name);
            }

            return View("Index", Model);
        }

        [HttpGet]
        public ViewResult ChangeListInSearchByTest(long GroupId, long TestId, bool SortDesc, bool SortDate)
        {
            var Model = new LecturerListResultViewModel
            {
                SortDesc = SortDesc,
                SortDate = SortDate,
                ListGroup = _Group.List.OrderBy(i => i.Name),
                ListTest = _Test.List.OrderBy(i => i.Name),
                GroupId = GroupId,
                TestId = TestId
            };
            var ListStudent = _Student.List.Where(i => i.GroupId == Model.GroupId).ToList();

            if (SortDate)
            {
                if (SortDesc)
                    Model.ListPassageData = _PassageData.List.Where(i => i.Full == true && i.TestId == Model.TestId && ListStudent.Any(j => j.Id == i.StudentId)).OrderByDescending(i => i.Date);
                else
                    Model.ListPassageData = _PassageData.List.Where(i => i.Full == true && i.TestId == Model.TestId && ListStudent.Any(j => j.Id == i.StudentId)).OrderBy(i => i.Date);
            }
            else
            {
                if (SortDesc)
                    Model.ListPassageData = _PassageData.List.Where(i => i.Full == true && i.TestId == Model.TestId && ListStudent.Any(j => j.Id == i.StudentId)).OrderByDescending(i => i.Student.Name);
                else
                    Model.ListPassageData = _PassageData.List.Where(i => i.Full == true && i.TestId == Model.TestId && ListStudent.Any(j => j.Id == i.StudentId)).OrderBy(i => i.Student.Name);
            }

            return View("SearchByTest", Model);
        }

        [HttpGet]
        public ViewResult ViewResult(long PassageDataId) 
        {
            var Model = new LecturerResultViewModel
            {
                PassageData = _PassageData.List.First(i => i.Id == PassageDataId)
            };
            Model.PassageData.ListResult = _Result.List.Where(i => i.PassageDataId == PassageDataId).OrderBy(i => i.CriteriaId);
            return View(Model);
        }
        public ViewResult ViewDetailedResult(long PassageDataId) 
        {
            var Model = new LecturerResultViewModel
            {
                PassageData = _PassageData.List.First(i => i.Id == PassageDataId)
            };
            Model.PassageData.ListResult = _Result.List.Where(i => i.PassageDataId == PassageDataId);
            Model.PassageData.ListPassageDataQuestion = _PassageDataQuestion.List.Where(i => i.PassageDataId == PassageDataId).OrderBy(i => i.NumQuestion);
            Model.ListTestQuestion = _TestQuestion.List.Where(i => i.TestId == Model.PassageData.TestId).OrderBy(i => i.NumQuestion);
            return View(Model); 
        }
    }
}
