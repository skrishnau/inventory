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
                    opt => opt.MapFrom(src => src.Date.ToShortDateString()));
            //CreateMap<MovementModel, Movement>();
        }
    }
}
