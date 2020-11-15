#region NameSpaces
using System.Collections.Generic;
#endregion


/// <summary>
/// Application Pharmacy Class 
/// </summary>
namespace PharmaGo.BOL
{
    public class Pharmacy
    {
        public long PharmacyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string Contact { get; set; }
        public string PharmacistId { get; set; }
        public string AsstPharmacistId { get; set; }
        public IEnumerable<StockMedicine> MedStores { get; set; }

        public GPAUser Pharmacist { get; set; }
        public GPAUser AsstPharmacist { get; set; }
    }
}