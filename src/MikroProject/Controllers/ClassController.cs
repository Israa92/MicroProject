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
    public class ClassController : Controller
    {
        AdminContext _context;
        public ClassController(AdminContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult CreateClass()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateClass(ClassViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var c = new Class();
            c.Id = model.Id;
            c.Name = model.Name;
            c.Student = model.Student;

            _context.Class.Add(c);
            _context.SaveChanges();

            return RedirectToAction("CreatedClass");
        }
        public IActionResult CreatedClass()
        {
            return View();
        }
    }
}


