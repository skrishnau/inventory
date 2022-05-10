using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Utility
{
    public class ConfigKeyValue
    {
        public ApplicationSettingsEnum Key { get; set; }
        public string Value { get; set; }
        public string ConvertToPlainText()
        {
            return Key.ToString() + " = " + Value;
        }
    }
    public class ApplicationSettingsModel
    {
        public string DatabaseServer { get; set; }
        public string DatabaseDatabase { get; set; }
        public string DatabaseUsername { get; set; }
        public string DatabasePassword { get; set; }

        public static ConfigKeyValue TrimAndGetSettingsKeyAndValue(string l)
        {
            if (string.IsNullOrEmpty(l))
                return null;
            var trimmed = l.Trim();
            if (trimmed.StartsWith("#"))
                return null;
            var split = trimmed.Split(new char[] { '=' });
            if (split.Length < 2)
                return null;
            if (!Enum.TryParse<ApplicationSettingsEnum>(split[0], out ApplicationSettingsEnum settingEnum))
                return null;
            var settingValue = string.Join("=", split.Skip(1)).Trim(); // the value at split[0] is the key
            return new ConfigKeyValue { Key = settingEnum, Value = settingValue };
        }
    }

    public enum ApplicationSettingsEnum
    {
        DB_Server,
        DB_Database,
        DB_Username,
        DB_Password
    }

    public class ConnectionStrings
    {
        public string EDMXConnectionString { get; set; }
        public string CodeFirstConnectionString { get; set; }
    }
    public class DatabaseConnectionModel
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ConnectionStrings GetConnectionString()//string ServerName, string DatabaseName, string Username, string Password
        {
            if (!string.IsNullOrEmpty(DatabaseName) && !string.IsNullOrEmpty(ServerName))
            {
                //DESKTOP-AK7BNHA\\SQLEXPRESS;;; IMS
                // create connection string and store it in UserSession
                var connectionString = new ConnectionStrings();
                var edmx = "metadata=res://*/Context.DatabaseContext.csdl|res://*/Context.DatabaseContext.ssdl|res://*/Context.DatabaseContext.msl;provider=System.Data.SqlClient;provider connection string=&quot;" +
                    $"data source={ServerName};initial catalog={DatabaseName};User ID={Username};Password={Password};integrated security=False;MultipleActiveResultSets=True;App=EntityFramework&quot;";
                connectionString.EDMXConnectionString = GetEDMXConnectionString(edmx);
                //DESKTOP-AK7BNHA\SQLEXPRESS
                connectionString.CodeFirstConnectionString = $"data source={ServerName};initial catalog={DatabaseName};User ID={Username};Password={Password};integrated security=False;MultipleActiveResultSets=True;App=EntityFramework";
                return connectionString;
            }
            return null;
        }

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
