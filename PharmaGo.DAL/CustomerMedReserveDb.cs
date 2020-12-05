using PharmaGo.BOL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.DAL
{
    public interface ICustomerMedReserveDb
    {
        IEnumerable<CustomerMedReserve> GetCustomerMedReserves();
        bool AddCustomerMedReserve(CustomerMedReserve customerMedReserve);
        bool DeleteCustomerMedReserve(long id);
    }
    public class CustomerMedReserveDb : ICustomerMedReserveDb
    {
        PGADbContext dbContext;
        public CustomerMedReserveDb(PGADbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public bool AddCustomerMedReserve(CustomerMedReserve customerMedReserve)
        {
            try
            {
                dbContext.CustomerMedReserves.Add(customerMedReserve);
                dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public bool DeleteCustomerMedReserve(long id)
        {
            try
            {
                var result=dbContext.CustomerMedReserves.Find(id);
                dbContext.CustomerMedReserves.Remove(result);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<CustomerMedReserve> GetCustomerMedReserves()
        {
            return dbContext.CustomerMedReserves;
        }
    }
}
