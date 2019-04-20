﻿using IMS.Forms.Inventory.Create;
using IMS.Forms.Inventory;
using Infrastructure.Context;
using Service.Core.Inventory;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Windows.Forms;
using IMS.Forms.Inventory.Categories;
using IMS.Forms.Purchases;
using Service.Core.LDAP;
using Service.Core.Suppliers;
using Service.Core.Customers;
using IMS.Forms.Business;
using Service.Core.Business;
using IMS.Forms.Users.Create;
using Service.Core.Users;
using Service.Core.Purchases.PurchaseOrders;
using IMS.Forms.Sales;
using Service.Core.Sales;
using IMS.Forms.Settings;
using Service.Core.Settings;
using IMS.Forms.Dashboard;
using IMS.Forms.Inventory.Attributes;
using IMS.Forms.Inventory.Products;
using IMS.Forms.Inventory.Suppliers;
using IMS.Forms.POS;
using IMS.Forms.POS.Customers;
using IMS.Forms.Inventory.Warehouses;
using IMS.Forms.POS.Counters;
using IMS.Forms.Generals;
using IMS.Forms.POS.Branches;
using IMS.Forms.Business.Create;
using IMS.Forms.UserManagement;
using IMS.Forms.UserManagement.Users;
using IMS.Forms.Orders;
using IMS.Forms.Inventory.Transfers;
using Service.Listeners;
using IMS.Forms.Inventory.UOM;
using IMS.Forms.Inventory.Packages;
using IMS.Forms.Inventory.Settings.Adjustments;
using IMS.Forms.Inventory.Purchases;
using IMS.Forms.Inventory.Purchases.Order;
using IMS.Forms.Inventory.Products.WarehouseProducts;
using IMS.Forms.Inventory.Units.Actions;
using IMS.Forms.Inventory.Settings;

namespace IMS
{
    static class Program
    {
        // simpleInjector's container
        public static Container container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            //Application.Run(new Form1());
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                Application.Run(container.GetInstance<Form1>());
            }

        }

        private static void Bootstrap()
        {
            // Create the container as usual.
            container = new Container();

            // Set the scoped lifestyle one directly after creating the container
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance:
            // Note: It is not possible to use Constructor Injection in User Controls. 
            // User Controls are required to have a default constructor. 
            // Instead, pass on dependencies to your User Controls using Method Injection.
            // e.g.
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Singleton);
            // container.Register<IUserContext, WinFormsUserContext>();
            container.Register<DatabaseContext>(Lifestyle.Singleton);
            // change listener
            container.Register<IDatabaseChangeListener, DatabaseChangeListener>(Lifestyle.Singleton);

            container.Register<IInventoryService, InventoryService>(Lifestyle.Singleton);
            container.Register<ILDapService, ActiveDirectory>(Lifestyle.Singleton);

            container.Register<ISupplierService, SupplierService>(Lifestyle.Singleton);
            container.Register<ICustomerService, CustomerService>(Lifestyle.Singleton);

            container.Register<IBusinessService, BusinessService>(Lifestyle.Singleton);
            container.Register<IUserService, UserService>(Lifestyle.Singleton);
            container.Register<IPurchaseService, PurchaseService>(Lifestyle.Singleton);

            container.Register<ISaleService, SaleService>(Lifestyle.Singleton);

            container.Register<IAppSettingService, AppSettingService>(Lifestyle.Singleton);

            // ==== NOTE: use Container.RegisterSingleton<>() for registration of forms and UCs ==== //
            // --- main form --- //
            container.Register<Form1>(Lifestyle.Scoped);

            // ======================= Modules registration ====================== //
            container.Register<GeneralUC>(Lifestyle.Scoped);
            container.Register<GeneralMenuBar>(Lifestyle.Scoped);

            container.Register<DashboardUC>(Lifestyle.Scoped);
            container.Register<DashboardMenuBar>(Lifestyle.Scoped);

            container.Register<InventoryUC>(Lifestyle.Scoped);
            container.Register<InventoryMenuBar>(Lifestyle.Scoped);

            container.Register<OrdersUC>(Lifestyle.Scoped);
            container.Register<OrdersMenuBar>(Lifestyle.Scoped);

            container.Register<PosUC>(Lifestyle.Scoped);
            container.Register<PosMenuBar>(Lifestyle.Scoped);

            container.Register<UserManagementUC>(Lifestyle.Scoped);
            container.Register<UserManagementMenuBar>(Lifestyle.Scoped);

            // --- General Related --- //
           
            container.Register<CategoryListUC>(Lifestyle.Scoped);
            container.Register<CategoryCreate>(Lifestyle.Scoped);
            container.Register<AttributeListUC>(Lifestyle.Scoped);
            container.Register<BranchListUC>(Lifestyle.Scoped);
            container.Register<BranchCreate>(Lifestyle.Scoped);

            // --- inventory related --- //
            

            container.Register<UomUC>(Lifestyle.Scoped);
            container.Register<PackageUC>(Lifestyle.Scoped);
            container.Register<AdjustmentCodeUC>(Lifestyle.Scoped);

            // --- POS related --- //
            container.Register<CounterListUC>(Lifestyle.Scoped);
            container.Register<DirectSaleForm>(Lifestyle.Scoped);

            // --- User Related --- //
            container.Register<UserListUC>(Lifestyle.Scoped);

            container.Register<BrandCreate>(Lifestyle.Scoped);
            container.Register<CustomerListUC>(Lifestyle.Scoped);
            container.Register<BusinessUC>(Lifestyle.Scoped);
            container.Register<UserCreate>(Lifestyle.Scoped);
            container.Register<NewItemAddForm>(Lifestyle.Scoped);
            container.Register<SaleUC>(Lifestyle.Scoped);
            container.Register<SettingsForm>(Lifestyle.Scoped);

           // container.Register<BranchDeleteConfirmationForm>(Lifestyle.Scoped);

            // transfers
            container.Register<InventoryTransfersListUC>(Lifestyle.Scoped);
            container.Register<TransferForm>(Lifestyle.Scoped);

            container.Register<WarehouseProductListUC>(Lifestyle.Scoped);

            container.Register<InventoryDisassembleForm>(Lifestyle.Scoped);
            container.Register<InventoryMergeForm>(Lifestyle.Scoped);
            container.Register<InventorySplitForm>(Lifestyle.Scoped);

            container.Register<InventoryMoveForm>(Lifestyle.Scoped);
            container.Register<InventoryAdjustmentForm>(Lifestyle.Scoped);
            container.Register<InventorySettingsUC>(Lifestyle.Scoped);
            //
            // Purchases
            //
            container.Register<PurchaseOrderUC>(Lifestyle.Scoped); // main
            container.Register<PurchaseOrderListUC>(Lifestyle.Scoped);
            container.Register<PurchaseOrderDetailUC>(Lifestyle.Scoped);
            container.Register<PurchaseOrderCreateForm>(Lifestyle.Scoped);
            container.Register<PurchaseOrderItemCreateForm>(Lifestyle.Scoped);
            //
            // Products
            //
            container.Register<ProductUC>(Lifestyle.Scoped);
            container.Register<ProductListUC>(Lifestyle.Scoped);
            container.Register<ProductDetailUC>(Lifestyle.Scoped);
            container.Register<ProductCreate>(Lifestyle.Scoped);
            //
            // Warehouse
            //
            container.Register<WarehouseUC>(Lifestyle.Scoped);
            container.Register<WarehouseListUC>(Lifestyle.Scoped);
            container.Register<WarehouseSideBarUC>(Lifestyle.Scoped);
            //
            // Suppliers
            //
            container.Register<SupplierUC>(Lifestyle.Scoped);
            container.Register<SupplierListUC>(Lifestyle.Scoped);
            container.Register<SupplierDetailUC>(Lifestyle.Scoped);
            container.Register<SupplierCreate>(Lifestyle.Scoped);
            container.Register<SupplierSideBarUC>(Lifestyle.Scoped);


            // Optionally verify the container.
            container.Verify();
        }
    }
}
