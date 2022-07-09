using Microsoft.AspNetCore.Mvc;
using Psychology.Data.Interfaces;
using Psychology.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Psychology.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentResultController : Controller
    {
        private readonly IPassageDataRepository _PassageData;
        private readonly IResultRepository _Result;

        public StudentResultController(IPassageDataRepository _PassageData, IResultRepository _Result)
        {
            this._PassageData = _PassageData;
            this._Result = _Result;
        }

        public ViewResult Index()
        {
            var Model = new StudentResultViewModel()
            {
                SortDesc = true,
                SortDate = true,
                ListPassageData = _PassageData.List.Where(i => i.Full== true && i.StudentId == long.Parse(User.Identity.Name)).OrderByDescending(i => i.Date)
            };
            return View(Model);
        }
        // -- сортировка списка по тесту --
        [HttpPost]
        public IActionResult SortListPassageData(StudentResultViewModel Model)
        {
            if (Model.SortDate)
            {
                if (Model.SortDesc)
                    Model.ListPassageData = _PassageData.List.Where(i => i.Full == true && i.StudentId == long.Parse(User.Identity.Name)).OrderByDescending(i => i.Date);
                else
                    Model.ListPassageData = _PassageData.List.Where(i => i.Full == true && i.StudentId == long.Parse(User.Identity.Name)).OrderBy(i => i.Date);
            }
            else
            {
                if (Model.SortDesc)
                    Model.ListPassageData = _PassageData.List.Where(i => i.Full == true && i.StudentId == long.Parse(User.Identity.Name)).OrderByDescending(i => i.Test.Name);
                else
                    Model.ListPassageData = _PassageData.List.Where(i => i.Full == true && i.StudentId == long.Parse(User.Identity.Name)).OrderBy(i => i.Test.Name);
            }
            return View("Index", Model);
        }
        public IActionResult ViewResult(long PassageDataId)
        {
            var Model = new StudentResultViewModel
            {
                PassageData = _PassageData.List.FirstOrDefault(i => i.Id == PassageDataId)
            };
            if (Model.PassageData == null || Model.PassageData.StudentId != long.Parse(User.Identity.Name))
                return RedirectToAction("Index", "StudentResult");

            Model.PassageData.ListResult = _Result.List.Where(i => i.PassageDataId == PassageDataId).OrderBy(i => i.CriteriaId);

            return View(Model);
        }
    }
}
