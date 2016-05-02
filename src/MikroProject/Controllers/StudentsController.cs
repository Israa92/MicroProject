using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MikroProject.ViewModels;
using MikroProject.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MikroProject.Controllers
{
    public class StudentsController : Controller
    {
        AdminContext _context;
        public StudentsController(AdminContext context)
        {
            _context = context;
        }

        public StudentViewModel[] GetAllStudents()
        {
            return _context.Student
                .Select(r => new StudentViewModel
        {
                    Id = r.Id,
                    FirstName = r.FirstName,
                    LastName = r.LastName,
                    IDNumber = r.IDNumber,
                    Class = r.Class,
                })
            .ToArray();
        }

        public IActionResult Update()
        {
            return View(GetAllStudents());
        }

        public IActionResult Edit(int id)
        {
            var student = _context.Student.FirstOrDefault(s => s.Id == id);
            StudentViewModel viewModel = new StudentViewModel
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                IDNumber = student.IDNumber,
                Class = student.Class,
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(StudentViewModel editModel)
        {
            //StudentViewModel editModel = new StudentViewModel;

            var student = _context.Student.FirstOrDefault(s => s.Id == editModel.Id);
            student.FirstName = editModel.FirstName;
            student.LastName = editModel.LastName;
            student.IDNumber = editModel.IDNumber;
            student.Class = editModel.Class;

            _context.SaveChanges();
            return RedirectToAction("update");
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var student = new Student();
            student.Id = model.Id;

            // Add to DB
            _context.Student.Add(student);
            _context.SaveChanges();

            return RedirectToAction("update");

        }
        //public IActionResult CreatedStudent()
        //{
        //    return View();
        //}
    }
}
