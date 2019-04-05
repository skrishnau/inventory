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
        public static Product MapToEntity(ProductModelForSave productModel)
        {
            return productModel.ToEntity();
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
                MinStockCountForAlert = x.AlertThreshold,
                QuantityInStocks = x.QuantityInStock,
                ShowStockAlerts = x.Alert,
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

        public static ProductModelForSave MapToProductModelForSave(Product product)
        {
            return new ProductModelForSave()
            {
                Id = product.Id,
                Name = product.Name,
                ProductAttributes = MapToProductAttributeModel(product.ProductAttributes),
                Brands = BrandMapper.MapToBrandModel(product.Brands.Where(x=>x.DeletedAt==null).ToList()),
                CategoryId = product.CategoryId,
                Category = CategoryMapper.MapToCategoryModel(product.Category),
                CreatedAt = product.CreatedAt,
                DeletedAt = product.DeletedAt,
                UpdatedAt = product.UpdatedAt,
                ShowStockAlerts = product.Alert,
                MinStockCountForAlert = product.AlertThreshold,
                Variants = MapToProductVariant(product.Variants),
            };
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
