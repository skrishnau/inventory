using Infrastructure.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;

namespace DTO.Core.Inventory
{
    public static class AdjustmentCodeMapper
    {
        public static AdjustmentCode MapToEntity(AdjustmentCodeModel model, AdjustmentCode entity)
        {
            if (entity == null)
                entity = new AdjustmentCode();

            entity.Name = model.Name;
            entity.AffectsDemand = model.AffectsDemand;
            entity.Type = model.Type;
            entity.Use = model.Use;
            return entity;
        }

        public static List<AdjustmentCodeModel> MapToModel(IQueryable<AdjustmentCode> query)
        {
            var list = new List<AdjustmentCodeModel>();
            foreach (var entity in query)
            {
                list.Add(MapToModel(entity));
            }
            return list;
        }


        public static AdjustmentCodeModel MapToModel(AdjustmentCode entity)
        {
            return new AdjustmentCodeModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                AffectsDemand = entity.AffectsDemand,
                Type = entity.Type,
                Use = entity.Use,
            };
        }
    }
}
