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
        public const string DATABASE_CONFIG_FILENAME = "imsconfig.config";
        public const string DATABASE_NAME = "IMS";
        public const string GROUP_BACKUP = "Backup";
        public const string GROUP_SYSTEM = "System";

        public const string KEY_BACKUP_FOLDER_PATH = "BackupFolderPath";
        public const string KEY_SHOW_TRANSACTION_CREATE_IN_FULL_PAGE = "show_transaction_create_in_full_page";
        public const string KEY_IS_TRANSACTION_CRETE_PAGE_LOCKED = "is_transaction_create_page_locked";
        public const string DISPLAY_IS_TRANSACTION_CRETE_PAGE_LOCKED = "Is Transaction Create Page Locked";

        // region: for Bibek Client Kalimati
        public const bool IS_TRIAL = false;
        public const bool HAS_STOCK_MANAGEMENT = true;
        // later convert it to appsettings and give on/off feature to user
        public const bool LEDGER_DISPLAY_TRANSACTION_ITEMS_ALSO = true;
        public const bool CAN_NEW_PRODUCT_BE_ADDED_FROM_TRANSACTION = false;
        public const bool CAN_NEW_PACKAGE_BE_ADDED_FROM_TRANSACTION = false;
        
        // endregion: for Bibek Client Kalimati



        public const string REQUIRED = "Required";
        public const string INVALID = "Invalid";
        public const string GREATER_THAN_ZERO = "Should be greater than zero";
        public const string NOT_AVAILABLE_IN_PRODUCT_UOM = "Not available in Product's UOM";
        public const string RECEIPT_NO_IS_REQUIRED = "Receipt No. is required. Please update Receipt settings.";


        public const string TAB_DASHBOARD = "Dashboard";
        public const string TAB_PURCHASES = "Purchases";
        public const string TAB_SALES = "Sales";
        public const string TAB_TRANSFERS = "Transfers";
        public const string TAB_CLIENTS = "Clients";
        public const string TAB_INVENTORY_UNITS = "Inventory Units";
        public const string TAB_POS = "POS";
        public const string TAB_PRODUCTS = "Products";
        public const string TAB_TRANSACTIONS = "Transactions";
        public const string TAB_ORDERS = "Orders";
        public const string TAB_SETTINGS = "Settings";
        public const string TAB_REPORTS = "Reports";
        public const string TAB_ACCOUNTS = "Accounts";
        public const string TAB_MANUFACTURE = "Manufacture";

        public const string NAME_INVENTORY_MANAGE = "Inventory Manage";
        public const string NAME_RATE_LIST = "Rate List";
        public const string NAME_INVENTORY_MOVEMENT = "Inventory Movement";
        public const string NAME_PROFIT_AND_LOSS = "Profit and Loss";
        public const string NAME_LEDGER = "Ledger";
        public const string NAME_PRODUCT_LEDGER = "Product Ledger";
        public const string NAME_PAYMENT_LIST = "Payment List";

        public const string YES = "Yes";
        public const string NO = "No";

        public const string ADMIN_USERNAME = "admin";
        public const string ADMIN_NAME = "Administrator";

        public const string CONFIG_DATABASE = "database";

        public const string KEY_MANUFACTURE_LOT_NO_START_FROM = "manufacture_lot_no_start_from";
        public const string SAVED_SUCCESSFULLY = "Saved Successfully!";
    }
}
