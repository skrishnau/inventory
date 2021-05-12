using IMS.Forms.Inventory;
using Service.Core.Inventory;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Windows.Forms;
using IMS.Forms.Inventory.Categories;
using IMS.Forms.Business;
using Service.Core.Business;
using Service.Core.Users;
using IMS.Forms.Sales;
using Service.Core.Settings;
using IMS.Forms.Inventory.Attributes;
using IMS.Forms.Inventory.Products;
using IMS.Forms.Inventory.Suppliers;
using IMS.Forms.POS;
using IMS.Forms.Inventory.Warehouses;
using IMS.Forms.POS.Counters;
using IMS.Forms.POS.Branches;
using IMS.Forms.Business.Create;
using IMS.Forms.Inventory.Transfers;
using Service.Listeners;
using IMS.Forms.Inventory.UOM;
using IMS.Forms.Inventory.Packages;
using IMS.Forms.Inventory.Settings.Adjustments;
using IMS.Forms.Inventory.Units.Actions;
using IMS.Forms.Inventory.Settings;
using IMS.Forms.Inventory.Units.Details;
using Service.Core.Inventory.Units;
using IMS.Forms.Inventory.Settings.General;
using IMS.Forms.Inventory.Settings.References;
//using IMS.Forms.Inventory.Sales;
using Service.Core.Orders;
using IMS.Forms.Inventory.Orders;
using IMS.Forms.Inventory.Dashboard;
using IMS.Forms.Inventory.InventoryDetail;
using Service.Core.Reports;
using Service.Interfaces;
using Service.Core;
using Service.Core.Payment;

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
            // container.Register<DatabaseContext>(Lifestyle.Singleton);
            // change listener
            container.Register<IDatabaseChangeListener, DatabaseChangeListener>(Lifestyle.Singleton);

            container.Register<IInventoryService, InventoryService>(Lifestyle.Singleton);
            container.Register<IProductService, ProductService>(Lifestyle.Singleton);
            container.Register<IInventoryUnitService, InventoryUnitService>(Lifestyle.Singleton);

            container.Register<IBusinessService, BusinessService>(Lifestyle.Singleton);
            container.Register<IUserService, UserService>(Lifestyle.Singleton);
            container.Register<IOrderService, OrderService>(Lifestyle.Singleton);
            container.Register<IPaymentService, PaymentService>(Lifestyle.Singleton);

            container.Register<ISaleService, SaleService>(Lifestyle.Singleton);
            container.Register<IReportService, ReportService>(Lifestyle.Singleton);
            //container.Register<ISaleOrderService, SaleOrderService>(Lifestyle.Singleton);

            container.Register<IAppSettingService, AppSettingService>(Lifestyle.Singleton);
            container.Register<IUomService, UomService>(Lifestyle.Singleton);

            // ==== NOTE: use Container.RegisterSingleton<>() for registration of forms and UCs ==== //
            // --- main form --- //
            container.Register<Form1>(Lifestyle.Scoped);

            // ======================= Modules registration ====================== //
            container.Register<DashboardUC>(Lifestyle.Scoped);

            container.Register<InventoryUC>(Lifestyle.Scoped);
            container.Register<InventoryMenuBar>(Lifestyle.Scoped);
            //container.Register<InventoryUnitListUC>(Lifestyle.Scoped);

            container.Register<PosUC>(Lifestyle.Scoped);
            container.Register<PosMenuBar>(Lifestyle.Scoped);
            
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

            // --- User Related --- //

            container.Register<BusinessUC>(Lifestyle.Scoped);
            container.Register<NewItemAddForm>(Lifestyle.Scoped);


            // container.Register<BranchDeleteConfirmationForm>(Lifestyle.Scoped);

            // transfers
            container.Register<InventoryTransfersListUC>(Lifestyle.Scoped);

            container.Register<WarehouseProductListUC>(Lifestyle.Scoped);

            container.Register<InventoryDisassembleForm>(Lifestyle.Scoped);
            container.Register<InventoryMergeForm>(Lifestyle.Scoped);
            container.Register<InventorySplitForm>(Lifestyle.Scoped);
            container.Register<InventoryMovementUC>(Lifestyle.Scoped);

            container.Register<InventoryAdjustmentForm>(Lifestyle.Scoped);

            container.Register<InventoryDetailUC>(Lifestyle.Scoped);


            //
            // Products
            //
            container.Register<ProductUC>(Lifestyle.Scoped);
            container.Register<ProductListUC>(Lifestyle.Scoped);
           // container.Register<ProductSidebarUC>(Lifestyle.Scoped);
            container.Register<ProductDetailUC>(Lifestyle.Scoped);
            container.Register<ProductCreateForm>(Lifestyle.Scoped);
            //
            // Warehouse
            //
            container.Register<WarehouseUC>(Lifestyle.Scoped);
            container.Register<WarehouseListUC>(Lifestyle.Scoped);
            container.Register<WarehouseSideBarUC>(Lifestyle.Scoped);
            //
            // Suppliers
            //
           // container.Register<SupplierUC>(Lifestyle.Scoped);
           container.Register<SupplierListUC>(Lifestyle.Scoped);
            container.Register<SupplierCreate>(Lifestyle.Scoped);
           // container.Register<SupplierSideBarUC>(Lifestyle.Scoped);
            // 
            // Settings
            // 
            container.Register<InventorySettingsUC>(Lifestyle.Scoped);
            container.Register<InventorySettingsSidebarUC>(Lifestyle.Scoped);
           // container.Register<CompanySettingsUC>(Lifestyle.Scoped);
            container.Register<ProfileUC>(Lifestyle.Scoped);
            container.Register<ReferenceSettingsUC>(Lifestyle.Scoped);
            //
            // Sales
            //
            //container.Register<SaleOrderListUC>(Lifestyle.Scoped);
            //container.Register<SaleOrderDetailUC>(Lifestyle.Scoped);
            //container.Register<SaleOrderCreateForm>(Lifestyle.Scoped);
            //container.Register<DirectSaleForm>(Lifestyle.Scoped);
            //
            // Orders
            //
            // container.Register<OrderUC>(Lifestyle.Scoped);
            // container.Register<OrderListUC>(Lifestyle.Scoped);
            // container.Register<OrderDetailUC>(Lifestyle.Scoped);
            container.Register<OrderCreateForm>(Lifestyle.Scoped);
            


            // Optionally verify the container.
            container.Verify();

        }
    }
}
