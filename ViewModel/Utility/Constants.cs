using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Enums;

namespace ViewModel.Utility
{
    public static class Constants
    {
        public const string DATABASE_NAME = "IMS";
        public const string GROUP_BACKUP = "Backup";
        public const string KEY_BACKUP_FOLDER_PATH = "BackupFolderPath";



        public const bool IS_TRIAL = true;
        public const bool HAS_STOCK_MANAGEMENT = true;
        // later convert it to appsettings and give on/off feature to user
        public const bool LEDGER_DISPLAY_TRANSACTION_ITEMS_ALSO = true;
        public const bool CAN_NEW_PRODUCT_BE_ADDED_FROM_TRANSACTION = false;
        public const bool CAN_NEW_PACKAGE_BE_ADDED_FROM_TRANSACTION = false;



        public const string REQUIRED = "Required";
        public const string INVALID = "Invalid";
        public const string GREATER_THAN_ZERO = "Should be greater than zero";
        public const string NOT_AVAILABLE_IN_PRODUCT_UOM = "Not available in Product's UOM";
        public const string RECEIPT_NO_IS_REQUIRED = "Receipt No. is required. Please update Receipt settings.";

    }
}
