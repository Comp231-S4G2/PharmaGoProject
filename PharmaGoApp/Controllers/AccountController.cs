using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmaGo.BOL;
using PharmaGoApp.Models;

namespace PharmaGoApp.Controllers
{
    public class AccountController : Controller
    {
        UserManager<GPAUser> userManager;
        SignInManager<GPAUser> signInManager;

        public AccountController(UserManager<GPAUser> _userManager, SignInManager<GPAUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                GPAUser user = new GPAUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    // PharmaId=1,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var resultCreate = await userManager.CreateAsync(user, model.Password);
                var resultRoleAssign = await userManager.AddToRoleAsync(user, "Customer");
                var resultSign = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);
                if (resultSign.Succeeded)
                {
                    var a = User.Identity.IsAuthenticated;
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
            //return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);

                if (Result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}
