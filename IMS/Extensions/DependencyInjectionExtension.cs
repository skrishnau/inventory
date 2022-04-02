using IMS.Forms.Inventory.Dashboard;
using Service.Core.Inventory;
using Service.Core.Orders;
using Service.Core.Settings;
using Service.Interfaces;
using Service.Listeners;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS
{
    public static class DependencyInjectionExtension
    {
        public static DashboardUC GetNewInstanceOfDashboardUC (this Container container)
        {
            return new DashboardUC(
                container.GetInstance<IInventoryService>(),
                container.GetInstance<IProductService>(),
                container.GetInstance<IOrderService>(),
                container.GetInstance<IAppSettingService>(),
                container.GetInstance<IDatabaseChangeListener>()
                );
        }
    }
}
