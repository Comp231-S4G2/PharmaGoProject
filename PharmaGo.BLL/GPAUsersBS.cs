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
    }
}
