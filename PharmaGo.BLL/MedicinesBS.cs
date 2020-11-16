
using PharmaGo.BOL;
using PharmaGo.DAL;
using System.Collections.Generic;

namespace PharmaGo.BLL
{
    public interface IMedicinesBS
    {
        IEnumerable<Medicine> GetMedicines();
        Medicine GetMedicine(long medicineId);
        bool CreateMedicine(Medicine medicine);
        bool UpdateMedicine(Medicine medicine);
        bool DeleteMedicine(long medicineId);
    }
    public class MedicinesBS : IMedicinesBS
    {
        IMedicinesDb medicinesDb;
        public MedicinesBS(IMedicinesDb _medicinesDb)
        {
            medicinesDb = _medicinesDb;
        }

        public bool CreateMedicine(Medicine medicine)
        {
           return  medicinesDb.CreateMedicine(medicine);
        }

        public bool DeleteMedicine(long medicineId)
        {
            return medicinesDb.DeleteMedicine(medicineId);
        }

        public Medicine GetMedicine(long medicineId)
        {
            return medicinesDb.GetMedicine(medicineId);
        }

        public IEnumerable<Medicine> GetMedicines()
        {
            return medicinesDb.GetMedicines();
        }

        public bool UpdateMedicine(Medicine medicine)
        {
            return medicinesDb.UpdateMedicine(medicine);
        }
    }
}
