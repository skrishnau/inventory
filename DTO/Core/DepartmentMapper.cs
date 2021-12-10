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
    public static class DepartmentMapper
    {
        public static DepartmentModel MapToModel(this Department entity, DepartmentModel model = null)
        {
            return Mappings.Mapper.Map(entity, model);
        }

        public static Department MapToEntity(this DepartmentModel model, Department entity = null)
        {
            return Mappings.Mapper.Map(model, entity);
        }
        public static List<DepartmentModel> MapToModel(this ICollection<Department> entityQuery)
        {
            var list = new List<DepartmentModel>();
            foreach (var s in entityQuery)
            {
                list.Add(s.MapToModel());
            }
            return list;
        }

    }
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentModel>()
                .ForMember(dest => dest.DepartmentUsers, opt => opt.Ignore())
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src=>src.IsVendor ? "External": "Internal"))
                .ForMember (dest=>dest.Name , opt=>opt.MapFrom(src=> src.Name + " (" + (src.IsVendor ? "External" : "Internal") + ")"))
                ;
            CreateMap<DepartmentModel, Department>()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.DepartmentUsers, opt => opt.Ignore())
                .ForMember(dest => dest.ManufactureDepartments, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedAt, opt => opt.Ignore())
                ;
        }
    }
}
