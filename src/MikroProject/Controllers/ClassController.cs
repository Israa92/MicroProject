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

        public ClassViewModel[] GetAllClasses()
        {
            return _context.Class
                .Select(r => new ClassViewModel
                {
                    Id = r.Id,
                    Name =r.Name,
                    Student = r.Student,
                })
            .ToArray();
        }

        public IActionResult Update()
        {
            return View(GetAllClasses());
        }

        public IActionResult Edit(int id)
        {
            var classRoom = _context.Class.FirstOrDefault(s => s.Id == id);
            ClassViewModel viewModel = new ClassViewModel
            {
                Name = classRoom.Name,
                Student = classRoom.Student,
               
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ClassViewModel editModel)
        {

            var classRoom = _context.Class.FirstOrDefault(s => s.Id == editModel.Id);
            classRoom.Name = editModel.Name;
            classRoom.Student = editModel.Student;

            _context.SaveChanges();
            return RedirectToAction("UpdateClass");
        }
    }
}


