using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
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
        public static string EDMXConnectionString { get; set; }
        public static string CodeFirstConnectionString { get; set; }
        // get ; TODO: call with connection string, first you need to load the connection string
        // TODO: also check if there's exception if no database found on first startup
        
        public static DatabaseContext Context => new DatabaseContext(GetEDMXConnectionString(EDMXConnectionString)); // new DatabaseContext();
        
        public static string GetEDMXConnectionString(string rawEDMXConnectionString)
        {
            var originalConnectionString = rawEDMXConnectionString.Replace("&quot;", "\"");//System.Configuration.ConfigurationManager.ConnectionStrings["CSName"].ConnectionString;
            var ecsBuilder = new EntityConnectionStringBuilder(originalConnectionString);
            var sqlCsBuilder = new SqlConnectionStringBuilder(ecsBuilder.ProviderConnectionString)
            ;
            var providerConnectionString = sqlCsBuilder.ToString();
            ecsBuilder.ProviderConnectionString = providerConnectionString;

            string contextConnectionString = ecsBuilder.ToString();
            return contextConnectionString;
        }
    }

}
