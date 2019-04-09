using Infrastructure.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;

namespace DTO.Core.Inventory
{
   public static  class UomMapper
    {

        public static Uom MapToEntity(UomModel model, Uom entity)
        {
            if (entity == null)
                entity = new Uom();

            entity.Use = model.Use;
            entity.Name = model.Name;
            entity.Quantity = model.Quantity;
            entity.BaseUomId = model.BaseUomId;
            return entity;
        }

        public static List<UomModel> MapToUomModel(IQueryable<Uom> uoms)
        {
            var list = new List<UomModel>();
            foreach(var uom in uoms)
            {
                list.Add(MapToUomModel(uom));
            }
            return list;
        }

        public static UomModel MapToUomModel(Uom uom)
        {
            return new UomModel()
            {
                BaseUom = uom.BaseUom == null ? uom.Name: uom.BaseUom.Name,
                Quantity = uom.Quantity,
                BaseUomId = uom.BaseUomId,
                Name = uom.Name,
                Use = uom.Use,
                Id = uom.Id
            };
        }
    }
}
