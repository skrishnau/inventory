using DTO.Core.Business;
using Infrastructure.Entities.Inventory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Common;
using ViewModel.Core.Inventory;

namespace DTO.Core.Inventory
{
    public static class ProductMapper
    {
        public static Product MapToEntity(ProductModelForSave model, Product entity)
        {
            if (entity == null)
                entity = new Product();
            // basics
            entity.Name = model.Name;
            entity.CategoryId = model.CategoryId;
            //entity.Category = model.Category;
            entity.HasVariants = model.HasVariants;
            entity.IsVariant = model.IsVariant;
            //entity.ParentProduct = model.ParentProduct;
            entity.ParentProductId = model.ParentProductId;
            entity.SKU = model.SKU;
            entity.Use = model.Use;
            // replenishments
            entity.ReorderPoint = model.ReorderPoint;
            entity.ReorderQuantity = model.ReorderQuantity;
            entity.ReorderAlert = model.ReorderAlert;
            // quanity
            entity.AvailableQuantity = model.AvailableQuantity;
            entity.CommittedQuantity = model.CommittedQuantity;
            entity.InStockQuantity = model.InStockQuantity;
            entity.OnHoldQuantity = model.OnHoldQuantity;
            entity.OnOrderQuantity = model.OnOrderQuantity;
            // extra info
            entity.AttributesJSON = model.AttributesJSON;
            entity.Barcode = model.Barcode;
            entity.Brand = model.Brand;
            //entity.Brands = model.Brands;
            entity.Description = model.Description;
            entity.Label = model.Label;
            entity.Manufacturer = model.Manufacturer;
            //package
            entity.PackageId = model.PackageId;
            //entity.Package = model.Package;
            entity.BaseUomId = model.BaseUomId;
            //entity.BaseUom = model.BaseUom;
            entity.UnitsInPackage = model.UnitsInPackage;
            entity.UnitNetWeight = model.UnitNetWeight;
            entity.UnitGrossWeight = model.UnitGrossWeight;
            // order
            entity.LeadDays = model.LeadDays;
            entity.EOQ = model.EOQ;
            entity.MonthlyDemand = model.MonthlyDemand;
            // inventory stocking
            entity.IsBuild = model.IsBuild;
            entity.IsBuy = model.IsBuy;
            entity.IsNotMovable = model.IsNotMovable;
            entity.IsSell = model.IsSell;
            entity.WarehouseId = model.WarehouseId;
            //entity.Warehouse = model.Warehouse;
            // pricing
            entity.RetailPrice = model.RetailPrice;
            entity.MarkupPercent = model.MarkupPercent;
            entity.SupplyPrice = model.SupplyPrice;
            // collections
            //entity.ProductAttributes = model.ProductAttributes;
            //entity.Variants = model.Variants;
            return entity;
        }


        public static ProductModelForGridView MapToProductModelForGridView(Product x)
        {
            return new ProductModelForGridView()
            {
                Name = x.Name,
                Id = x.Id,
                CreatedAt = GetDateShortString(x.CreatedAt),
                UpdatedAt = GetDateShortString(x.UpdatedAt),
                Brands = GetBrandListCommaSeparatedString(x.Brands.ToList()),
                // OptionValues = GetOptionValuesCommaSeparatedString(x.ProductAttributes.ToList()),
                Category = x.Category.Name,
                MinStockCountForAlert = x.ReorderPoint,
                QuantityInStocks = x.InStockQuantity,
                ShowStockAlerts = x.ReorderAlert,
                VariantCount = x.Variants == null ? 0 : x.Variants.Count
            };
        }

        //public static string GetOptionValuesCommaSeparatedString(List<Infrastructure.Entities.Inventory.ProductAttribute> list)
        //{
        //    var builder = new StringBuilder();
        //    foreach (var option in list.OrderBy(x => x.Option.Name).GroupBy(x => x.Option.Name))
        //    {
        //        builder.Append(option.Key);
        //        builder.Append(": ");

        //        for (var v = 0; v < option.Count(); v++)
        //        {
        //            builder.Append(option.ElementAt(v).Option.Value);
        //            if (v <= option.Count() - 2)
        //                builder.Append(", ");
        //        }
        //        builder.Append(" ; ");
        //    }
        //    return builder.ToString();
        //}

        public static string GetDateShortString(DateTime date)
        {
            return date.ToShortDateString();
        }

        public static string GetBrandListCommaSeparatedString(List<Brand> brands)
        {
            var builder = new StringBuilder();
            for (var b = 0; b < brands.Count; b++)
            {

                builder.Append(brands[b].Name);
                if (b < brands.Count - 2)
                    builder.Append(", ");
                if (b == brands.Count - 2)
                    builder.Append(" , ");// &

            }
            return builder.ToString();
        }

        public static ProductModel MapToProductModel(Product product)
        {
            return new ProductModel()
            {
                Id = product.Id,
                Name = product.Name,
            };
        }
        
        public static ProductModelForSave MapToProductModelForSave(Product entity)
        {
            var model = new ProductModelForSave();
            // basics
            model.Name = entity.Name;
            model.CategoryId = entity.CategoryId;
            model.Category = CategoryMapper.MapToCategoryModel(entity.Category);
            model.HasVariants = entity.HasVariants;
            model.IsVariant = entity.IsVariant;
            //entity.ParentProduct = model.ParentProduct;
            model.ParentProduct = entity.ParentProduct == null? null: ProductMapper.MapToProductModelForSave(entity.ParentProduct);
            model.ParentProductId = entity.ParentProductId;
            model.SKU = entity.SKU;
            model.Use = entity.Use;
            // replenishments
            model.ReorderPoint = entity.ReorderPoint;
            model.ReorderQuantity = entity.ReorderQuantity;
            model.ReorderAlert = entity.ReorderAlert;
            // quanity
            model.AvailableQuantity = entity.AvailableQuantity;
            model.CommittedQuantity = entity.CommittedQuantity;
            model.InStockQuantity = entity.InStockQuantity;
            model.OnHoldQuantity = entity.OnHoldQuantity;
            model.OnOrderQuantity = entity.OnOrderQuantity;
            // extra info
            model.AttributesJSON = entity.AttributesJSON;
            model.Barcode = entity.Barcode;
            model.Brand = entity.Brand;
            model.Brands = BrandMapper.MapToBrandModel(entity.Brands.Where(x => x.DeletedAt == null).ToList());
            model.Description = entity.Description;
            model.Label = entity.Label;
            model.Manufacturer = entity.Manufacturer;
            //package
            model.PackageId = entity.PackageId;
            model.Package = PackageMapper.MapToModel(entity.Package);
            model.BaseUomId = entity.BaseUomId;
            model.BaseUom = UomMapper.MapToUomModel(entity.BaseUom);
            model.UnitsInPackage = entity.UnitsInPackage;
            model.UnitNetWeight = entity.UnitNetWeight;
            model.UnitGrossWeight = entity.UnitGrossWeight;
            // order
            model.LeadDays = entity.LeadDays;
            model.EOQ = entity.EOQ;
            model.MonthlyDemand = entity.MonthlyDemand;
            // inventory stocking
            model.IsBuild = entity.IsBuild;
            model.IsBuy = entity.IsBuy;
            model.IsNotMovable = entity.IsNotMovable;
            model.IsSell = entity.IsSell;
            model.WarehouseId = entity.WarehouseId;
            model.Warehouse = entity.Warehouse == null ? null :WarehouseMapper.MapToWarehouseModel(entity.Warehouse);
            // pricing
            model.RetailPrice = entity.RetailPrice;
            model.MarkupPercent = entity.MarkupPercent;
            model.SupplyPrice = entity.SupplyPrice;
            // collections
            model.ProductAttributes = MapToProductAttributeModel(entity.ProductAttributes);
            model.Variants = MapToProductVariant(entity.Variants);
            return model;
        }



        private static List<ProductVariantModel> MapToProductVariant(ICollection<Variant> variants)
        {
            var list = new List<ProductVariantModel>();
            foreach (var vari in variants)
            {
                var mod = new ProductVariantModel()
                {
                    Alert = vari.Alert ?? false,
                    AlertThreshold = vari.MinStockCountForAlert ?? 0,
                    Id = vari.Id,
                    SKU = vari.SKU,
                    Attributes = JsonConvert.DeserializeObject<List<NameValuePair>>(vari.AttributesJSON),
                };
                // parse attribute json
                // foreach (var att in vari.VariantAttributes)
                // {
                //     mod.Attributes.Add(new NameValuePair(att.ProductAttribute.Attribute, att.Value));
                // }
                list.Add(mod);
            }
            return list;
        }

        public static List<ProductAttributeModel> MapToProductAttributeModel(ICollection<ProductAttribute> collection)
        {
            var list = new List<ProductAttributeModel>();
            foreach (var col in collection)
            {
                list.Add(new ProductAttributeModel()
                {
                    Attribute = col.Attribute,
                    Id = col.Id,
                    ProductId = col.ProductId
                });
            }
            return list;
        }
    }
}
