using Infrastructure.Context;
using ViewModel.Core;
using ViewModel.Utility;

namespace Service
{
    public class UserSession
    {
        public static UserModel User { get; set; }
        public static bool IsTrial { get; set; } = false;



        public static void Logout()
        {
            if (User != null)
                User = null;
        }
        public static bool IsLoggedIn()
        {
            return User != null;
        }
        private static DatabaseConnectionModel _databaseConnectionModel;
        public static DatabaseConnectionModel DatabaseConnectionModel
        {
            get { return _databaseConnectionModel; }
            set
            {
                _databaseConnectionModel = value;
                if (value != null && value.ServerName != null && value.DatabaseName != null && value.Password != null && value.Username != null)
                {
                    var connStr = value.GetConnectionString();
                    if (connStr != null)
                    {
                        DatabaseContext.EDMXConnectionString = connStr.EDMXConnectionString;
                        DatabaseContext.CodeFirstConnectionString = connStr.CodeFirstConnectionString;
                    }
                }
            }
        }
        /*
        private static ConnectionStrings _connectionStrings;
        // db connection
        private static ConnectionStrings ConnectionStrings
        {
            get { return _connectionStrings; }
            set
            {
                if(value != null)
                {
                    DatabaseContext.EDMXConnectionString = value.EDMXConnectionString;
                    DatabaseContext.CodeFirstConnectionString = value.CodeFirstConnectionString;
                }
                _connectionStrings = value;
            }
        }*/

    }
}
