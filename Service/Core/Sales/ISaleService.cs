using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Orders;

namespace Service.Core.Orders
{
    public interface ISaleService
    {
        void AddOrUpdateOrder(OrderModel saleModel);

        void AddOrUpdateOrderItem(OrderItemModel saleItemModel);

        List<OrderModel> GetOrderList();

        List<OrderItemModel> GetOrderItemList(int saleId);

    }
}
