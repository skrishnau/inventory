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
                Id = wh.Id,
                Hold = wh.Hold,
                MixedProduct = wh.MixedProduct,
                Location = wh.Location,
                Staging = wh.Staging,
            };
        }

        public static WarehouseModel MapToWarehouseModel(Warehouse warehouse)
        {
            return new WarehouseModel()
            {
                Hold = warehouse.Hold,
                MixedProduct = warehouse.MixedProduct,
                Id = warehouse.Id,
                Location = warehouse.Location,
                Staging = warehouse.Staging,
            };
        }
    }
}
