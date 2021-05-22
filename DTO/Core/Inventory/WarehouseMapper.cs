using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DTO.AutoMapperBase;
using Infrastructure.Context;
using ViewModel.Core.Business;

namespace DTO.Core.Inventory
{
    public static class WarehouseMapper
    {
        public static Warehouse MapToEntity(this WarehouseModel model, Warehouse entity)
        {
            return Mappings.Mapper.Map(model, entity);
        }

        public static List<WarehouseModel> MapToModel(this IQueryable<Warehouse> query)
        {
            return Mappings.Mapper.Map<IQueryable<Warehouse>, List<WarehouseModel>>(query);
        }

        public static WarehouseModel MapToModel(this Warehouse entity)
        {
            return Mappings.Mapper.Map<WarehouseModel>(entity);
        }
    }

    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<Warehouse, WarehouseModel>();
            CreateMap<WarehouseModel, Warehouse>();
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }
    }
}
