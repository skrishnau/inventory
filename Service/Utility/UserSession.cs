using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Users;

namespace Service
{
    public class UserSession
    {
        public static UserModel User { get; set; }

        // db connection
        public static string Database { get; set; }

    }
}
