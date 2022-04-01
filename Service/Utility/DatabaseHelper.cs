using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Utility;

namespace Service.Utility
{
    public static class DatabaseHelper
    {
        public static ConnectionStrings GetConnectionString(string serverName, string databaseName)
        {

            if (!string.IsNullOrEmpty(databaseName) && !string.IsNullOrEmpty(serverName))
            {
                //DESKTOP-AK7BNHA\\SQLEXPRESS;;; IMS
                // create connection string and store it in UserSession
                var connectionString = new ConnectionStrings();
                connectionString.EDMXConnectionString = "metadata=res://*/Context.DatabaseContext.csdl|res://*/Context.DatabaseContext.ssdl|res://*/Context.DatabaseContext.msl;provider=System.Data.SqlClient;provider connection string=&quot;" +
                    $"data source={serverName};initial catalog={databaseName};integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
                //DESKTOP-AK7BNHA\SQLEXPRESS
                connectionString.CodeFirstConnectionString = $"data source={serverName};initial catalog={databaseName};integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
                return connectionString;
            }
            return null;
        }
        public static bool TestDatabaseConnection(ConnectionStrings connectionStrings)
        {
            try
            {
                using (var _context = new DatabaseContext(DatabaseContext.GetEDMXConnectionString(connectionStrings.EDMXConnectionString)))
                {
                    return _context.Database.Exists();
                }
            }
            catch (Exception ex) { return false; }
        }
    }
}
