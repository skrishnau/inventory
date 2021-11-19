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
    public static class ManufactureDepartmentUserUserMapper
    {
        public static ManufactureDepartmentUserModel MapToModel(this ManufactureDepartmentUser entity, ManufactureDepartmentUserModel model = null)
        {
            return Mappings.Mapper.Map(entity, model);
        }

        public static ManufactureDepartmentUser MapToEntity(this ManufactureDepartmentUserModel model, ManufactureDepartmentUser entity = null)
        {
            return Mappings.Mapper.Map(model, entity);
        }
        public static List<ManufactureDepartmentUserModel> MapToModel(this ICollection<ManufactureDepartmentUser> entityQuery)
        {
            var list = new List<ManufactureDepartmentUserModel>();
            foreach (var s in entityQuery)
            {
                list.Add(s.MapToModel());
            }
            return list;
        }

    }
    public class ManufactureDepartmentUserProfile : Profile
    {
        public ManufactureDepartmentUserProfile()
        {
            CreateMap<ManufactureDepartmentUser, ManufactureDepartmentUserModel>()
                .ForMember(dest=>dest.Name, opt=>opt.MapFrom(src=>src.User.Name))
                ;
            CreateMap<ManufactureDepartmentUserModel, ManufactureDepartmentUser>()
                .ForMember(dest=> dest.ManufactureDepartment, opt=>opt.Ignore())
                .ForMember(dest=> dest.User, opt=>opt.Ignore())
                .ForMember(dest=> dest.UserManufactures, opt=>opt.Ignore())
                ;
        }
    }
}
