using PharmaGo.BOL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.DAL
{
    public interface IPharmacyDb
    {
        IEnumerable<Pharmacy> GetPharmacies();
        Pharmacy GetPharmacy(long pharmacyId);
        bool CreatePharmacy(Pharmacy pharmacy);
        bool UpdatePharmacy(Pharmacy pharmacy);
        bool DeletePharmacy(long pharmacyId);
    }
    public class PharmacyDb : IPharmacyDb
    {
        PGADbContext dbContext;
        public PharmacyDb(PGADbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public bool CreatePharmacy(Pharmacy pharmacy)
        {
            try
            {
                dbContext.Pharmacies.Add(pharmacy);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletePharmacy(long pharmacyId)
        {
            try
            {
                var pharmacy = dbContext.Pharmacies.Find(pharmacyId);
                dbContext.Remove(pharmacy);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Pharmacy GetPharmacy(long pharmacyId)
        {
            return dbContext.Pharmacies.Find(pharmacyId);
        }

        public IEnumerable<Pharmacy> GetPharmacies()
        {
            return dbContext.Pharmacies;
        }

        public bool UpdatePharmacy(Pharmacy pharmacy)
        {
            try
            {
                dbContext.Update<Pharmacy>(pharmacy);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
