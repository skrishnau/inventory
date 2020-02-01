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
    [Obsolete("Extra table for Brand is not to be done now", true)]
    public static class BrandMapper
    {
        public static List<BrandModel> MapToBrandModel(this ICollection<Brand> brands)
        {
            return Mappings.Mapper.Map<List<BrandModel>>(brands);
        }
    }

    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandModel>();
            CreateMap<BrandModel, Brand>();

        }

    }
}
