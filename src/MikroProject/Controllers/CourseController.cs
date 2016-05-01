using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MikroProject.Models;
using MikroProject.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MikroProject.Controllers
{
    public class CourseController : Controller
    {
        AdminContext _context;
        public CourseController(AdminContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult CreateInstructor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCourse(CourseViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var course = new Course();
            course.Name = model.Name;
            course.Id = model.Id;
            course.Instructor = model.Instructor;
            course.Class = model.Class;
            course.StartDate = model.StartDate;
            course.EndTime = model.EndTime;

            // Add to DB
            _context.Course.Add(course);
            _context.SaveChanges();

            return RedirectToAction("CreatedCourse");
        }
        public IActionResult CreatedCourse()
        {
            return View();
        }
    }
}
