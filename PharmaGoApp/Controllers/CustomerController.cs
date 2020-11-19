using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmaGoApp.Models.Customer;

namespace PharmaGoApp.Controllers
{
    public class CustomerController : Controller
    {
        private static List<CustomerApointmentViewModel> customerAppointments = new List<CustomerApointmentViewModel>();
        public CustomerController()
        {

        }
        public IActionResult Index()
        {
            return View(customerAppointments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
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
            
            return View();
        }

    }
}
