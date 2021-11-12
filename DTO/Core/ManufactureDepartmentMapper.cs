using AutoMapper;
using DTO.AutoMapperBase;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core;

namespace DTO.Core
{
    public static class ManufactureDepartmentMapper
    {
        public static ManufactureDepartmentModel MapToModel(this ManufactureDepartment entity, ManufactureDepartmentModel model = null)
        {
            return Mappings.Mapper.Map(entity, model);
        }

        public static ManufactureDepartment MapToEntity(this ManufactureDepartmentModel model, ManufactureDepartment entity = null)
        {
            return Mappings.Mapper.Map(model, entity);
        }
        public static List<ManufactureDepartmentModel> MapToModel(this ICollection<ManufactureDepartment> entityQuery)
        {
            var list = new List<ManufactureDepartmentModel>();
            foreach (var s in entityQuery)
            {
                list.Add(s.MapToModel());
            }
            return list;
        }

    }
    public class ManufactureDepartmentProfile : Profile
    {
        public ManufactureDepartmentProfile()
        {
            CreateMap<ManufactureDepartment, ManufactureDepartmentModel>()
                .ForMember(dest => dest.ManufactureDepartmentUsers, opt => opt.MapFrom(src=>src.ManufactureDepartmentUsers))
                ;
            CreateMap<ManufactureDepartmentModel, ManufactureDepartment>()
                .ForMember(dest => dest.CancelledAt, opt => opt.Ignore())
                .ForMember(dest => dest.CancelledByUserId, opt => opt.Ignore())
                .ForMember(dest => dest.CompletedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CompletedByUserId, opt => opt.Ignore())
                .ForMember(dest => dest.StartedAt, opt => opt.Ignore())
                .ForMember(dest => dest.StartedByUserId, opt => opt.Ignore())
                .ForMember(dest=> dest.ManufactureDepartmentUsers, opt=>opt.Ignore())

                ;
        }
    }
}
