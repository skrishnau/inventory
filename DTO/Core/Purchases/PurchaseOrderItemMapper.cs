using Infrastructure.Entities.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Purchases;

namespace DTO.Core.Purchases
{
    public static class PurchaseOrderItemMapper
    {

        public static PurchaseOrderItem MapToEntity(PurchaseOrderItemModel model, PurchaseOrderItem entity)
        {
            if (entity == null)
                entity = new PurchaseOrderItem();

            entity.ProductId = model.ProductId;
            entity.PurchaseOrderId = model.PurchaseOrderId;
            entity.Quantity = model.Quantity;
            entity.Rate = model.Rate;
            entity.TotalAmount = model.TotalAmount;
            entity.IsReceived = model.IsReceived;
            entity.IsHold = model.IsHold;
            entity.WarehouseId = model.WarehouseId;
            return entity;
        }

        public static List<PurchaseOrderItemModel> MapToPurhaseOrderItemModel(IQueryable<PurchaseOrderItem> query)
        {
            var list = new List<PurchaseOrderItemModel>();
            foreach(var model in query)
            {
                list.Add(new PurchaseOrderItemModel()
                {
                    Id = model.Id,
                    Quantity = model.Quantity,
                    Rate = model.Rate,
                    TotalAmount = model.TotalAmount,
                    Product = model.Product.Name,
                    SKU = model.Product.SKU,
                    IsHold = model.IsHold,
                    IsReceived = model.IsReceived,
                    ProductId = model.ProductId,
                    PurchaseOrderId = model.PurchaseOrderId,
                    WarehouseId = model.WarehouseId,
                    Warehouse = model.Warehouse.Name,
                    InStock = model.Product.InStockQuantity,
                    OnOrder = model.Product.OnOrderQuantity,
                });
            }
            return list;
        }

    }
}


//public static List<PurchaseOrderItem> MapToEntity(ICollection<PurchaseOrderItemModel> models)
//{
//    var list = new List<PurchaseOrderItem>();
//    foreach(var model in models)
//    {
//        list.Add(new PurchaseOrderItem()
//        {
//            Id = model.Id,
//            PurchaseOrderId = model.PurchaseOrderId,
//            Quantity = model.Quantity,
//            Rate = model.Rate,
//            TotalAmount = model.TotalAmount,
//            ProductId = model.ProductId,
//        });
//    }
//    return list;
//}