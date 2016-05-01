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
    public class InstructorController : Controller
    {
        AdminContext _context;
        public InstructorController(AdminContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateInstructor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateInstructor(InstructorViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var instructor = new Instructor();
            instructor.Id = model.Id;

            _context.Instructor.Add(instructor);
            _context.SaveChanges();

            return RedirectToAction("CreatedInstructor");

        }
    }
}

