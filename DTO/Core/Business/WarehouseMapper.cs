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

        public static Warehouse MapToEntity(WarehouseModel model, Warehouse entity)
        {
            if (entity == null)
                entity = new Warehouse();
            entity.Name = model.Name;
            entity.Hold = model.Hold;
            entity.MixedProduct = model.MixedProduct;
            entity.Staging = model.Staging;
            entity.Use = model.Use;
            return entity;
        }

        public static List<WarehouseModel> MapToModel(IQueryable<Warehouse> query)
        {
            var list = new List<WarehouseModel>();
            foreach(var entity in query)
            {
                list.Add(MapToModel(entity));
            }

            return list;
        }

        public static WarehouseModel MapToModel( Warehouse entity)
        {
            return new WarehouseModel()
            {
                Hold = entity.Hold,
                MixedProduct = entity.MixedProduct,
                Id = entity.Id,
                Name = entity.Name,
                Staging = entity.Staging,
                Use = entity.Use,
            };
        }
    }
}
