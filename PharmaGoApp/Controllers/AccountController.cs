#region Namespaces

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmaGo.BLL;
using PharmaGo.BOL;
using PharmaGoApp.Helper;
using PharmaGoApp.Models;
using PharmaGoApp.Models.Common;
using PharmaGoApp.Models.Constant;
using PharmaGoApp.Models.Customer;
using System;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace PharmaGoApp.Controllers
{
    /// <summary>
    /// Account Controller
    /// Handling Account related events ex:SignUp,LogIn,LogOut,Account Modification
    /// </summary>
    public class AccountController : Controller
    {
        UserManager<GPAUser> userManager;
        SignInManager<GPAUser> signInManager;
        IGPAUsersBS gPAUsersBS;
        IAppReviewBS appReviewBS;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_userManager"></param>
        /// <param name="_signInManager"></param>
        /// <param name="_gPAUsersBS"></param>
        /// <param name="_appReviewBS"></param>
        public AccountController(UserManager<GPAUser> _userManager, SignInManager<GPAUser> _signInManager,
                                    IGPAUsersBS _gPAUsersBS, IAppReviewBS _appReviewBS)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            gPAUsersBS = _gPAUsersBS;
            appReviewBS = _appReviewBS;
        }

        /// <summary>
        /// Index method for HomePage
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// ActionMethod is responsible to render SignUp View
        /// </summary>
        /// <returns>SignUp View</returns>
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        /// <summary>
        /// ActionMethod is responsible for signing up the user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

                var sendMail = new EmailJobHelperViewModel()
                {
                    ReceiverMailId = user.Email,
                    Subject = MailConstant.AccountCreatedSubject,
                    HtmlMessage = MailConstant.AccountCreatedMessge(user.UserName)
                };
                EmailJobHelper.SendMailHelper(sendMail);

                var resultCreate = await userManager.CreateAsync(user, model.Password);

                if(gPAUsersBS.GetGPAUsers().Count()>0)
                    await userManager.AddToRoleAsync(user, "Customer");
                else
                    await userManager.AddToRoleAsync(user, "Admin");
                var resultSign = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);
                if (resultSign.Succeeded)
                {
                    //var a = User.Identity.IsAuthenticated;
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }

        /// <summary>
        /// ActionMethod is responsible to LogOut the user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
            //return RedirectToAction("Login", "Account");
        }

        /// <summary>
        /// ActionMethod is responsible to render LogIn View
        /// </summary>
        /// <returns>LogIn View</returns>
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        /// <summary>
        /// ActionMethod is responsible to do LogIn 
        /// </summary>
        /// <param name="model">LogInViewModel</param>
        /// <returns>Logs In Authenticated users</returns>
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

        /// <summary>
        /// ActionMethod is responsible to render UpdateAccount View
        /// </summary>
        /// <returns>UpdateAccount View</returns>
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

        /// <summary>
        /// ActionMethod is responsible to render UpdateAccount View
        /// </summary>
        /// <param name="model">SignUpViewModel</param>
        /// <returns>updated account with Index page</returns>
        [HttpPost]
        public async Task<IActionResult> UpdateAccount(SignUpViewModel model)
        {
            if (ModelState.IsValid||!ModelState.IsValid)
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

        /// <summary>
        /// ActionMethod is responsible to delete Logged In User
        /// </summary>
        /// <returns>Delete and LogOut</returns>
        public async Task<IActionResult> DeleteAccount()
        {
            var user = await GetLogedInUser();
            if (gPAUsersBS.DeleteUser(user))
            {
                var sendMail = new EmailJobHelperViewModel()
                {
                    ReceiverMailId = user.Email,
                    Subject = MailConstant.AccountDeletionSubject,
                    HtmlMessage = MailConstant.AccountDeletionMessge(user.UserName)
                };
                EmailJobHelper.SendMailHelper(sendMail);
            }
            return RedirectToAction("LogOut");
        }
        /// <summary>
        /// method is responsible to return logged in user
        /// </summary>
        /// <returns>logged in user</returns>
        private async Task<GPAUser> GetLogedInUser()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            return user;
        }

        /// <summary>
        /// ActionMethod is responsible to render Customer Review
        /// </summary>
        /// <returns>CustomerReview View</returns>
        public IActionResult CustomerReview()
        {
            return View();
        }

        /// <summary>
        /// ActionMethod is responsible to save Customer Review
        /// </summary>
        /// <param name="model">Customer Review ViewModel</param>
        /// <returns>CustomerReview View</returns>
        [HttpPost]
        public async Task<IActionResult> CustomerReview(CustomerReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                //creating ViewModel and initializing it
                AppReview app = new AppReview()
                {
                    FluShotServices = model.FluShotServices,
                    ApplicationPerformance = model.ApplicationPerformance,
                    TechnicalAssistanceResponse = model.TechnicalAssistanceResponse,
                    OverallReview = model.OverallReview,
                    UserId = GetLogedInUser().Result.Id
                };
                //Add review to DB
                appReviewBS.AddReview(app);
                ViewBag.SuccessMsg = "Review Submited ";
            }
            //return the view 
            return View();
        }

        /// <summary>
        /// ActionMethod is responsible to render TechSupportReview View
        /// </summary>
        /// <returns>TechSupportReview View</returns>
        public IActionResult TechSupportReview()
        {
            return View();
        }
    }
}
