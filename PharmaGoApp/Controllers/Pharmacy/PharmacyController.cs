using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public static List<AppointmentViewModel> appointments = new List<AppointmentViewModel>()
        {
            new AppointmentViewModel(){Id=1,CustomerName="Neeraj",TimeSlot="9.00 AM",Age="20"},
            new AppointmentViewModel(){Id=2,CustomerName="Fred",TimeSlot="9.30 AM",Age="25"},
            new AppointmentViewModel(){Id=3,CustomerName="Neeraj",TimeSlot="10.00 AM",Age="24"},
        };
        public PharmacyController(ICustomerPrescriptionBS _customerPrescriptionBS, IGPAUsersBS _gPAUsersBS
                                    , IStoreMedicineBS _storeMedicineBS)
        {
            customerPrescriptionBS = _customerPrescriptionBS;
            gPAUsersBS = _gPAUsersBS;
            storeMedicineBS = _storeMedicineBS;
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
                customerPrescriptionBS.SavePrescriptionMedicine(prescription,prescriptionMedicine);
                return RedirectToAction("ApprovePrescription",new { id = model.PrescriptionId });
            }
            ViewBag.StockMedicines = storeMedicineBS.GetStockMedicines();
            return View();
        }
    }
}
