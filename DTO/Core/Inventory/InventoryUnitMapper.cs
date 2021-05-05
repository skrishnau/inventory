using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Inventory;
using ViewModel.Core.Inventory;
using ViewModel.Core.Orders;
using ViewModel.Utility;

namespace DTO.Core.Inventory
{
    public static class InventoryUnitMapper
    {


        public static List<InventoryUnitModel> MapToModel(this IEnumerable<InventoryUnit> query)
        {
            var list = new List<InventoryUnitModel>();
            foreach (var entity in query)
            {
                list.Add(MapToModel(entity));
            }
            return list;
        }
        public static List<InventoryUnitModel> MapToModel(this List<InventoryUnit> query)
        {
            var list = new List<InventoryUnitModel>();
            foreach (var entity in query)
            {
                list.Add(MapToModel(entity));
            }
            return list;
        }

        public static InventoryUnitModel MapToModel(this InventoryUnit entity)
        {
            return new InventoryUnitModel()
            {
                ExpirationDate = entity.ExpirationDate.HasValue ? entity.ExpirationDate.Value.ToShortDateString() : "",
                GrossWeight = entity.GrossWeight,
                Id = entity.Id,
                IsHold = entity.IsHold,
                IssueAdjustment = entity.IssueAdjustment,
                IssueDate = entity.IssueDate.HasValue ? entity.IssueDate.Value.ToShortDateString() : "",
                IssueReceipt = entity.IssueReceipt,
                LotNumber = entity.LotNumber,
                NetWeight = entity.NetWeight,
                Notes = entity.Notes,
                Package = entity.Package == null ? "" : entity.Package.Name,
                PackageId = entity.PackageId,
                PackageQuantity = entity.PackageQuantity,
                Product = entity.Product == null ? "" : entity.Product.Name,
                ProductId = entity.ProductId,
                ProductionDate = entity.ProductionDate.HasValue ? entity.ProductionDate.Value.ToShortDateString() : "",
                ReceiveAdjustmentCode = entity.ReceiveAdjustment,
                ReceiveDate = entity.ReceiveDate.HasValue ? entity.ReceiveDate.Value.ToShortDateString() : "",
                ReceiveDateBS = entity.ReceiveDate.HasValue ? DateConverter.Instance.ToBS(entity.ReceiveDate.Value).ToString() : "",
                ReceiveReceipt = entity.ReceiveReceipt,
                Remark = entity.Remark,
                SKU = entity.Product == null ? "" : entity.Product.SKU,
                Supplier = entity.Supplier == null ? "" : entity.Supplier.Name,
                SupplierId = entity.SupplierId,
                Rate = entity.Rate,
                UnitQuantity = entity.UnitQuantity,
                Uom = entity.Uom == null ? "" : entity.Uom.Name,
                UomId = entity.UomId,
                Warehouse = entity.Warehouse == null ? "" : entity.Warehouse.Name,
                WarehouseId = entity.WarehouseId,

            };
        }

        public static InventoryUnit CloneEntity(this InventoryUnit entity)
        {
            return new InventoryUnit()
            {

                ExpirationDate = entity.ExpirationDate,//.HasValue ? entity.ExpirationDate.Value.ToShortDateString() : "",
                GrossWeight = entity.GrossWeight,
                Id = entity.Id,
                IsHold = entity.IsHold,
                IssueAdjustment = entity.IssueAdjustment,
                IssueDate = entity.IssueDate,//.HasValue ? entity.IssueDate.Value.ToShortDateString() : "",
                IssueReceipt = entity.IssueReceipt,
                LotNumber = entity.LotNumber,
                NetWeight = entity.NetWeight,
                Notes = entity.Notes,
                //Package = entity.Package == null ? "" : entity.Package.Name,
                PackageId = entity.PackageId,
                PackageQuantity = entity.PackageQuantity,
                //Product = entity.Product == null ? "" : entity.Product.Name,
                ProductId = entity.ProductId,
                ProductionDate = entity.ProductionDate,//.HasValue ? entity.ProductionDate.Value.ToShortDateString() : "",
                ReceiveAdjustment = entity.ReceiveAdjustment,
                ReceiveDate = entity.ReceiveDate,//.HasValue ? entity.ReceiveDate.Value.ToShortDateString() : "",
                ReceiveReceipt = entity.ReceiveReceipt,
                Remark = entity.Remark,
                // SKU = entity.Product == null ? "" : entity.Product.SKU,
                // Supplier = entity.Supplier, == null ? "" : entity.Supplier.BasicInfo.Name,
                SupplierId = entity.SupplierId,
                Rate = entity.Rate,
                UnitQuantity = entity.UnitQuantity,
                //Uom = entity.Uom == null ? "" : entity.Uom.Name,
                UomId = entity.UomId,
                // Warehouse = entity.Warehouse == null ? "" : entity.Warehouse.Name,
                WarehouseId = entity.WarehouseId,

            };
        }

        public static List<InventoryUnit> MapToEntity(this List<InventoryUnitModel> modelList)
        {
            var entityList = new List<InventoryUnit>();
            foreach (var model in modelList)
            {
                entityList.Add(MapToEntity(model));
            }
            return entityList;
        }

        public static InventoryUnit MapToEntity(this InventoryUnitModel model)
        {
            DateTime productionDate; DateTime expireDate;
            var prodDateParsed = DateTime.TryParse(model.ProductionDate, out productionDate);
            var expireDateParsed = DateTime.TryParse(model.ExpirationDate, out expireDate);

            return new InventoryUnit()
            {
                ExpirationDate = expireDateParsed ? (DateTime?)expireDate : null, //model.ExpirationDate,
                GrossWeight = model.GrossWeight,
                Id = model.Id,
                IsHold = model.IsHold,
                IssueAdjustment = model.IssueAdjustment,
                IssueDate = null,//model.IssueDate,
                IssueReceipt = model.IssueReceipt,
                LotNumber = model.LotNumber,
                NetWeight = model.NetWeight,
                Notes = model.Notes,
                //Package  = model.Package,
                PackageId = model.PackageId,
                PackageQuantity = model.PackageQuantity,
                //Product = model.Product,
                ProductId = model.ProductId,
                ProductionDate = prodDateParsed ? (DateTime?)productionDate : null, //model.ProductionDate,
                ReceiveAdjustment = model.ReceiveAdjustmentCode,
                ReceiveDate = null,//model.ReceiveDate,
                ReceiveReceipt = model.ReceiveReceipt,
                Remark = model.Remark,
                //Supplier= model.Supplier,
                SupplierId = model.SupplierId,
                Rate = model.Rate,
                Total = model.Total,
                UnitQuantity = model.UnitQuantity,
                //Uom = model.Uom,
                UomId = model.UomId,
                //Warehouse = model.Warehouse,
                WarehouseId = model.WarehouseId,
                
            };
        }
        public static List<OrderItemModel> MapToOrderItemModel(List<InventoryUnitModel> model, int orderId, bool assignIdAlso = false)
        {
            var list = new List<OrderItemModel>();
            if (model == null)
                return list;
            foreach (var m in model)
            {
                list.Add(MapToOrderItemModel(m, orderId, assignIdAlso));
            }
            return list;
        }

        public static OrderItemModel MapToOrderItemModel(InventoryUnitModel model, int orderId, bool assignIdAlso = false)
        {
            return new OrderItemModel()
            {
                Id = assignIdAlso ? model.Id : 0,
                ProductId = model.ProductId,
                Product = model.Product,
                SKU = model.SKU,
                ExpirationDate = model.ExpirationDate,//.HasValue ? model.ExpirationDate.Value.ToShortDateString() : "",
                ProductionDate = model.ProductionDate,//.HasValue ? model.ProductionDate.Value.ToShortDateString() : "",
                LotNumber = model.LotNumber,
                //IssueReceipt = null,
                //IssueAdjustment = null,//model.Adjustment,
                NetWeight = model.NetWeight,
                GrossWeight = model.GrossWeight,
                UnitQuantity = model.UnitQuantity,
                Rate = model.Rate,
                Total = model.Total,
                IsHold = model.IsHold,
                SupplierId = model.SupplierId,
                Supplier = model.Supplier,
                WarehouseId = model.WarehouseId,
                Warehouse = model.Warehouse,
                Uom = model.Uom,
                UomId = model.UomId,
                Package = model.Package,
                PackageId = model.PackageId,
                PackageQuantity = model.PackageQuantity,
                //ReceiveAdjustmentCode = model.Adjustment,
                //ReceiveDate = null,
                //ReceiveReceipt = model.Reference,
                //Remark = null,
                OrderId = orderId,
                
            };
        }
    }
}
