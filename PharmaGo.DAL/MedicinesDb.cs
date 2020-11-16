using PharmaGo.BOL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.DAL
{
    public interface IMedicinesDb
    {
        IEnumerable<Medicine> GetMedicines();
        Medicine GetMedicine(long medicineId);
        bool CreateMedicine(Medicine medicine);
        bool UpdateMedicine(Medicine medicine);
        bool DeleteMedicine(long medicineId);
    }
    public class MedicinesDb : IMedicinesDb
    {
        PGADbContext dbContext;
        public MedicinesDb(PGADbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public bool CreateMedicine(Medicine medicine)
        {
            try
            {
                dbContext.Medicines.Add(medicine);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteMedicine(long medicineId)
        {
            try
            {
                var medicine = dbContext.Medicines.Find(medicineId);
                dbContext.Remove(medicine);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Medicine GetMedicine(long medicineId)
        {
            return dbContext.Medicines.Find(medicineId);
        }

        public IEnumerable<Medicine> GetMedicines()
        {
            return dbContext.Medicines;
        }

        public bool UpdateMedicine(Medicine medicine)
        {
            try
            {
                dbContext.Update<Medicine>(medicine);
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
