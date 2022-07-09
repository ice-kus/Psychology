using Microsoft.AspNetCore.Mvc;
using Psychology.ViewModels;
using Psychology.Data.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System;

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
            Model.Group.Name = Model.Group.Name.Trim();
            _Group.Update(Model.Group);
            if (!_Group.Save())
            {
                Model.Message = "Группа с таким наименованием уже есть в базе";
                Model.ListStudent = _Student.List.Where(i => i.GroupId == Model.Group.Id).OrderBy(i => i.Name);
                if (Model.ListStudent.Count() == 0)
                    Model.Delete = true;
                return View(Model);
            }
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
            Model.Group.Name = Model.Group.Name.Trim();
            _Group.Create(Model.Group.Name);
            if (!_Group.Save())
            {
                Model.Message = "Группа с таким наименованием уже есть в базе";
                return View(Model);
            }
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
            if (!_Student.Save())
            {
                Model.Message = "Студент с таким номером зачетной книжки уже есть в базе";
                return View(Model);
            }
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
            Model.Student.Name = Model.Student.Name.Trim();
            Model.Student.Password = Model.Student.Password.Trim();
            _Student.Create(Model.Student.Id, Model.Student.Name, Model.Student.Password, Model.Group.Id);
            if (!_Student.Save())
            {
                Model.Message = "Студент с таким номером зачетной книжки уже есть в базе";
                return View(Model);
            }
            return RedirectToAction("Group", new { Id = Model.Group.Id});
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
            Model.Lecturer.Name = Model.Lecturer.Name.Trim();
            Model.Lecturer.Login = Model.Lecturer.Login.Trim();
            Model.Lecturer.Password = Model.Lecturer.Password.Trim();
            _Lecturer.Update(Model.Lecturer);
            if (!_Lecturer.Save())
            {
                Model.Message = "Преподаватель с таким логином уже есть в базе";
                return View(Model);
            }
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
            Model.Lecturer.Name = Model.Lecturer.Name.Trim();
            Model.Lecturer.Login = Model.Lecturer.Login.Trim();
            Model.Lecturer.Password = Model.Lecturer.Password.Trim();
            _Lecturer.Create(Model.Lecturer.Name, Model.Lecturer.Login, Model.Lecturer.Password);
            if (!_Lecturer.Save())
            {
                Model.Message = "Преподаватель с таким логином уже есть в базе";
                return View(Model);
            }
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
            Model.Lecturer.Password = Model.Lecturer.Password.Trim();
            _Lecturer.Update(Model.Lecturer);
            _Lecturer.Save();
            return RedirectToAction("Index");
        }
    }
}