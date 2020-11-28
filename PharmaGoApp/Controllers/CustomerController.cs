using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmaGo.BLL;
using PharmaGo.BOL;
using PharmaGoApp.Models.Customer;

namespace PharmaGoApp.Controllers
{
    public class CustomerController : Controller
    {
        private static List<CustomerApointmentViewModel> customerAppointments = new List<CustomerApointmentViewModel>();

        UserManager<GPAUser> userManager;
        private IStoreMedicineBS storeMedicineBS;
        private readonly IHostingEnvironment webHostEnvironment;
        private ICustomerPrescriptionBS customerPrescriptionBS;
        private IAppointmentBS appointmentBS;
        private ITimeSlotsBS timeSlotsBS;
        private IPharmaciesBS pharmaciesBS;
        public CustomerController(UserManager<GPAUser> _userManager, IStoreMedicineBS _storeMedicineBS, IHostingEnvironment _webHostEnvironment, 
            ICustomerPrescriptionBS _customerPrescriptionBS, IAppointmentBS _appointmentBS, ITimeSlotsBS _timeSlotsBS, IPharmaciesBS _pharmaciesBS)
        {
            userManager = _userManager;
            storeMedicineBS = _storeMedicineBS;
            webHostEnvironment = _webHostEnvironment;
            customerPrescriptionBS = _customerPrescriptionBS;
            appointmentBS = _appointmentBS;
            timeSlotsBS = _timeSlotsBS;
            pharmaciesBS = _pharmaciesBS;
        }
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var prescriptions = appointmentBS.GetAppointmentsByPatient(user.Id).Select(x=>
            new CustomerApointmentViewModel() 
            { 
                Id=x.Id,
                PatientName=user.UserName,
                Date=x.TimeSlot.Date,
                ScheduleTime=x.ApptTime,
                StoreId=x.StoreId,
                StoreName=x.TimeSlot.Pharmacy.Name
            });
            return View(prescriptions);
        }

        [HttpGet]
        public IActionResult GetSchedulesByStoreAndDate(long storeId,DateTime date)
        {
            var timeSlots = timeSlotsBS.GetTimeSlotsByStoreAndDate(storeId, date);
            var result = new List<CustomerApointmentViewModel>();
            if (timeSlots.Count() > 0)
            {
                var firstSlot = timeSlots.FirstOrDefault(x => x.Date.Equals(date));
                result = firstSlot.Appointments.Select(x =>
                   new CustomerApointmentViewModel()
                   {
                       ScheduleTime = x.ApptTime,
                       ScheduleEndTime = x.ApptTime.AddMinutes(15)
                   }).ToList();
                ViewBag.StartTime = firstSlot.ScheduleStartTime.ToLongTimeString();
                ViewBag.EndTime = firstSlot.ScheduleEndTime.ToLongTimeString();
            }
            else
            {
                ViewBag.ErrMessage = "No Time Slot Is Available For " + date.ToLongDateString();
            } 
            ViewBag.Date = date.ToLongDateString();
            return PartialView(result);
        }

        /// <summary>
        /// Create Appointment HttpGet
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CreateAppointment()
        {
            ViewBag.Stores = pharmaciesBS.GetAllPharmacies();
            return View();
        }
        /// <summary>
        /// Create 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CustomerApointmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var timeSlots = timeSlotsBS.GetTimeSlotsByStoreAndDate(model.StoreId, model.Date);
                var firstSlot = timeSlots.FirstOrDefault(x => x.Date.Equals(model.Date));
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var appointment = new Appointment()
                {
                    StoreId=model.StoreId,
                    CustomerId=user.Id,
                    ApptTime=model.ScheduleTime,
                    TimeSlotId=firstSlot.Id
                };
                if(appointmentBS.CreateAppointment(appointment))
                    return RedirectToAction("Index");
                ViewBag.ErrMassage = "Time is already Booked";
            }
            ViewBag.Stores = pharmaciesBS.GetAllPharmacies();
            return View();
        }
        public IActionResult DeleteAppointment(int id)
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

        [HttpGet]
        public IActionResult SearchMedicine()
        {
            var medicines = storeMedicineBS.SearchMedicinesFromStore("");
            return View(medicines);
        }

        [HttpPost]
        public IActionResult SearchMedicine(string MedName)
        {
            var medicines = storeMedicineBS.SearchMedicinesFromStore(MedName);
            return View(medicines);
        }

        [HttpGet]
        public IActionResult UploadPrescription()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadPrescription(CustomerPrescriptionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var uploads = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
                FileUploadHelper objFile = new FileUploadHelper();
                string strFilePath = await objFile.SaveFileAsync(model.formFile, uploads);
                strFilePath = strFilePath
                 .Replace(webHostEnvironment.WebRootPath, string.Empty)
                 .Replace("\\", "/"); //Relative Path can be stored in database or do logically what is needed.
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var prescription = new CustomerPrescription()
                {
                    PrescriptionPath = strFilePath,
                    UserId = user.Id
                };
                customerPrescriptionBS.SavePrescription(prescription);
                ViewBag.SuccessMsg = "Prescription Uploaded Successfully";
            }

            return View();
        }
    }
}
