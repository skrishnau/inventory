using AutoMapper;
using DTO.AutoMapperBase;
using Infrastructure.Context;
using System.Collections.Generic;
using ViewModel.Core.Inventory;

namespace DTO.Core.Inventory
{
    public static class AdjustmentCodeMapper
    {
        public static AdjustmentCode MapToEntity(this AdjustmentCodeModel model, AdjustmentCode entity)
        {
            return Mappings.Mapper.Map(model, entity);
        }

        public static List<AdjustmentCodeModel> MapToModel(this IEnumerable<AdjustmentCode> query)
        {
            return Mappings.Mapper.Map<List<AdjustmentCodeModel>>(query);
        }

        public static AdjustmentCodeModel MapToModel(this AdjustmentCode entity)
        {
            return Mappings.Mapper.Map<AdjustmentCodeModel>(entity);
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



//var list = new List<AdjustmentCodeModel>();
//foreach (var entity in query)
//{
//    list.Add(MapToModel(entity));
//}
//return list;



//return new AdjustmentCodeModel()
//{
//    Id = entity.Id,
//    Name = entity.Name,
//    AffectsDemand = entity.AffectsDemand,
//    Type = entity.Type,
//    Use = entity.Use,
//};