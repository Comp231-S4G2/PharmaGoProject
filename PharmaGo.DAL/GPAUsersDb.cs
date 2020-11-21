using PharmaGo.BOL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.DAL
{
    public interface IGPAUsersDb
    {
        IEnumerable<GPAUser> GetGPAUsers();
        GPAUser GetGPAUser(string userId);
        bool CreateGPAUser(GPAUser user);
        bool UpdateGPAUser(GPAUser user);
        bool DeleteGPAUser(string userId);
    }
    public class GPAUsersDb : IGPAUsersDb
    {
        PGADbContext dbContext;
        public GPAUsersDb(PGADbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public bool CreateGPAUser(GPAUser user)
        {
            try
            {
                dbContext.GPAUsers.Add(user);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteGPAUser(string userId)
        {
            try
            {
                var user = dbContext.GPAUsers.Find(userId);
                dbContext.Remove(user);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public GPAUser GetGPAUser(string userId)
        {
            return dbContext.GPAUsers.Find(userId);
        }

        public IEnumerable<GPAUser> GetGPAUsers()
        {
            return dbContext.GPAUsers;
        }

        public bool UpdateGPAUser(GPAUser user)
        {
            try
            {
                dbContext.Update<GPAUser>(user);
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
