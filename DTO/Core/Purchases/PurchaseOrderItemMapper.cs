using Infrastructure.Entities.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;
using ViewModel.Core.Purchases;

namespace DTO.Core.Purchases
{
    public static class PurchaseOrderItemMapper
    {
        public static List<InventoryUnitModel> MapToInventoryUnitModel(ICollection<PurchaseOrderItemModel> models)
        {
            var list = new List<InventoryUnitModel>();

            foreach (var model in models)
            {
                list.Add(MapToInventoryUnitModel(model));
            }

            return list;
        }

        public static InventoryUnitModel MapToInventoryUnitModel(PurchaseOrderItemModel model)
        {
            return new InventoryUnitModel()
            {
                Id = 0,
                ProductId = model.ProductId,
                Product = model.Product,
                SKU = model.SKU,
                ExpirationDate = model.ExpirationDate.HasValue ? model.ExpirationDate.Value.ToShortDateString() : "",
                ProductionDate = model.ProductionDate.HasValue ? model.ProductionDate.Value.ToShortDateString() : "",
                LotNumber = model.LotNumber,
                IssueReceipt = null,
                IssueAdjustment = null,//model.Adjustment,
                NetWeight = model.NetWeight,
                GrossWeight = model.GrossWeight,
                UnitQuantity = model.UnitQuantity,
                SupplyPrice = model.Rate,
                TotalSupplyAmount = model.TotalAmount,
                IsHold = model.IsHold,
                SupplierId = model.SupplierId,
                Supplier = model.Supplier,
                WarehouseId = model.WarehouseId,
                Warehouse = model.Warehouse,
                Uom = model.Uom,
                UomId = model.UomId,
                IssueDate = null,//model.
                Notes = null,
                Package = model.Package,
                PackageId = model.PackageId,
                PackageQuantity = model.PackageQuantity,
                ReceiveAdjustment = model.Adjustment,
                ReceiveDate = null,
                ReceiveReceipt = model.Reference,
                Remark = null,
            };
        }

        public static PurchaseOrderItem MapToEntity(PurchaseOrderItemModel model, PurchaseOrderItem entity)
        {
            if (entity == null)
                entity = new PurchaseOrderItem();

            entity.Adjustment = model.Adjustment;
            entity.ExpirationDate = model.ExpirationDate;
            entity.GrossWeight = model.GrossWeight;
            entity.IsHold = model.IsHold;
            entity.IsReceived = model.IsReceived;
            entity.LotNumber = model.LotNumber;
            entity.NetWeight = model.NetWeight;
            entity.PackageId = model.PackageId;
            entity.PackageQuantity = model.PackageQuantity;
            entity.ProductId = model.ProductId;
            entity.ProductionDate = model.ProductionDate;
            entity.PurchaseOrderId = model.PurchaseOrderId;
            entity.Rate = model.Rate;
            entity.Reference = model.Reference;
            entity.SupplierId = model.SupplierId;
            entity.TotalAmount = model.TotalAmount;
            entity.UnitQuantity = model.UnitQuantity;
            entity.UomId = model.UomId;
            entity.WarehouseId = model.WarehouseId;
            return entity;
        }

        public static List<PurchaseOrderItemModel> MapToPurhaseOrderItemModel(IQueryable<PurchaseOrderItem> query)
        {
            var list = new List<PurchaseOrderItemModel>();
            foreach (var model in query)
            {
                list.Add(new PurchaseOrderItemModel()
                {
                    Id = model.Id,
                    UnitQuantity = model.UnitQuantity,
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
                    UomId = model.UomId,
                    SupplierId = model.SupplierId,
                    Supplier = model.Supplier == null ? "" : model.Supplier.BasicInfo.Name,
                    Adjustment = model.Adjustment,
                    ExpirationDate = model.ExpirationDate,
                    GrossWeight = model.GrossWeight,
                    LotNumber = model.LotNumber,
                    NetWeight = model.NetWeight,
                    Package = model.Package == null ? "" : model.Package.Name,
                    PackageId = model.PackageId,
                    PackageQuantity = model.PackageQuantity,
                    ProductionDate = model.ProductionDate,
                    Reference = model.Reference,
                    Uom = model.Uom == null ? "" : model.Uom.Name,
                    
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