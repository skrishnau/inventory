using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Inventory;
using ViewModel.Core.Inventory;

namespace DTO.Core.Inventory
{
    public class InventoryUnitMapper
    {
        

        public static List<InventoryUnitModel> MapToModel(IQueryable<InventoryUnit> query)
        {
            var list = new List<InventoryUnitModel>();
            foreach (var entity in query)
            {
                list.Add(MapToModel(entity));
            }
            return list;
        }
        public static List<InventoryUnitModel> MapToModel(List<InventoryUnit> query)
        {
            var list = new List<InventoryUnitModel>();
            foreach (var entity in query)
            {
                list.Add(MapToModel(entity));
            }
            return list;
        }

        public static InventoryUnitModel MapToModel(InventoryUnit entity)
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
                ReceiveAdjustment = entity.ReceiveAdjustment,
                ReceiveDate = entity.ReceiveDate.HasValue ? entity.ReceiveDate.Value.ToShortDateString() : "",
                ReceiveReceipt = entity.ReceiveReceipt,
                Remark = entity.Remark,
                SKU = entity.Product == null ? "" : entity.Product.SKU,
                Supplier = entity.Supplier == null ? "" : entity.Supplier.BasicInfo.Name,
                SupplierId = entity.SupplierId,
                SupplyPrice = entity.SupplyPrice,
                UnitQuantity = entity.UnitQuantity,
                Uom = entity.Uom == null ? "" : entity.Uom.Name,
                UomId = entity.UomId,
                Warehouse = entity.Warehouse == null ? "" : entity.Warehouse.Name,
                WarehouseId = entity.WarehouseId,

            };
        }

        public static InventoryUnit CloneEntity(InventoryUnit entity)
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
                SupplyPrice = entity.SupplyPrice,
                UnitQuantity = entity.UnitQuantity,
                //Uom = entity.Uom == null ? "" : entity.Uom.Name,
                UomId = entity.UomId,
                // Warehouse = entity.Warehouse == null ? "" : entity.Warehouse.Name,
                WarehouseId = entity.WarehouseId,

            };
        }
    }
}
