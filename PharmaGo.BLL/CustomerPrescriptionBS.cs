using PharmaGo.BOL;
using PharmaGo.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.BLL
{
    public interface ICustomerPrescriptionBS
    {
        IEnumerable<CustomerPrescription> GetCustomerPrescriptions();
        IEnumerable<MedDemand> GetCustomerPrescriptionMedDemands(long prescriptionId);
        bool SavePrescription(CustomerPrescription prescription);
        bool SavePrescriptionMedicine(CustomerPrescription prescription, MedDemand medDemand);
    }
    public class CustomerPrescriptionBS : ICustomerPrescriptionBS
    {
        ICustomerPrescriptionDb customerPrescriptionDb;
        IMedDemandDb MedDemandDb;
        public CustomerPrescriptionBS(ICustomerPrescriptionDb _customerPrescriptionDb, IMedDemandDb _MedDemandDb)
        {
            customerPrescriptionDb = _customerPrescriptionDb;
            MedDemandDb = _MedDemandDb;
        }

        public IEnumerable<MedDemand> GetCustomerPrescriptionMedDemands(long prescriptionId)
        {
           return MedDemandDb.GetMedDemandsByPrescription(prescriptionId);
        }

        public IEnumerable<CustomerPrescription> GetCustomerPrescriptions()
        {
            return customerPrescriptionDb.GetCustomerPrescriptions();
        }

        public bool SavePrescription(CustomerPrescription prescription)
        {
            return customerPrescriptionDb.SavePrescription(prescription);

        }

        public bool SavePrescriptionMedicine(CustomerPrescription prescription, MedDemand medDemand)
        {
            try
            {
                var result=MedDemandDb.AddMedDemand(medDemand);
                if (prescription.MedDemands == null)
                    prescription.MedDemands = new List<MedDemand>();
                prescription.MedDemands.Add(medDemand);
                return result;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
