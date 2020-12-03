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
                if(ValidateDateForAppointment(timeSlots.FirstOrDefault(x => x.Date.Equals(model.Date)), model))
                {
                    var user = await userManager.FindByNameAsync(User.Identity.Name);
                    var appointment = new Appointment()
                    {
                        StoreId = model.StoreId,
                        CustomerId = user.Id,
                        ApptTime = model.ScheduleTime,
                        TimeSlotId = firstSlot.Id
                    };
                    if (appointmentBS.CreateAppointment(appointment))
                        return RedirectToAction("Index");
                    ViewBag.ErrMassage = "Time is already Booked";
                }
                else
                    ViewBag.ErrMassage = "Appointment cant be schedule for: " +model.Date.ToLongDateString();

            }
            ViewBag.Stores = pharmaciesBS.GetAllPharmacies();
            return View();
        }
        public IActionResult DeleteAppointment(int id)
        {
            if(appointmentBS.DeleteAppointment(id))
                return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var appointment = appointmentBS.GetAppointment(id);
            var customerAppointment= new CustomerApointmentViewModel()
            {
                Id = appointment.Id,
                Date = appointment.TimeSlot.Date,
                ScheduleTime = appointment.ApptTime
            };
            return View(customerAppointment);
        }
        [HttpPost]
        public IActionResult Edit(CustomerApointmentViewModel model)
        {
            
            var appointment = appointmentBS.GetAppointment(model.Id);
            var timeSlots = timeSlotsBS.GetTimeSlotsByStoreAndDate(appointment.StoreId, model.Date);
            if (timeSlots.Count() > 0&& ValidateDateForAppointment(timeSlots.FirstOrDefault(x => x.Date.Equals(model.Date)),model))
            {
                appointment.TimeSlot = timeSlots.FirstOrDefault(x => x.Date.Equals(model.Date)) ;
                appointment.ApptTime = model.ScheduleTime;
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "Appointment cant be schedule for: " + model.Date.ToLongDateString();
            return View(model);
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
        /// <summary>
        /// method is responsible to check if appointment time is not get conflicted with others
        /// </summary>
        /// <param name="timeSlot"></param>
        /// <param name="apointmentViewModel"></param>
        /// <returns></returns>
        private bool ValidateDateForAppointment(TimeSlot timeSlot,CustomerApointmentViewModel apointmentViewModel)
        {
            try
            {
                foreach(var appointment in timeSlot.Appointments)
                {
                    TimeSpan timeSpan = appointment.ApptTime.TimeOfDay - apointmentViewModel.ScheduleTime.TimeOfDay;
                    if (appointment.Id!=apointmentViewModel.Id && timeSpan.TotalMinutes < 15 && timeSpan.TotalMinutes > -15)
                        return false;
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
