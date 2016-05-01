using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using MikroProject.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace MikroProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        IdentityDbContext _identityContext;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IdentityDbContext identityContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _identityContext = identityContext;
        }

        public IActionResult Menu()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel viewModel, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // Skapa DB-schema
            await _identityContext.Database.EnsureCreatedAsync();

            // Skapa användaren
            var result = await _userManager.CreateAsync(new IdentityUser(
                viewModel.LoginName), viewModel.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(nameof(LoginViewModel.Password), result.Errors.First().Description);
                return View(viewModel);
            }

            // Logga in användaren
            await _signInManager.PasswordSignInAsync(viewModel.LoginName, viewModel.Password,
                false, false);

            // Omdirigera användaren
            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction("Menu");
            else
                return Redirect(returnUrl);
        }
    }
}
