using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmaGo.BLL;
using PharmaGo.BOL;
using PharmaGoApp.Models.Admin;

namespace PharmaGoApp.Controllers
{
    public class AdminController : Controller
    {
        UserManager<GPAUser> userManager;
        SignInManager<GPAUser> signInManager;
        IPharmaciesBS pharmaciesBS;
        IGPAUsersBS usersBS;

        public AdminController(UserManager<GPAUser> _userManager, 
            SignInManager<GPAUser> _signInManager,
            IPharmaciesBS _pharmaciesBS, IGPAUsersBS _usersBS)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            pharmaciesBS = _pharmaciesBS;
            usersBS = _usersBS;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ManageUsers()
        {
            var result = usersBS.GetGPAUsers().Select(x=>
            new UsersViewModel() 
            { 
                Id=x.Id,
                FName=x.FirstName,
                LName=x.LastName,
                UserName=x.UserName,
                Email=x.Email
            });
            return View(result);
        }

        public IActionResult SuspendUserAccount(string id)
        {
            if(usersBS.DeleteUser(new GPAUser()))
            {

            }
            return View();
        }

        [HttpGet]
        public IActionResult ManageStores()
        {
            var result = pharmaciesBS.GetAllPharmacies().Select(x => new StoreViewModel()
            {
                PharmacyId=x.PharmacyId,
                Name=x.Name,
                Address=x.Address,
                EmailId=x.EmailId,
                Contact=x.Contact
            });
            return View(result);
        }

        [HttpGet]
        public IActionResult CreateStore()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStore(CreateStoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                //first create store here
                
                GPAUser pharmacist = new GPAUser()
                {
                    UserName = model.UserName,
                    FirstName=model.FirstName,
                    LastName=model.LastName,
                    Email = model.Email,
                    // PharmaId=1,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                GPAUser asstPharmacist = new GPAUser()
                {
                    UserName = model.AsstUserName,
                    FirstName = model.AsstFirstName,
                    LastName = model.AsstLastName,
                    Email = model.AsstEmail,
                    // PharmaId=1,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var resultCreate = await userManager.CreateAsync(pharmacist, model.Password);
                var resultRoleAssign = await userManager.AddToRoleAsync(pharmacist, "Pharmacist");
                var asstResultCreate = await userManager.CreateAsync(pharmacist, model.Password);
                var asstResultRoleAssign = await userManager.AddToRoleAsync(pharmacist, "AsstPharmacist");

                PharmaGo.BOL.Pharmacy pharmacy = new PharmaGo.BOL.Pharmacy()
                {
                    Name = model.Name,
                    Address = model.Address,
                    EmailId = model.EmailId,
                    Contact = model.Contact,
                    PharmacistId=pharmacist.Id,
                    AsstPharmacistId=asstPharmacist.Id
                };
                pharmaciesBS.CreatePharmacy(pharmacy);
                //update store id for Pharmacist and asst pharmacist
                pharmacist.PharmaId = pharmacy.PharmacyId;
                asstPharmacist.PharmaId = pharmacy.PharmacyId;
                usersBS.UpdateUser(pharmacist);
                usersBS.UpdateUser(asstPharmacist);
                return RedirectToAction("ManageStores");
            }
            return View();
        }       
    }
}
