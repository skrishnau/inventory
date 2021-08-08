using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    partial class DatabaseContext
    {
        public DatabaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        // get ; TODO: call with connection string, first you need to load the connection string
        // TODO: also check if there's exception if no database found on first startup
        public static DatabaseContext Context => new DatabaseContext();
        
    }

}
