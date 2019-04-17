using AutoMapper;
using DTO.AutoMapperBase;
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

        //static AdjustmentCodeMapper()
        //{
        //    Mapper.Initialize(cfg =>
        //    {
        //        cfg.CreateMap<AdjustmentCode, AdjustmentCodeModel>();
        //        cfg.CreateMap<AdjustmentCodeModel, AdjustmentCode>();
        //        // cfg.AddProfile<WarehouseProfile>();
        //    });
        //}

        public static AdjustmentCode MapToEntity(AdjustmentCodeModel model, AdjustmentCode entity)
        {
            return Mappings.Mapper.Map(model, entity);
            //if (entity == null)
            //    entity = new AdjustmentCode();

            //entity.Name = model.Name;
            //entity.AffectsDemand = model.AffectsDemand;
            //entity.Type = model.Type;
            //entity.Use = model.Use;
            //return entity;
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
            return Mappings.Mapper.Map<AdjustmentCodeModel>(entity);
            //return new AdjustmentCodeModel()
            //{
            //    Id = entity.Id,
            //    Name = entity.Name,
            //    AffectsDemand = entity.AffectsDemand,
            //    Type = entity.Type,
            //    Use = entity.Use,
            //};
        }
    }

    public class AdjustmentCodeProfile : Profile
    {
        public AdjustmentCodeProfile()
        {
            CreateMap<AdjustmentCode, AdjustmentCodeModel>();
            CreateMap<AdjustmentCodeModel, AdjustmentCode>();
        }
    }
}
