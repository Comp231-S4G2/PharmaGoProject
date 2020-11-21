using PharmaGo.BOL;
using PharmaGo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmaGo.BLL
{
    public interface IStoreMedicineBS
    {
        IEnumerable<BOL.StockMedicine> SearchMedicinesFromStore(string medName);
        IEnumerable<StockMedicine> GetStockMedicines();
        IEnumerable<StockMedicine> GetStockMedicineByStore(long storeId);
        StockMedicine GetStockMedicine(long stockMedicineId);
        bool CreateStockMedicine(StockMedicine stockMedicine);
        bool UpdateStockMedicine(StockMedicine stockMedicine);
        bool DeleteStockMedicine(long stockMedicineId);
    }
    public class StoreMedicineBS : IStoreMedicineBS
    {
        IStockMedicinesDb medicinesStoreDb;
        public StoreMedicineBS(IStockMedicinesDb _medicinesStoreDb)
        {
            medicinesStoreDb = _medicinesStoreDb;
        }

        public bool CreateStockMedicine(StockMedicine stockMedicine)
        {
            return medicinesStoreDb.CreateStockMedicine(stockMedicine);
        }

        public bool DeleteStockMedicine(long stockMedicineId)
        {
            return medicinesStoreDb.DeleteStockMedicine(stockMedicineId);
        }

        public StockMedicine GetStockMedicine(long stockMedicineId)
        {
            return medicinesStoreDb.GetStockMedicine(stockMedicineId);
        }

        public IEnumerable<StockMedicine> GetStockMedicineByStore(long storeId)
        {
            return medicinesStoreDb.GetStockMedicineByStore(storeId);
        }

        public IEnumerable<StockMedicine> GetStockMedicines()
        {
            return medicinesStoreDb.GetStockMedicines();
        }

        public IEnumerable<StockMedicine> SearchMedicinesFromStore(string medName)
        {
            if (medName == null || medName.Trim() == "")
                return medicinesStoreDb.GetStockMedicines();
            return medicinesStoreDb.GetStockMedicines().Where(x => x.Medicine.Name.Contains(medName));
        }

        public bool UpdateStockMedicine(StockMedicine stockMedicine)
        {
            return medicinesStoreDb.UpdateStockMedicine(stockMedicine);
        }
    }
}
