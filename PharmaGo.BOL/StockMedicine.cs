#region Header
//POCO class of StockMedicine is created here
//Responsible to map medicine and its quantity
#endregion

namespace PharmaGo.BOL
{
    public class StockMedicine
    {
        public long Id { get; set; }
        public Medicine Medicine { get; set; }
        public int Quantity { get; set; }
    }
}
