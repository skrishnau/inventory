﻿using AutoMapper;
using DTO.AutoMapperBase;
using Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
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
                .ForMember(dest => dest.RelatedPackage, opt => opt.MapFrom(src => src.Package1 == null ? (src.Package != null ? src.Package.Name : string.Empty) : src.Package1.Name))
                .ForMember(dest => dest.Package, opt => opt.MapFrom(src => src.Package == null ? string.Empty : src.Package.Name))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product == null ? string.Empty : src.Product.Name))
                ;
            CreateMap<UomModel, Uom>()
                .ForMember(d => d.Package1, opt=> opt.Ignore())
                .ForMember(d=>d.Package, opt=>opt.Ignore())
                .ForMember(d=>d.Product , opt=>opt.Ignore());
        }
    }
}
