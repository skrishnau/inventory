using IMS.Forms.Inventory.Create;
using IMS.Forms.Inventory;
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

            // ==== NOTE: use Container.RegisterSingleton<>() for registration of forms and UCs ==== //
            // --- main form --- //
            container.Register<Form1>(Lifestyle.Scoped);
            // --- inventory related --- //
            container.Register<BrandCreate>(Lifestyle.Scoped);
            container.Register<CategoryCreate>(Lifestyle.Scoped);
            container.Register<ProductCreate>(Lifestyle.Scoped);
            container.Register<InventoryUC>(Lifestyle.Scoped);
            container.Register<CategoryListUC>(Lifestyle.Scoped);
            container.Register<PurchaseOrderForm>(Lifestyle.Scoped);

            // Optionally verify the container.
            container.Verify();
        }
    }
}
