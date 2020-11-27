using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaGoApp.Models.Common
{
    public class ReserveMedicine
    {
        public long StockMedicineId { get; set; }
        public string MedName { get; set; }
        public double UnitPrice { get; set; }
        public string PatientName { get; set; }
        public string PatientId { get; set; }
        public int Quantity { get; set; }
    }
}
