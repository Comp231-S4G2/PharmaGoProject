using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmaGo.BLL;
using PharmaGo.BOL;
using PharmaGoApp.Models.Pharmacy;

namespace PharmaGoApp.Controllers.Pharmacy
{
    public class AsstPharmacistController : Controller
    {
        IStoreMedicineBS storeMedicineBS;
        IMedicinesBS medicinesBS;
        UserManager<GPAUser> userManager;
        public AsstPharmacistController(UserManager<GPAUser> _userManager, IStoreMedicineBS _storeMedicineBS, IMedicinesBS _medicinesBS)
        {
            storeMedicineBS = _storeMedicineBS;
            userManager = _userManager;
            medicinesBS = _medicinesBS;
        }
        private async Task<GPAUser> GetLogedInUser()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            return user;
        }

        public IActionResult Index()
        {
            var medicines = storeMedicineBS.GetStockMedicineByStore(GetLogedInUser().Result.PharmaId??0);
            return View(medicines);
        }

        [HttpGet]
        public IActionResult CreateStockMedicine()
        {
            ViewBag.Medicines = medicinesBS.GetMedicines();
            return View();
        }

        [HttpPost]
        public IActionResult CreateStockMedicine(CreateStockMedicineViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pharmaId = GetLogedInUser().Result.PharmaId ?? 0;
                var stckMed = new StockMedicine()
                {
                    Quantity = model.Quantity,
                    MedicineId = model.MedId,
                    PharmacyId = pharmaId,
                };
                storeMedicineBS.CreateStockMedicine(stckMed);
                return RedirectToAction("Index");
            }
            ViewBag.Medicines = medicinesBS.GetMedicines();
            return View();
        }
        public IActionResult Delete(long id)
        {
            storeMedicineBS.DeleteStockMedicine(id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(long id)
        {
            var stockMed = storeMedicineBS.GetStockMedicine(id);
            UpdateStockMedicineViewModel stock = new UpdateStockMedicineViewModel()
            {
                Id = stockMed.Id,
                MedName = stockMed.Medicine.Name,
                Quantity = stockMed.Quantity
            };
            return View();
        }

        [HttpPost]
        public IActionResult Edit(UpdateStockMedicineViewModel model)
        {
            if (ModelState.IsValid)
            {
                var stockMed = storeMedicineBS.GetStockMedicine(model.Id);
                stockMed.Quantity = model.Quantity;
                storeMedicineBS.UpdateStockMedicine(stockMed);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
