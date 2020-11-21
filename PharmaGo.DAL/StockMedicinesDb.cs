using Microsoft.EntityFrameworkCore;
using PharmaGo.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmaGo.DAL
{
    public interface IStockMedicinesDb
    {
        IEnumerable<StockMedicine> GetStockMedicines();
        IEnumerable<StockMedicine> GetStockMedicineByStore(long storeId);
        StockMedicine GetStockMedicine(long stockMedicineId);
        bool CreateStockMedicine(StockMedicine stockMedicine);
        bool UpdateStockMedicine(StockMedicine stockMedicine);
        bool DeleteStockMedicine(long stockMedicineId);
    }
    public class StockMedicinesDb : IStockMedicinesDb
    {
        PGADbContext dbContext;
        public StockMedicinesDb(PGADbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public bool CreateStockMedicine(StockMedicine stockMedicine)
        {
            try
            {
                dbContext.StockMedicines.Add(stockMedicine);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteStockMedicine(long stockMedicineId)
        {
            try
            {
                var medStore = dbContext.StockMedicines.Find(stockMedicineId);
                dbContext.StockMedicines.Remove(medStore);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public StockMedicine GetStockMedicine(long stockMedicineId)
        {
            var stockMedicine = GetStockMedicines().FirstOrDefault(x=>x.Id==stockMedicineId);
            return stockMedicine;
        }

        public IEnumerable<StockMedicine> GetStockMedicineByStore(long storeId)
        {
            return dbContext.StockMedicines.Where(x => x.PharmaId== storeId).Include(x => x.Medicine).Include(x => x.Pharmacy);
        }

        public IEnumerable<StockMedicine> GetStockMedicines()
        {
            return dbContext.StockMedicines.Include(x=>x.Medicine).Include(x=>x.Pharmacy);
        }

        public bool UpdateStockMedicine(StockMedicine stockMedicine)
        {
            try
            {
                dbContext.Update<StockMedicine>(stockMedicine);
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
