using Infrastructure.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;
using ViewModel.Core.Orders;
using ViewModel.Enums;
using ViewModel.Utility;

namespace DTO.Core.Inventory
{
    public static class OrderItemMapper
    {
        public static List<InventoryUnitModel> MapToInventoryUnitModel(ICollection<OrderItemModel> models, bool assignIdAlso = false)
        {
            var list = new List<InventoryUnitModel>();

            foreach (var model in models)
            {
                list.Add(MapToInventoryUnitModel(model, assignIdAlso));
            }

            return list;
        }

        public static InventoryUnitModel MapToInventoryUnitModel(OrderItemModel model, bool assignIdAlso = false)
        {
            return new InventoryUnitModel()
            {
                Id = assignIdAlso ? model.Id : 0,
                ProductId = model.ProductId,
                Product = model.Product,
                SKU = model.SKU,
                ExpirationDate = model.ExpirationDate,//.HasValue ? model.ExpirationDate.Value.ToShortDateString() : "",
                ProductionDate = model.ProductionDate,//.HasValue ? model.ProductionDate.Value.ToShortDateString() : "",
                LotNumber = model.LotNumber,
                IssueReceipt = null,
                IssueAdjustment = null,//model.Adjustment,
                NetWeight = model.NetWeight,
                GrossWeight = model.GrossWeight,
                UnitQuantity = model.UnitQuantity,
                Rate = model.Rate,
                Total = model.Total,
                IsHold = model.IsHold,
                SupplierId = model.SupplierId,
                Supplier = model.Supplier,
                WarehouseId = model.WarehouseId??0,
                Warehouse = model.Warehouse,
                //Uom = model.Uom,
                //UomId = model.UomId,
                IssueDate = null,//model.
                Notes = null,
                Package = model.Package,
                PackageId = model.PackageId,
                PackageQuantity = model.PackageQuantity,
                ReceiveAdjustmentCode = model.Adjustment,
                ReceiveDate = null,
                ReceiveReceipt = model.Reference,
                Remark = null,
                InStockQuantity = model.InStockQuantity,
                OnOrderQuantity = model.OnOrderQuantity,
                OnComittedQuantity = model.OnComittedQuantity,
                OnHoldQuantity = model.OnHoldQuantity,
                
            };
        }

        public static OrderItem MapToEntity(this OrderItemModel model, OrderItem entity)
        {
            if (entity == null)
                entity = new OrderItem();
            //DateTime productionDate; DateTime expireDate;
            //var prodDateParsed = DateTime.TryParse(model.ProductionDate, out productionDate);
            //var expireDateParsed = DateTime.TryParse(model.ExpirationDate, out expireDate);

            entity.Adjustment = model.Adjustment;
            entity.ExpirationDate = DateHelper.ConvertToDateTime(model.ExpirationDate);//model.ExpirationDate;
            entity.GrossWeight = model.GrossWeight;
            entity.IsHold = model.IsHold;
            entity.IsReceived = model.IsReceived;
            entity.LotNumber = model.LotNumber;
            entity.NetWeight = model.NetWeight;
            entity.PackageId = model.PackageId;
            entity.PackageQuantity = model.PackageQuantity;
            entity.ProductId = model.ProductId;
            entity.ProductionDate = DateHelper.ConvertToDateTime(model.ProductionDate);// model.ProductionDate;
            entity.OrderId = model.OrderId;
            entity.Rate = model.Rate;
            entity.Reference = model.Reference;
            entity.SupplierId = model.SupplierId == 0 ? null : model.SupplierId;
            entity.Total = model.Total;
            entity.UnitQuantity = model.UnitQuantity;
           // entity.UomId = model.UomId == 0 ? null : model.UomId;
            entity.WarehouseId = model.WarehouseId == 0 ? null : model.WarehouseId;
            return entity;
        }

        public static List<OrderItemModel> MapToOrderItemModel(IQueryable<OrderItem> query)
        {
            var list = new List<OrderItemModel>();
            foreach (var model in query)
            {
                list.Add(MapToOrderItemModel(model));
            }
            return list;
        }

        public static List<OrderItemModel> MapToOrderItemModel(this ICollection<OrderItem> query)
        {
            var list = new List<OrderItemModel>();
            foreach (var model in query)
            {
                list.Add(MapToOrderItemModel(model));
            }
            return list;
        }
        public static OrderItemModel MapToOrderItemModel(OrderItem model)
        {
            return new OrderItemModel()
            {
                Id = model.Id,
                UnitQuantity = model.UnitQuantity,
                Rate = model.Rate,
                Total = model.Total,
                Product = model.Product.Name,
                SKU = model.Product.SKU,
                IsHold = model.IsHold,
                IsReceived = model.IsReceived,
                ProductId = model.ProductId,
                OrderId = model.OrderId,
                WarehouseId = model.WarehouseId,
                Warehouse = model.Warehouse?.Name,
                InStockQuantity = model.Product.InStockQuantity,
                OnOrderQuantity = model.Product.OnOrderQuantity,
                OnHoldQuantity = model.Product.OnHoldQuantity,
               // UomId = model.UomId,
                SupplierId = model.SupplierId,
                Supplier = model.Supplier == null ? "" : model.Supplier.Name,
                Adjustment = model.Adjustment,
                ExpirationDate = DateHelper.ToFormattedDateString(model.ExpirationDate),
                GrossWeight = model.GrossWeight,
                LotNumber = model.LotNumber,
                NetWeight = model.NetWeight,
                Package = model.Package == null ? "" : model.Package.Name,
                PackageId = model.PackageId,
                PackageQuantity = model.PackageQuantity,
                ProductionDate = DateHelper.ToFormattedDateString(model.ProductionDate),
                Reference = model.Reference,
               // Uom = model.Uom == null ? "" : model.Uom.Name,
            };
        }

        public static InventoryUnitModel MapToInventoryUnitModel(this OrderItem model, OrderTypeEnum orderType)
        {
            return new InventoryUnitModel()
            {
                Id = model.Id,
                UnitQuantity = model.UnitQuantity,
                //Rate = model.Rate,
                //TotalAmount = model.TotalAmount,
                Product = model.Product?.Name ?? "",
                SKU = model.Product?.SKU ?? "",
                IsHold = model.IsHold,
                // IsReceived = model.IsReceived,
                ProductId = model.ProductId,
                // PurchaseOrderId = model.PurchaseOrderId,
                WarehouseId = model.WarehouseId ?? 0,
                Warehouse = model.Warehouse?.Name ?? "",
                //  InStock = model.Product.InStockQuantity,
                // OnOrder = model.Product.OnOrderQuantity,
               // UomId = model.UomId,
                SupplierId = model.SupplierId,
                Supplier = model.Supplier?.Name ?? "",
                // Adjustment = model.Adjustment,
                //  ExpirationDate = model.ExpirationDate,
                GrossWeight = model.GrossWeight,
                LotNumber = model.LotNumber,
                NetWeight = model.NetWeight,
                Package = model.Package?.Name ?? "",
                PackageId = model.PackageId,
                PackageQuantity = model.PackageQuantity,
                //  ProductionDate = model.ProductionDate,
                // Reference = model.Reference,
                //Uom = model.Uom?.Name ?? "",
                Rate = orderType == OrderTypeEnum.Sale? (model.CostPriceRate ?? 0): model.Rate,


            };
        }

        public static List<InventoryUnitModel> MapToInventoryUnitModel(this ICollection<OrderItem> query, OrderTypeEnum orderType)
        {
            var list = new List<InventoryUnitModel>();
            foreach (var model in query)
            {
                list.Add(MapToInventoryUnitModel(model, orderType));
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