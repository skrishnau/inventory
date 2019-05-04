using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Context;
using ViewModel.Core.Orders;

namespace Service.Core.Orders
{
    public class SaleService : ISaleService
    {
       // private readonly DatabaseContext _contex;

        public SaleService()//DatabaseContext context
        {
            //_contex = context;
        }

        public void AddOrUpdateOrder(OrderModel model)
        {
            //var dbEntity = _contex.Order.FirstOrDefault(x => x.Id == model.Id);
            //if(dbEntity == null)
            //{
            //    var saleEntity = model.MapToEntity();
            //    foreach(var si in model.OrderItems)
            //    {
            //        // check sku; if variant not found then return false; if variant found then create entity object

            //    }
            //    saleEntity.CreatedAt = DateTime.Now;
            //    _contex.Orders.Add(saleEntity);
            //}
            //else
            //{
            //    dbEntity.Address = model.Address;
            //    dbEntity.CustomerName = model.CustomerName;
            //    dbEntity.Date = model.Date;
            //    dbEntity.InvoiceNo = model.BillNo;
            //    dbEntity.MobileNo = model.MobileNo;
            //    dbEntity.Total = model.TotalAmount;

            //}
            //_contex.SaveChanges();

        }

        public void AddOrUpdateOrderItem(OrderItemModel saleItemModel)
        {
            //var dbEntity = _contex.OrderItem.FirstOrDefault(x => x.Id == saleItemModel.Id);
            //if(dbEntity == null)
            //{
            //    var saleItemEntity = saleItemModel.ToEntity();

            //    _contex.OrderItem.Add(saleItemEntity);
            //}
            //else
            //{
            //    dbEntity.Quantity = saleItemModel.Quantity;
            //    dbEntity.Rate = saleItemModel.Rate;
            //    dbEntity.SKU = saleItemModel.SKU;
            //    dbEntity.TotalAmount = saleItemModel.Total;
            //}
            //_contex.SaveChanges();
        }

        public List<OrderItemModel> GetOrderItemList(int saleId)
        {
            // var saleItems = _contex.OrderItems
            //    .Where(x =>x.OrderId == saleId)
            //   . Select(x => new OrderItemModel()
            //    {
            //        Id = x.Id,
            //        ItemDescription = x.ItemDescription,
            //        Quantity = x.Quantity,
            //        Rate = x.Rate,
            //        SKU = x.SKU,
            //        Total = x.TotalAmount

            //    })

            //    .ToList();
            //return saleItems;
            return null;
        }

        public List<OrderModel> GetOrderList()
        {
            //var sales = _contex.Orders.
            //    Where(x => x.DeletedAt == null).
            //    Select(x => new OrderModel()
            //    {
            //        BillNo = x.InvoiceNo,
            //        Address = x.Address,
            //        CustomerName = x.CustomerName,
            //        Date = x.Date,
            //        Id = x.Id,
            //        MobileNo = x.MobileNo,
            //        TotalAmount = x.Total,
            //        VatNo = x.VatNo

            //    }).
            //    ToList();
            //return sales;
            return null;
        }
    }
}
