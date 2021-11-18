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
            if (entity == null)
                entity = new Manufacture();
            entity.LotNo = model.LotNo;
            entity.Name = model.Name;
            entity.Remarks = model.Remarks;
            return entity;
            //return Mappings.Mapper.Map(model, entity);
        }
        public static List<ManufactureModel> MapToModel(this ICollection<Manufacture> entityQuery)
        {
            var list = new List<ManufactureModel>();
            foreach (var s in entityQuery)
            {
                list.Add(s.MapToModel());
            }
            return list;
        }

    }
    public class ManufactureProfile : Profile
    {
        public ManufactureProfile()
        {
            CreateMap<Manufacture, ManufactureModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.CompletedAt != null ? "Completed" : src.CancelledAt != null ? "Cancelled" : src.DeletedAt != null ? "Deleted" : src.StartedAt != null ? "In_Process" : "New"))
                .ForMember(dest => dest.ManufactureDepartments, opt => opt.Ignore())
                .ForMember(dest => dest.ManufactureProducts, opt => opt.Ignore())
                ;
            CreateMap<ManufactureModel, Manufacture>()
                .ForMember(dest => dest.CancelledAt, opt => opt.Ignore())
                .ForMember(dest => dest.CancelledByUserId, opt => opt.Ignore())
                .ForMember(dest => dest.CompletedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CompletedByUserId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore())
                .ForMember(dest => dest.StartedAt, opt => opt.Ignore())
                .ForMember(dest => dest.StartedByUserId, opt => opt.Ignore())
                .ForMember(dest=> dest.ManufactureDepartments, opt=>opt.Ignore())
                .ForMember(dest=> dest.ManufactureProducts, opt=>opt.Ignore())
                .ForMember(dest=> dest.User, opt=>opt.Ignore())
                .ForMember(dest=> dest.User1, opt=>opt.Ignore())
                .ForMember(dest=> dest.User2, opt=>opt.Ignore())
                .ForMember(dest=> dest.User3, opt=>opt.Ignore())
                .ForMember(dest=> dest.User4, opt=>opt.Ignore())

                ;
        }
    }
}
