using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;
using ViewModel.Core.Orders;
using ViewModel.Enums;

namespace Service.Core.Orders
{
    public interface IOrderService
    {
        int GetNextLotNumber();

        void SavePurchaseOrder(OrderModel purchaseOrderModel);

        List<OrderModel> GetAllOrders(OrderTypeEnum orderType);

        List<OrderItemModel> GetPurchaseOrderItems(int purchaseId);
        List<InventoryUnitModel> GetInventoryUnitsOfPurchaseOrdeItems(ICollection<OrderItemModel> models);

        OrderModel GetOrder(OrderTypeEnum orderType, int orderId);


        string SavePurchaseOrderItems(int purchaseOrderId, List<OrderItemModel> items);

        string SetSent(int purchaseOrderId);
        string SetReceived(int purchaseOrderId);
        string SetCancelled(int purchaseOrderId);
    }
}
