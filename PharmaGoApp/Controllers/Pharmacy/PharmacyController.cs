﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmaGoApp.Models.Pharmacy;

namespace PharmaGoApp.Controllers.Pharmacy
{
    public class PharmacyController : Controller
    {
        public static List<AppointmentViewModel> appointments = new List<AppointmentViewModel>()
        {
            new AppointmentViewModel(){Id=1,CustomerName="Neeraj",TimeSlot="9.00 AM",Age="20"},
            new AppointmentViewModel(){Id=2,CustomerName="Fred",TimeSlot="9.30 AM",Age="25"},
            new AppointmentViewModel(){Id=3,CustomerName="Neeraj",TimeSlot="10.00 AM",Age="24"},
        };
        public PharmacyController()
        {

        }
        public IActionResult Index()
        {
            return View(appointments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            var appointment=appointments.Find(x=>x.Id==id);
            appointments.Remove(appointment);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var appointment = appointments.Find(x => x.Id == id);
            return View(appointment);
        }

        [HttpPost]
        public IActionResult Edit(AppointmentViewModel model)
        {
            var appointment = appointments.Find(x => x.Id == model.Id);
            appointment.CustomerName = model.CustomerName;
            appointment.TimeSlot = model.TimeSlot;
            return RedirectToAction("Index");
        }

    }
}