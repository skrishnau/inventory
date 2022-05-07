using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Utility;

namespace DTO
{
    public static class ApplicationSettingsMapper
    {
        public static DatabaseConnectionModel ToDatabaseConnectionModel(this ApplicationSettingsModel applicationSettings)
        {
            return new DatabaseConnectionModel
            {
                DatabaseName = applicationSettings.DatabaseDatabase,
                Password = applicationSettings.DatabasePassword,
                ServerName = applicationSettings.DatabaseServer,
                Username = applicationSettings.DatabaseUsername,
            };
        }
    }
}
