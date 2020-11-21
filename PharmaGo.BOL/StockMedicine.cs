#region Header
//POCO class of StockMedicine is created here
//Responsible to map medicine and its quantity
#endregion

using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaGo.BOL
{
    public class StockMedicine
    {
        public long Id { get; set; }

        [ForeignKey("Medicines")]
        public long MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Pharmacies")]
        public long PharmaId { get; set; }
        public Pharmacy Pharmacy { get; set; }
    }
}
