using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Users;

namespace Service.Core.LDAP
{
   public class ActiveDirectory : ILDapService
    {
        public void AddUser()
        {
           // throw new NotImplementedException();
        }

        public User GetUser()
        {
            return null;
           // throw new NotImplementedException();
        }

        public void SyncUsers()
        {
            throw new NotImplementedException();
        }
    }
}
