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
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
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

            return RedirectToAction("CreatedStudent");

        }
        public IActionResult CreatedStudent()
        {
            return View();
        }
    }
}
