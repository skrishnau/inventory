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
    public static class ManufactureMapper
    {
        public static ManufactureModel MapToModel(this Manufacture entity, ManufactureModel model = null)
        {
            return Mappings.Mapper.Map(entity, model);
        }

        public static Manufacture MapToEntity(this ManufactureModel model, Manufacture entity = null)
        {
            return Mappings.Mapper.Map(model, entity);
        }
    }
    public class ManufactureProfile : Profile
    {
        public ManufactureProfile()
        {
            CreateMap<Manufacture, ManufactureModel>();
            CreateMap<ManufactureModel, Manufacture>()
                .ForMember(dest=>dest.CancelledAt, opt=>opt.Ignore())
                .ForMember(dest=>dest.CancelledByUserId, opt=>opt.Ignore())
                .ForMember(dest=>dest.CompletedAt, opt=>opt.Ignore())
                .ForMember(dest=>dest.CompletedByUserId, opt=>opt.Ignore())
                .ForMember(dest=>dest.CreatedAt, opt=>opt.Ignore())
                .ForMember(dest=>dest.CreatedByUserId, opt=>opt.Ignore())
                .ForMember(dest=>dest.StartedAt, opt=>opt.Ignore())
                .ForMember(dest=>dest.StartedByUserId, opt=>opt.Ignore())
                ;
        }
    }
}
