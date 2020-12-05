using PharmaGo.BOL;
using PharmaGo.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.BLL
{
    public interface IGPAUsersBS
    {
        bool UpdateUser(GPAUser user);
        bool DeleteUser(GPAUser user);
        bool DeleteUser(string  userId);
        IEnumerable<GPAUser> GetGPAUsers();
    }
    public class GPAUsersBS : IGPAUsersBS
    {
        IGPAUsersDb usersDb;
        public GPAUsersBS(IGPAUsersDb _usersDb)
        {
            usersDb = _usersDb;
        }
        public bool UpdateUser(GPAUser user)
        {
           return usersDb.UpdateGPAUser(user);
        }

        public bool DeleteUser(GPAUser user)
        {
            return usersDb.DeleteGPAUser(user.Id); 
        }

        public IEnumerable<GPAUser> GetGPAUsers()
        {
            return usersDb.GetGPAUsers();
        }

        public bool DeleteUser(string userId)
        {
            return usersDb.DeleteGPAUser(userId);
        }
    }
}
