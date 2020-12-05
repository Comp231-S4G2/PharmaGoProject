using PharmaGo.BOL;
using PharmaGo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmaGo.BLL
{
    public interface ICustomerMedReserveBS
    {
        IEnumerable<CustomerMedReserve> GetCustomerMedReserves();
        IEnumerable<CustomerMedReserve> GetCustomerMedReservesByStockMedId(long id);
        bool AddCustomerMedReserve(CustomerMedReserve customerMedReserve);
        bool DeleteCustomerMedReserve(long id);
    }

    public class CustomerMedReserveBS : ICustomerMedReserveBS
    {
        private ICustomerMedReserveDb customerMedReserveDb;
        public CustomerMedReserveBS(ICustomerMedReserveDb _customerMedReserveDb)
        {
            customerMedReserveDb = _customerMedReserveDb;
        }
        public bool AddCustomerMedReserve(CustomerMedReserve customerMedReserve)
        {
            return customerMedReserveDb.AddCustomerMedReserve(customerMedReserve);
        }

        public bool DeleteCustomerMedReserve(long id)
        {
            return customerMedReserveDb.DeleteCustomerMedReserve(id);
        }

        public IEnumerable<CustomerMedReserve> GetCustomerMedReserves()
        {
            return customerMedReserveDb.GetCustomerMedReserves();
        }

        public IEnumerable<CustomerMedReserve> GetCustomerMedReservesByStockMedId(long id)
        {
            return GetCustomerMedReserves().Where(x=>x.StockMedicineId==id);
        }
    }
}
