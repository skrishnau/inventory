using Infrastructure.Context;
using ViewModel.Core;
using ViewModel.Utility;

namespace Service
{
    public class UserSession
    {
        public static UserModel User { get; set; }

        private static ConnectionStrings _connectionStrings;
        // db connection
        public static ConnectionStrings ConnectionStrings
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
        }

    }
}
