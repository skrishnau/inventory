using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core;
using ViewModel.Core.Inventory;
using ViewModel.Core.Orders;
using ViewModel.Enums;

namespace Service.Core.Orders
{
    public interface IOrderService
    {
        int GetNextLotNumber();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseOrderModel"></param>
        /// <param name="checkout">The order is processed and receipt generated at the same time</param>
        ResponseModel<OrderModel> SaveOrder(OrderModel purchaseOrderModel, bool checkout);
       

        int GetAllOrdersCount(OrderTypeEnum orderType, OrderListTypeEnum orderListType, string userSearch, string _searchReceiptNo);
        OrderListModel GetAllOrders(OrderTypeEnum orderType, OrderListTypeEnum orderListType, string userSearch, string receiptNoSearch, int pageSize, int offset);

        List<OrderItemModel> GetPurchaseOrderItems(int purchaseId);
        List<InventoryUnitModel> GetInventoryUnitsOfPurchaseOrdeItems(ICollection<OrderItemModel> models);

        OrderModel GetOrder(OrderTypeEnum orderType, int orderId);
        OrderModel GetOrderForDetailView(int orderId, bool withProductModel = false);//OrderTypeEnum orderType, 

        string SavePurchaseOrderItems(int purchaseOrderId, List<OrderItemModel> items);
        string SavePurchaseOrderItems(int purchaseOrderId, List<InventoryUnitModel> items);
        /*
        string SetSent(int orderId);
        string SetReceived(int purchaseOrderId);
        string SetIssued(int orderId);
        */
        string SetCancelled(int purchaseOrderId);
        List<DueAmountModel> GetDueReceivables();
        List<SalePurchaseAmountModel> GetSalePurchaseAmountForBarDiagram(DateTime from, DateTime to);
    }
}
