using IMS.Forms.Inventory.Create;
using IMS.Forms.Inventory;
using IMS.Forms.Customer;
using Infrastructure.Context;
using Service.Core.Inventory;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Inventory.Lists;
using IMS.Forms.Inventory.Lists.Category;
using IMS.Forms.Purchases;
using IMS.Forms.Suppliers;
using Service.Core.LDAP;
using Service.Core.Suppliers;
using Service.Core.Customers;
using IMS.Forms.Business;
using Service.Core.Business;
using IMS.Forms.Users;
using IMS.Forms.Users.Create;
using Service.Core.Users;
using Service.Core.Purchases.PurchaseOrders;
using IMS.Forms.Sales;
using Service.Core.Sales;

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
            container.Register<IInventoryService, InventoryService>(Lifestyle.Singleton);
            container.Register<ILDapService, ActiveDirectory>(Lifestyle.Singleton);

            container.Register<ISupplierService, SupplierService>(Lifestyle.Singleton);
            container.Register<ICustomerService, CustomerService>(Lifestyle.Singleton);

            container.Register<IBusinessService, BusinessService>(Lifestyle.Singleton);
            container.Register<IUserService, UserService>(Lifestyle.Singleton);
            container.Register<IPurchaseService, PurchaseService>(Lifestyle.Singleton);

            container.Register<ISaleService, SaleService>(Lifestyle.Singleton);

            // ==== NOTE: use Container.RegisterSingleton<>() for registration of forms and UCs ==== //
            // --- main form --- //
            container.Register<Form1>(Lifestyle.Scoped);
            // --- inventory related --- //
            container.Register<BrandCreate>(Lifestyle.Scoped);
            container.Register<CategoryCreate>(Lifestyle.Scoped);
            container.Register<ProductCreate>(Lifestyle.Scoped);
            container.Register<InventoryUC>(Lifestyle.Scoped);
            container.Register<SupplierUC>(Lifestyle.Scoped);
            container.Register<CategoryListUC>(Lifestyle.Scoped);
            container.Register<PurchaseOrderForm>(Lifestyle.Scoped);
            container.Register<CustomerUC>(Lifestyle.Scoped);
            container.Register<BusinessUC>(Lifestyle.Scoped);
            container.Register<UserUC>(Lifestyle.Scoped);
            container.Register<UserCreate>(Lifestyle.Scoped);
            container.Register<DirectSaleForm>(Lifestyle.Scoped);
            container.Register<NewItemAddForm>(Lifestyle.Scoped);
            container.Register<SaleUC>(Lifestyle.Scoped);
            





            container.Register<PurchaseListUC>(Lifestyle.Scoped);
            
            // Optionally verify the container.
            container.Verify();
        }
    }
}
