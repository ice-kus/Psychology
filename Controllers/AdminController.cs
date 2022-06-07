using Microsoft.AspNetCore.Mvc;
using Psychology.ViewModels;
using Psychology.Data.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Psychology.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IStudentRepository _Student;
        private readonly ILecturerRepository _Lecturer;
        private readonly IPassageDataRepository _PassageData;
        private readonly ITestRepository _Test;
        private readonly IGroupRepository _Group;
        public AdminController(ITestRepository _Test, IStudentRepository _Student, ILecturerRepository _Lecturer, IGroupRepository _Group, IPassageDataRepository _PassageData)
        {
            this._Student = _Student;
            this._Lecturer = _Lecturer;
            this._Group = _Group;
            this._PassageData = _PassageData;
            this._Test = _Test;
        }
        public ViewResult Index()
        {
            var Model = new AdminViewModel
            {
                ListGroup = _Group.List.OrderBy(i => i.Name)
            };
            return View(Model);
        }
        [HttpGet]
        public ViewResult Group(long Id)
        {
            var Model = new AdminViewModel
            {
                ListStudent = _Student.List.Where(i => i.GroupId == Id).OrderBy(i => i.Name),
                Group = _Group.List.FirstOrDefault(i => i.Id == Id)
            };
            if (Model.ListStudent.Count() == 0)
                Model.Delete = true;
            return View(Model);
        }
        [HttpPost]
        public ActionResult Group(AdminViewModel Model)
        {
            _Group.Update(Model.Group);
            _Group.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteGroup(AdminViewModel Model)
        {
            _Group.Delete(Model.Group.Id);
            _Group.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult AddGroup()
        {
            var Model = new AdminViewModel();
            Model.Group = new Data.Models.Group();
            return View(Model);
        }
        [HttpPost]
        public ActionResult AddGroup(AdminViewModel Model)
        {
            _Group.Create(Model.Group.Name);
            _Group.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult Student(long Id)
        {
            var Model = new AdminViewModel
            {
                Student = _Student.List.First(i => i.Id == Id),
                ListGroup = _Group.List.OrderBy(i => i.Name)
            };
            Model.Group = Model.ListGroup.First(i => i.Id == Model.Student.GroupId);
            if (!_PassageData.List.Any(i => i.StudentId == Id))
                Model.Delete = true;
            return View(Model);
        }
        [HttpPost]
        public ActionResult Student(AdminViewModel Model)
        {
            _Student.Update(Model.Student);
            _Student.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteStudent(AdminViewModel Model)
        {
            _Student.Delete(Model.Student.Id);
            _Student.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult AddStudent(long Id)
        {
            var Model = new AdminViewModel
            {
                Student = new Data.Models.Student(),
                Group = _Group.List.First(i => i.Id == Id)
            };
            return View(Model);
        }
        [HttpPost]
        public ActionResult AddStudent(AdminViewModel Model)
        {
            _Student.Create(Model.Student.Name, Model.Student.Password, Model.Group.Id);
            _Student.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult ListLecturer()
        {
            var Model = new AdminViewModel
            {
                ListLecturer = _Lecturer.List.Where(i => i.Id != 1).OrderBy(i => i.Id)
            };
            return View(Model);
        }
        [HttpGet]
        public ViewResult Lecturer(long Id)
        {
            var Model = new AdminViewModel
            {
                Lecturer = _Lecturer.List.First(i => i.Id == Id)
            };
            if (!_Test.List.Any(i => i.LecturerId == Id))
                Model.Delete = true;
            return View(Model);
        }
        [HttpPost]
        public ActionResult Lecturer(AdminViewModel Model)
        {
            _Lecturer.Update(Model.Lecturer);
            _Lecturer.Save();
            return RedirectToAction("ListLecturer");
        }
        [HttpPost]
        public ActionResult DeleteLecturer(AdminViewModel Model)
        {
            _Lecturer.Delete(Model.Lecturer.Id);
            _Lecturer.Save();
            return RedirectToAction("ListLecturer");
        }
        [HttpGet]
        public ViewResult AddLecturer()
        {
            var Model = new AdminViewModel
            {
                Lecturer = new Data.Models.Lecturer()
            };
            return View(Model);
        }
        [HttpPost]
        public ActionResult AddLecturer(AdminViewModel Model)
        {
            _Lecturer.Create(Model.Lecturer.Name, Model.Lecturer.Login, Model.Lecturer.Password);
            _Lecturer.Save();
            return RedirectToAction("ListLecturer");
        }
        [HttpGet]
        public ViewResult Admin()
        {
            var Model = new AdminViewModel
            {
                Lecturer = _Lecturer.List.First(i => i.Id == 1)
            };
            return View(Model);
        }
        [HttpPost]
        public ActionResult Admin(AdminViewModel Model)
        {
            _Lecturer.Update(Model.Lecturer);
            _Lecturer.Save();
            return RedirectToAction("Index");
        }
    }
}