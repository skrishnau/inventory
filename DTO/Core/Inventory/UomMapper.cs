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
    public static class UomMapper
    {

        public static Uom MapToEntity(this UomModel model, Uom entity)
        {
            return Mappings.Mapper.Map(model, entity);
            //if (entity == null)
            //    entity = new Uom();
            //entity.Use = model.Use;
            //entity.Name = model.Name;
            //entity.Quantity = model.Quantity;
            //entity.BaseUomId = model.BaseUomId;
            //return entity;
        }

        public static List<UomModel> MapToUomModel(this IQueryable<Uom> uoms)
        {
            return Mappings.Mapper.Map<List<UomModel>>(uoms.ToList());
            //var list = new List<UomModel>();
            //foreach (var uom in uoms)
            //{
            //    list.Add(MapToUomModel(uom));
            //}
            //return list;
        }

        public static UomModel MapToUomModel(this Uom uom)
        {
            return Mappings.Mapper.Map<UomModel>(uom);
            //return new UomModel()
            //{
            //    BaseUom = uom.BaseUom == null ? uom.Name : uom.BaseUom.Name,
            //    Quantity = uom.Quantity,
            //    BaseUomId = uom.BaseUomId,
            //    Name = uom.Name,
            //    Use = uom.Use,
            //    Id = uom.Id
            //};
        }
    }

    class UomProfile : Profile
    {
        public UomProfile()
        {
            CreateMap<Uom, UomModel>()
                .ForMember(dest => dest.BaseUom,
                            opt => opt.MapFrom(src => src.BaseUom == null ? src.Name : src.BaseUom.Name));
            CreateMap<UomModel, Uom>().ForMember(d => d.BaseUom, 
                            opt=> opt.Ignore());
        }
    }
}
