using Infrastructure.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;

namespace DTO.Core.Inventory
{
    public static class ProductMapper
    {
        public static Product MapToEntity(ProductModel productModel)
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
                OptionValues = GetOptionValuesCommaSeparatedString(x.ProductAttributes.ToList()),
                Category = x.Category.Name,
                MinStockCountForAlert = x.MinStockCountForAlert,
                QuantityInStocks = x.QuantityInStock,
                ShowStockAlerts = x.ShowStockAlerts
            };
        }

        public static string GetOptionValuesCommaSeparatedString(List<Infrastructure.Entities.Inventory.ProductOption> list)
        {
            var builder = new StringBuilder();

            foreach (var option in list.OrderBy(x => x.Option.Name).GroupBy(x => x.Option.Name))
            {
                builder.Append(option.Key);
                builder.Append(": ");

                for (var v = 0; v < option.Count(); v++)
                {
                    builder.Append(option.ElementAt(v).Option.Value);
                    if (v <= option.Count() - 2)
                        builder.Append(", ");
                }
                builder.Append(" ; ");
            }

            return builder.ToString();
        }

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
    }
}
