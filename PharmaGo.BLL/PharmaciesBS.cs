using PharmaGo.BOL;
using PharmaGo.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.BLL
{
    public interface IPharmaciesBS
    {
        IEnumerable<Pharmacy> GetAllPharmacies();
        bool CreatePharmacy(Pharmacy pharmacy);
        bool UpdatePharmacy(Pharmacy pharmacy);
    }
    public class PharmaciesBS : IPharmaciesBS
    {
        IPharmacyDb pharmacyDb;
        public PharmaciesBS(IPharmacyDb _pharmacyDb)
        {
            pharmacyDb = _pharmacyDb;
        }
        public bool CreatePharmacy(Pharmacy pharmacy)
        {
            return pharmacyDb.CreatePharmacy(pharmacy);
        }

        public IEnumerable<Pharmacy> GetAllPharmacies()
        {
            return pharmacyDb.GetPharmacies();
        }

        public bool UpdatePharmacy(Pharmacy pharmacy)
        {
            return pharmacyDb.UpdatePharmacy(pharmacy);
        }
    }
}
