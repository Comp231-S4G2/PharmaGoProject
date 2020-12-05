using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.BOL
{
    public class CustomerMedReserve
    {
        public long Id { get; set; }
        public string CustomerId { get; set; }
        public GPAUser Customer { get; set; }
        public long StockMedicineId { get; set; }
        public StockMedicine StockMedicine { get; set; }
    }
}
