using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmaGo.BLL;
using PharmaGoApp.Models.Customer;

namespace PharmaGoApp.Controllers
{
    public class CustomerController : Controller
    {
        private static List<CustomerApointmentViewModel> customerAppointments = new List<CustomerApointmentViewModel>();
       
        private IStoreMedicineBS storeMedicineBS;
        public CustomerController(IStoreMedicineBS _storeMedicineBS)
        {
            storeMedicineBS = _storeMedicineBS;
        }
        public IActionResult Index()
        {
            return View(customerAppointments);
        }

        /// <summary>
        /// Create Appointment HttpGet
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Create 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(CustomerApointmentViewModel model)
        {
            model.Id = customerAppointments.Count() + 1;
            customerAppointments.Add(model);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var appointment = customerAppointments.Find(x => x.Id == id);
            customerAppointments.Remove(appointment);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var appointment = customerAppointments.Find(x => x.Id == id);
            return View(appointment);
        }
        [HttpPost]
        public IActionResult Edit(CustomerApointmentViewModel model)
        {
            var appointment = customerAppointments.Find(x => x.Id == model.Id);
            appointment.Date=model.Date;
            appointment.ScheduleTime = model.ScheduleTime;
            appointment.PatientName = model.PatientName;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SearchMedicine(string Name)
        {
            var medicines = storeMedicineBS.SearchMedicinesFromStore(Name);
            return View(medicines);
        }

    }
}
