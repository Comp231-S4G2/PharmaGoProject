using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmaGo.BLL;
using PharmaGo.BOL;
using PharmaGoApp.Models.Common;
using PharmaGoApp.Models.Pharmacy;

namespace PharmaGoApp.Controllers.Pharmacy
{
    public class PharmacyController : Controller
    {
        ICustomerPrescriptionBS customerPrescriptionBS;
        IGPAUsersBS gPAUsersBS;
        IStoreMedicineBS storeMedicineBS;
        ITimeSlotsBS TimeSlotsBS;
        UserManager<GPAUser> userManager;
        IAppointmentBS appointmentBS;
        public static List<AppointmentViewModel> appointments = new List<AppointmentViewModel>()
        {
            new AppointmentViewModel(){Id=1,CustomerName="Neeraj",TimeSlot="9.00 AM"},
            new AppointmentViewModel(){Id=2,CustomerName="Fred",TimeSlot="9.30 AM"},
            new AppointmentViewModel(){Id=3,CustomerName="Neeraj",TimeSlot="10.00 AM"},
        };

        

        public PharmacyController(ICustomerPrescriptionBS _customerPrescriptionBS, IGPAUsersBS _gPAUsersBS
                                    , IStoreMedicineBS _storeMedicineBS, ITimeSlotsBS _TimeSlotsBS, UserManager<GPAUser> _userManager, IAppointmentBS _appointmentBS)
        {
            customerPrescriptionBS = _customerPrescriptionBS;
            gPAUsersBS = _gPAUsersBS;
            storeMedicineBS = _storeMedicineBS;
            TimeSlotsBS = _TimeSlotsBS;
            userManager = _userManager;
            appointmentBS = _appointmentBS;
        }

        private async Task<GPAUser> GetLogedInUser()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            return user;
        }

        public IActionResult GetSchedules()
        {
            var result = TimeSlotsBS.GetTimeSlots().Select(x =>
            new AddSlotViewModel()
            {
                Id=x.Id,
                Date=x.Date,
                ScheduleStartTime=x.ScheduleStartTime,
                ScheduleEndTime=x.ScheduleEndTime
            });
            return View(result);
        }

        [HttpGet]
        public IActionResult CreateSchedule()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSchedule(AddSlotViewModel model)
        {
            if (ModelState.IsValid)
            {
                long pharmaId = 0;
                long.TryParse(GetLogedInUser().Result.PharmaId.ToString(), out pharmaId);
                var timeSlot = new TimeSlot()
                {
                    Date = model.Date,
                    ScheduleEndTime = model.ScheduleEndTime,
                    ScheduleStartTime = model.ScheduleStartTime,
                    PharmacyId = pharmaId
                };
                
                if (TimeSlotsBS.AddTimeSlot(timeSlot))
                {
                    return RedirectToAction("GetSchedules");
                }
                ViewBag.ErrMassage = "Schedule can not be created";
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditSchedule(long id)
        {
            var timeSlot = TimeSlotsBS.GetTimeSlot(id);

            var result = new AddSlotViewModel()
            {
                Id = id,
                Date = timeSlot.Date,
                ScheduleStartTime = timeSlot.ScheduleStartTime,
                ScheduleEndTime = timeSlot.ScheduleEndTime
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult EditSchedule(AddSlotViewModel model)
        {
            long pharmaId = 0;
            long.TryParse(GetLogedInUser().Result.PharmaId.ToString(), out pharmaId);
            var result = new TimeSlot()
            {
                Id = model.Id,
                Date = model.Date,
                ScheduleEndTime = model.ScheduleEndTime,
                ScheduleStartTime = model.ScheduleStartTime,
                PharmacyId = pharmaId
            };
            if(TimeSlotsBS.UpdateTimeSlot(result))
                return RedirectToAction("GetSchedules");
            ViewBag.ErrMassage = "Schedule can not be Updated";
            return View();
        }
        public IActionResult DeleteSchedule(long id)
        {
            TimeSlotsBS.DeleteTimeSlot(id);
            return RedirectToAction("GetSchedules");
        }

        public IActionResult Index()
        {
            long pharmaId = 0;
            long.TryParse(GetLogedInUser().Result.PharmaId.ToString(), out pharmaId);
            var result = appointmentBS.GetAppointmentsByStore(pharmaId).Select(x=>new AppointmentViewModel()
            {
                Id=x.Id,
                TimeSlot=x.ApptTime.ToShortTimeString(),
                AppointmentDate=x.TimeSlot.Date.ToShortDateString(),
                CustomerName=x.Customer.UserName
            });
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete(long id)
        {
            appointmentBS.DeleteAppointment(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var result = appointmentBS.GetAppointment(id); 
            var appointment=new AppointmentViewModel()
            {
                Id = result.Id,
                TimeSlot = result.ApptTime.ToShortTimeString(),
                AppointmentDate = result.TimeSlot.Date.ToShortDateString(),
                CustomerName = result.Customer.UserName
            };
            return View(appointment);
        }

        [HttpPost]
        public IActionResult Edit(AppointmentViewModel model)
        {
            var result = appointmentBS.GetAppointment(model.Id);
            var appointment = appointments.Find(x => x.Id == model.Id);
            appointment.CustomerName = model.CustomerName;
            result.ApptTime = DateTime.Parse(model.TimeSlot);
            long pharmaId = 0;
            long.TryParse(GetLogedInUser().Result.PharmaId.ToString(), out pharmaId);
            var slots= TimeSlotsBS.GetTimeSlotsByStoreAndDate(pharmaId, DateTime.Parse(model.AppointmentDate));
            if (slots.Count() > 0)
            {
                result.TimeSlotId = slots.First().Id;
                if (!appointmentBS.UpdateAppointment(result))
                {
                    ViewBag.ErrorMessage = "Cant schedule appointment ";
                    return View();
                }
                    
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult GetPrescriptions()
        {
            var result = customerPrescriptionBS.GetCustomerPrescriptions().Select(x=>
            new PrescriptionValidateViewModel()
            { 
                FilePath=x.PrescriptionPath,//.Replace("/", "\\"),
                CustomerId =x.UserId,
                CustomerName=x.user.UserName,
                PrescriptionId=x.Id
            
            });
            return View(result);
        }

        //ApprovePrescription
        [HttpGet]
        public IActionResult ApprovePrescription(long id)
        {
            var medicinesReserve = customerPrescriptionBS.GetCustomerPrescriptionMedDemands(id).Select(x=>
            new ReserveMedicine()
            {
                PrescriptionId=id,
                StockMedicineId=x.StockMedicineId,
                MedName=x.StockMedicine.Medicine.Name,
                UnitPrice=x.StockMedicine.Medicine.Price,
                PatientName=x.CustomerPrescription.user.UserName,
                PatientId=x.CustomerPrescription.UserId,
                Quantity=x.Quantity
            });
            TempData["PrescriptionId"] = id;
            return View(medicinesReserve);
        }

        [HttpGet]
        public IActionResult CreateReserveMed()
        {
            long prescriptionId = 0;
            long.TryParse(TempData["PrescriptionId"].ToString(),out prescriptionId);
            var result = customerPrescriptionBS.GetCustomerPrescriptions()
                .Where(y => y.Id == prescriptionId)
                .Select(x =>
            new ReserveMedicine()
            {
                PrescriptionId = prescriptionId,
                PatientName = x.user.UserName,
                PatientId = x.UserId
            }).FirstOrDefault(x=>x.PrescriptionId==prescriptionId);
            ViewBag.StockMedicines = storeMedicineBS.GetStockMedicines();
            return View(result);
        }

        [HttpPost]
        public IActionResult CreateReserveMed(ReserveMedicine model)
        {
            if (ModelState.IsValid)
            {
                var prescription = customerPrescriptionBS.GetCustomerPrescriptions().FirstOrDefault(x => x.Id == model.PrescriptionId);
                var prescriptionMedicine = new MedDemand()
                {
                    CustomerPrescriptionId=model.PrescriptionId,
                    StockMedicineId=model.StockMedicineId,
                    Quantity=model.Quantity,
                    InStock=1
                };
                var result=customerPrescriptionBS.SavePrescriptionMedicine(prescription,prescriptionMedicine);
                if(result)
                    return RedirectToAction("ApprovePrescription",new { id = model.PrescriptionId });
                ViewBag.ErrMessage = "Stock is not sufficient";
            }
            ViewBag.StockMedicines = storeMedicineBS.GetStockMedicines();
            return View();
        }
    }
}
