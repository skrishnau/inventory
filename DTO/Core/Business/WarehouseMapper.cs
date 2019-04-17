using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO.AutoMapperBase;
using Infrastructure.Entities.Business;
using ViewModel.Core.Business;

namespace DTO.Core.Business
{
    public static class WarehouseMapper
    {
        public static Warehouse MapToEntity(WarehouseModel model, Warehouse entity)
        {
            return Mappings.Mapper.Map(model, entity);
        }

        public static List<WarehouseModel> MapToModel(IQueryable<Warehouse> query)
        {
            return Mappings.Mapper.Map<IQueryable<Warehouse>, List<WarehouseModel>>(query);
        }

        public static WarehouseModel MapToModel(Warehouse entity)
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
