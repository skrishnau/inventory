using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Business;
using ViewModel.Core.Business;

namespace DTO.Core.Business
{
    public static class WarehouseMapper
    {
        internal static ICollection<Warehouse> MapToEntity(ICollection<WarehouseModel> warehouses)
        {
            var list = new List<Warehouse>();
            foreach(var wh in warehouses)
            {
                list.Add(MapToEntity(wh));
            }
            return list;
        }

        internal static Warehouse MapToEntity(WarehouseModel wh)
        {
            return new Warehouse()
            {
                BranchId = wh.BranchId,
                CanMoveStocksToBranch = wh.CanMoveStocksToBranch,
                Code = wh.Code,
                CreatedAt = wh.CreatedAt,
                DeletedAt = wh.DeletedAt,
                Id = wh.Id,
                Location = wh.Location,
                UpdatedAt = wh.UpdatedAt,
            };
        }
    }
}
