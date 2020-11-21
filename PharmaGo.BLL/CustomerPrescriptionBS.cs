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
        bool SavePrescription(CustomerPrescription prescription);
    }
    public class CustomerPrescriptionBS : ICustomerPrescriptionBS
    {
        ICustomerPrescriptionDb customerPrescriptionDb;
        public CustomerPrescriptionBS(ICustomerPrescriptionDb _customerPrescriptionDb)
        {
            customerPrescriptionDb = _customerPrescriptionDb;
        }
        public IEnumerable<CustomerPrescription> GetCustomerPrescriptions()
        {
            return customerPrescriptionDb.GetCustomerPrescriptions();
        }

        public bool SavePrescription(CustomerPrescription prescription)
        {
            return customerPrescriptionDb.SavePrescription(prescription);

        }
    }
}
