using Infrastructure.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;

namespace DTO.Core.Inventory
{
    public static class PackageMapper
    {
        public static Package MapToEntity(PackageModel model, Package entity)
        {
            if (entity == null)
                entity = new Package();

            entity.Name = model.Name;
            entity.Use = model.Use;
            return entity;
        }

        public static List<PackageModel> MapToModel(IQueryable<Package> query)
        {
            var list = new List<PackageModel>();
            foreach(var entity in query)
            {
                list.Add(MapToModel(entity));
            }
            return list;
        }


        public static PackageModel MapToModel(Package entity)
        {
            return new PackageModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Use = entity.Use,
            };
        }
    }
}
