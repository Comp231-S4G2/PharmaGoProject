using Microsoft.EntityFrameworkCore;
using PharmaGo.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmaGo.DAL
{
    public interface IMedDemandDb
    {
        IEnumerable<MedDemand> GetMedDemands();
        IEnumerable<MedDemand> GetMedDemandsByPrescription(long prescriptionId);
        IEnumerable<MedDemand> GetMedDemands(long stockMedId);
        bool AddMedDemand(MedDemand medDemand);
        bool DeleteMedDemand(long medDemandId);
    }
    public class MedDemandDb : IMedDemandDb
    {
        PGADbContext dbContext;
        public MedDemandDb(PGADbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public bool AddMedDemand(MedDemand medDemand)
        {
            try
            {
                var stockMedicine = dbContext.StockMedicines.Find(medDemand.StockMedicineId);
                if (stockMedicine.Quantity > medDemand.Quantity)
                {
                    stockMedicine.Quantity = stockMedicine.Quantity - medDemand.Quantity;
                    dbContext.Update<StockMedicine>(stockMedicine);
                    dbContext.MedDemands.Add(medDemand);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool DeleteMedDemand(long medDemandId)
        {
            try
            {
                var medicine = dbContext.MedDemands.Find(medDemandId);
                dbContext.MedDemands.Remove(medicine);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<MedDemand> GetMedDemands()
        {
            return dbContext.MedDemands;
        }

        public IEnumerable<MedDemand> GetMedDemands(long stockMedId)
        {
            return dbContext.MedDemands.Where(x=>x.StockMedicineId==stockMedId);
        }

        public IEnumerable<MedDemand> GetMedDemandsByPrescription(long prescriptionId)
        {
            return dbContext.MedDemands.Where(x => x.CustomerPrescriptionId == prescriptionId).Include(x=>x.CustomerPrescription.user).Include(x=>x.StockMedicine.Medicine);
        }
    }
}
