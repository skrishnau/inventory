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
            entity.Unit = model.Unit;
            entity.Quantity = model.Quantity;
            entity.BaseUnitId = model.BaseUnitId;
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
                BaseUnit = uom.BaseUnit == null ? uom.Unit: uom.BaseUnit.Unit,
                Quantity = uom.Quantity,
                BaseUnitId = uom.BaseUnitId,
                Unit = uom.Unit,
                Use = uom.Use,
                Id = uom.Id
            };
        }
    }
}
