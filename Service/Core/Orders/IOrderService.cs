﻿using System;
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

        void SaveOrder(OrderModel purchaseOrderModel);

        List<OrderModel> GetAllOrders(OrderTypeEnum orderType);

        List<OrderItemModel> GetPurchaseOrderItems(int purchaseId);
        List<InventoryUnitModel> GetInventoryUnitsOfPurchaseOrdeItems(ICollection<OrderItemModel> models);

        OrderModel GetOrder(OrderTypeEnum orderType, int orderId);
        OrderModel GetOrderForDetailView(int orderId);//OrderTypeEnum orderType, 

        string SavePurchaseOrderItems(int purchaseOrderId, List<OrderItemModel> items);
        string SavePurchaseOrderItems(int purchaseOrderId, List<InventoryUnitModel> items);

        string SetSent(int orderId);
        string SetReceived(int purchaseOrderId);
        string SetIssued(int orderId);
        string SetCancelled(int purchaseOrderId);
    }
}
