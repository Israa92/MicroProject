using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MikroProject.ViewModels;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MikroProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //nothing
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        IdentityDbContext _identityContext;

        public HomeController(
            UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        IdentityDbContext identityContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _identityContext = identityContext;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            await _identityContext.Database.EnsureCreatedAsync();

            var result = await _userManager.CreateAsync(new IdentityUser(
                viewModel.LoginName), viewModel.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(nameof(LoginViewModel.Password), result.Errors.First().Description);
                return View(viewModel);
            }

            //logga in användaren
            await _signInManager.PasswordSignInAsync(viewModel.LoginName, viewModel.Password,
                false, false);

            //omdirigera användaren
            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction("index");
            else
                return Redirect(returnUrl);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }
    }
}
