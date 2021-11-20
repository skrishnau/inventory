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
    public static class UserManufactureMapper
    {
        public static UserManufactureModel MapToModel(this UserManufacture entity, UserManufactureModel model = null)
        {
            return Mappings.Mapper.Map(entity, model);
        }

        public static UserManufacture MapToEntity(this UserManufactureModel model, UserManufacture entity = null)
        {
            return Mappings.Mapper.Map(model, entity);
        }
        public static List<UserManufactureModel> MapToModel(this ICollection<UserManufacture> entityQuery)
        {
            var list = new List<UserManufactureModel>();
            foreach (var s in entityQuery)
            {
                list.Add(s.MapToModel());
            }
            return list;
        }

    }
    public class UserManufactureProfile : Profile
    {
        public UserManufactureProfile()
        {
            CreateMap<UserManufacture, UserManufactureModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src=>src.ManufactureDepartmentUser.UserId))
                ;
            CreateMap<UserManufactureModel, UserManufacture>()
                .ForMember(dest => dest.ManufactureDepartmentUser, opt => opt.Ignore())
                ;
        }
    }
}
