using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmaGo.BOL
{
    public class MedDemand
    {
        public long Id { get; set; }
        public StockMedicine StockMedicine { get; set; }
        public CustomerPrescription CustomerPrescription { get; set; }

        [ForeignKey("StockMedicine")]
        public long StockMedicineId { get; set; }

        [ForeignKey("CustomerPrescription")]
        public long CustomerPrescriptionId { get; set; }
        public int Quantity { get; set; }
        public int InStock { get; set; }

    }
}
