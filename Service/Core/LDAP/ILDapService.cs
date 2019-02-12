using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Users;

namespace Service.Core.LDAP
{
   public interface ILDapService
    {
        void SyncUsers();
        void AddUser();
        User GetUser();
    }
}
