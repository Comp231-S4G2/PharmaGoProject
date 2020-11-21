using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmaGo.BLL;
using PharmaGo.BOL;
using PharmaGoApp.Models;
using PharmaGoApp.Models.Customer;

namespace PharmaGoApp.Controllers
{
    public class AccountController : Controller
    {
        UserManager<GPAUser> userManager;
        SignInManager<GPAUser> signInManager;
        IGPAUsersBS gPAUsersBS;
        IAppReviewBS appReviewBS;
        public AccountController(UserManager<GPAUser> _userManager, SignInManager<GPAUser> _signInManager,
                                    IGPAUsersBS _gPAUsersBS, IAppReviewBS _appReviewBS)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            gPAUsersBS = _gPAUsersBS;
            appReviewBS = _appReviewBS;
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
                    FirstName=model.FirstName,
                    LastName=model.LastName,
                    // PharmaId=1,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var resultCreate = await userManager.CreateAsync(user, model.Password);
                var resultRoleAssign = await userManager.AddToRoleAsync(user, "Customer");
                var resultSign = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);
                if (resultSign.Succeeded)
                {
                    //var a = User.Identity.IsAuthenticated;
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
            ViewBag.ErrorMessage = "Invalid UserName Or Password";
            return View();
        }

        public async Task<IActionResult> UpdateAccount()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var viewModel = new SignUpViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAccount(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                gPAUsersBS.UpdateUser(user);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public async Task<IActionResult> DeleteAccount()
        {
            var user = await GetLogedInUser();
            gPAUsersBS.DeleteUser(user);
            return RedirectToAction("LogOut");
        }

        private async Task<GPAUser> GetLogedInUser()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            return user;
        }

        public IActionResult CustomerReview()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CustomerReview(CustomerReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppReview app = new AppReview()
                {
                    FluShotServices = model.FluShotServices,
                    ApplicationPerformance = model.ApplicationPerformance,
                    TechnicalAssistanceResponse = model.TechnicalAssistanceResponse,
                    OverallReview = model.OverallReview,
                    UserId = GetLogedInUser().Result.Id
                };
                appReviewBS.AddReview(app);
                ViewBag.SuccessMsg = "Review Submited ";
            }
            return View();
        }

        public IActionResult TechSupportReview()
        {
            return View();
        }
    }
}
