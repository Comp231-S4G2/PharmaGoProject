using Microsoft.EntityFrameworkCore;
using PharmaGo.BOL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.DAL
{
    public interface ICustomerPrescriptionDb
    {
        IEnumerable<CustomerPrescription> GetCustomerPrescriptions();
        bool SavePrescription(CustomerPrescription prescription);
    }
    public class CustomerPrescriptionDb : ICustomerPrescriptionDb
    {
        PGADbContext dbContext;
        public CustomerPrescriptionDb(PGADbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public IEnumerable<CustomerPrescription> GetCustomerPrescriptions()
        {
            return dbContext.CustomerPrescriptions.Include(x=>x.user);
        }

        public bool SavePrescription(CustomerPrescription prescription)
        {
            try
            {
                dbContext.CustomerPrescriptions.Add(prescription);
                dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}
