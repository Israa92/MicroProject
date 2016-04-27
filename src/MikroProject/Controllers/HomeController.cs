using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
