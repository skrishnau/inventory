using AutoMapper;
using DTO.AutoMapperBase;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core;
using ViewModel.Core.Inventory;

namespace DTO.Core
{
    public static class ManufactureDepartmentProductMapper
    {
        public static ManufactureDepartmentProductModel MapToModel(this ManufactureDepartmentProduct entity, ManufactureDepartmentProductModel model = null)
        {
            return Mappings.Mapper.Map(entity, model);
        }

        public static ManufactureDepartmentProduct MapToEntity(this ManufactureDepartmentProductModel model, ManufactureDepartmentProduct entity = null)
        {
            return Mappings.Mapper.Map(model, entity);
        }
        public static List<ManufactureDepartmentProductModel> MapToModel(this ICollection<ManufactureDepartmentProduct> entityQuery)
        {
            var list = new List<ManufactureDepartmentProductModel>();
            foreach (var s in entityQuery)
            {
                list.Add(s.MapToModel());
            }
            return list;
        }
        public static InventoryUnitModel MapToInventoryUnitModel(this ManufactureDepartmentProductModel model)
        {
            return new InventoryUnitModel
            {
                PackageId = model.PackageId,
                Package = model.PackageName,
                ProductId = model.ProductId,
                Product = model.ProductName,
                UnitQuantity = model.Quantity
            };
        }

        public static ManufactureDepartmentProductModel MapToManufactureDepartmentProductModel(this InventoryUnitModel model, int departmentId, bool inOut)
        {
            return new ManufactureDepartmentProductModel
            {
                PackageId = model.PackageId ?? 0,
                PackageName = model.Package,
                ProductId = model.ProductId,
                ProductName = model.Product,
                Quantity = model.UnitQuantity,
                DepartmentId = departmentId,
                InOut = inOut,
            };
        }
        
        public static List<ManufactureDepartmentProductModel> MapToManufactureDepartmentProductModel(this List<InventoryUnitModel> model, int departmentId, bool inOut)
        {
            var list = new List<ManufactureDepartmentProductModel>();
            foreach(var m in model)
            {
                list.Add(m.MapToManufactureDepartmentProductModel(departmentId, inOut));
            }
            return list;
        }

    }
    public class ManufactureDepartmentProductProfile : Profile
    {
        public ManufactureDepartmentProductProfile()
        {
            CreateMap<ManufactureDepartmentProduct, ManufactureDepartmentProductModel>()
                .ForMember(dest=>dest.DepartmentId, opt=>opt.MapFrom(src=>src.ManufactureDepartment.DepartmentId))
                ;
            CreateMap<ManufactureDepartmentProductModel, ManufactureDepartmentProduct>()
                ;
        }
    }

}
