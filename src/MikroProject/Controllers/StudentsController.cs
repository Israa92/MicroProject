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
        AdminContext context;
        // GET: /<controller>/
        public StudentViewModel Edit(int id)
        {
            var student = context.Student.FirstOrDefault(s => s.Id == id);
            return new StudentViewModel
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                IDNumber = student.IDNumber,
                Class = student.Class,
            };
        }

        public void Update(StudentViewModel editModel)
        {
            var student = context.Student.FirstOrDefault(s => s.Id == editModel.Id);
            student.FirstName = editModel.FirstName;
            student.LastName = editModel.LastName;
            student.IDNumber = editModel.IDNumber;
            student.Class = editModel.Class;

            context.SaveChanges();
        }

        public StudentViewModel[] GetAllStudents()
        {
            return context.Student
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
    }
}
