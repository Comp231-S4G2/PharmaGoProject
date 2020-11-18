using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmaGo.BLL;
using PharmaGo.BOL;

namespace PharmaGoApp.Controllers
{
    public class MedicinesController : Controller
    {
        IMedicinesBS medicinesBs;
        public MedicinesController(IMedicinesBS _medicinesBs)
        {
            medicinesBs = _medicinesBs;
        }
        public IActionResult Index()
        {
            var medicines = medicinesBs.GetMedicines();
            return View(medicines);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Medicine model)
        {
            if(medicinesBs.CreateMedicine(model))
                return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var model = medicinesBs.GetMedicine(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Medicine model)
        {
            medicinesBs.UpdateMedicine(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            medicinesBs.DeleteMedicine(id);
            return RedirectToAction("Index");
        }
    }
}
