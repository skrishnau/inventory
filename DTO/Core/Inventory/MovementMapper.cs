using AutoMapper;
using DTO.AutoMapperBase;
using Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using ViewModel.Core.Inventory;
using ViewModel.Utility;

namespace DTO.Core.Inventory
{
    public static class MovementMapper
    {
        public static List<MovementModel> MapToModel(this IQueryable<Movement> query)
        {
            return Mappings.Mapper.Map<List<MovementModel>>(query);
        }
    }

    public class MovementProfile : Profile
    {
        public MovementProfile()
        {
            CreateMap<Movement, MovementModel>()
                 .ForMember(d => d.Date,
                    opt => opt.MapFrom(src => DateConverter.Instance.ToBS(src.Date).ToString()));
            //CreateMap<MovementModel, Movement>();
        }
    }
}
