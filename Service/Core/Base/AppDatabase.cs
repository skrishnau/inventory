using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Base
{
    public class AppDatabase
    {
        private static DatabaseContext context;
        static AppDatabase()
        {
            if (context == null)
                context = new DatabaseContext();
        }


    }
}
