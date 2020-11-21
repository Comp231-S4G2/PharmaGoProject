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
    }
    public class StoreMedicineBS : IStoreMedicineBS
    {
        IStockMedicinesDb medicinesStoreDb;
        public StoreMedicineBS(IStockMedicinesDb _medicinesStoreDb)
        {
            medicinesStoreDb = _medicinesStoreDb;
        }
        public IEnumerable<StockMedicine> SearchMedicinesFromStore(string medName)
        {
            if (medName == null || medName.Trim() == "")
                return medicinesStoreDb.GetStockMedicines();
            return medicinesStoreDb.GetStockMedicines().Where(x => x.Medicine.Name.Contains(medName));
        }
    }
}
