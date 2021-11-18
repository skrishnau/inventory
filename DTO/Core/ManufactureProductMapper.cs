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
    public static class ManufactureProductMapper
    {
        public static ManufactureProductModel MapToModel(this ManufactureProduct entity, ManufactureProductModel model = null)
        {
            return Mappings.Mapper.Map(entity, model);
        }

        public static ManufactureProduct MapToEntity(this ManufactureProductModel model, ManufactureProduct entity = null)
        {
            return Mappings.Mapper.Map(model, entity);
        }
        public static List<ManufactureProductModel> MapToModel(this ICollection<ManufactureProduct> entityQuery)
        {
            var list = new List<ManufactureProductModel>();
            foreach (var s in entityQuery)
            {
                list.Add(s.MapToModel());
            }
            return list;
        }

    }
    public class ManufactureProductProfile : Profile
    {
        public ManufactureProductProfile()
        {
            CreateMap<ManufactureProduct, ManufactureProductModel>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product == null ? "" : src.Product.Name))
                .ForMember(dest => dest.PackageName, opt => opt.MapFrom(src => src.Package == null ? "" : src.Package.Name))
                ;
            CreateMap<ManufactureProductModel, ManufactureProduct>()
                .ForMember(dest => dest.Manufacture, opt => opt.Ignore())
                .ForMember(dest => dest.Package, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                ;
        }
    }
}
