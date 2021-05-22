using System.Collections.Generic;
using System.Linq;
using Infrastructure.Context;
using ViewModel.Core.Inventory;

namespace DTO.Core.Inventory
{
    public static  class WarehouseProductMapper
    {
        public static List<WarehouseProductModel> MapToModel(IQueryable<WarehouseProduct> query)
        {
            var list = new List<WarehouseProductModel>();
            foreach(var entity in query)
            {
                list.Add(MapToModel(entity));
            }
            return list;
        }

        public static WarehouseProductModel MapToModel(WarehouseProduct entity)
        {
            return new WarehouseProductModel()
            {
                Id = entity.Id,
                InStockQuantity = entity.InStockQuantity,
                OnHoldQuantity = entity.OnHoldQuantity,
                Product = entity.Product == null ? "": entity.Product.Name,
                ProductId = entity.ProductId,
                SKU = entity.Product == null ? "": entity.Product.SKU,
                UpdatedAt = entity.UpdatedAt.ToShortDateString(),
                Warehouse = entity.Warehouse == null ? "" : entity.Warehouse.Name,
                WarehouseId = entity.WarehouseId,
                
            };
        }
    }
}
