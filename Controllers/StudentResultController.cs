using Microsoft.AspNetCore.Mvc;
using Psychology.Data.Interfaces;
using Psychology.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Psychology.Controllers
{
    [Authorize]
    public class StudentResultController : Controller
    {
        private readonly IStatisticsRepository _Statistics;
        private readonly IResultRepository _Result;

        public StudentResultController(IStatisticsRepository _Statistics, IResultRepository _Result)
        {
            this._Statistics = _Statistics;
            this._Result = _Result;
        }

        public ViewResult Index()
        {
            var Model = new StudentResultViewModel()
            {
                SortDesc = true,
                SortDate = true,
                ListStatistics = _Statistics.List.Where(i => i.StudentId == long.Parse(User.Identity.Name)).OrderByDescending(i => i.Date)
            };
            return View(Model);
        }
        // -- сортировка списка тестов --
        [HttpPost]
        public IActionResult SortListStatistics(StudentResultViewModel Model)
        {
            if (Model.SortDate)
            {
                if (Model.SortDesc)
                    Model.ListStatistics = _Statistics.List.Where(i => i.StudentId == long.Parse(User.Identity.Name)).OrderByDescending(i => i.Date);
                else
                    Model.ListStatistics = _Statistics.List.Where(i => i.StudentId == long.Parse(User.Identity.Name)).OrderBy(i => i.Date);
            }
            else
            {
                if (Model.SortDesc)
                    Model.ListStatistics = _Statistics.List.Where(i => i.StudentId == long.Parse(User.Identity.Name)).OrderByDescending(i => i.Test.Name);
                else
                    Model.ListStatistics = _Statistics.List.Where(i => i.StudentId == long.Parse(User.Identity.Name)).OrderBy(i => i.Test.Name);
            }
            return View("Index", Model);
        }
        public IActionResult ViewResult(long StatisticsId)
        {
            var Model = new StudentResultViewModel
            {
                Statistics = _Statistics.List.FirstOrDefault(i => i.Id == StatisticsId)
            };
            if (Model.Statistics == null || Model.Statistics.StudentId != long.Parse(User.Identity.Name))
                return RedirectToAction("Index", "Result");
            Model.Statistics.ListResult = _Result.List.Where(i => i.StatisticsId == StatisticsId);
            return View(Model);
        }
    }
}
