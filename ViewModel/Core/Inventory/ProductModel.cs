using Infrastructure.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Inventory
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
       // public int BrandId { get; set; }

        public decimal QuantityInStock { get; set; }
        public decimal LatestUnitCostPrice { get; set; }
        public decimal LatestUnitSellPrice { get; set; }

        public bool ShowStockAlerts { get; set; }

        public int MinStockCountForAlert { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual CategoryModel Category { get; set; }
        public virtual List<BrandModel> Brands { get; set; }


        public Product ToEntity()
        {
            var brandEntities = new List<Brand>();
            foreach(var b in Brands)
            {
                brandEntities.Add(b.ToEntity());
            }
            return new Product()
            {
                //Category = Category.ToEntity(),
                CategoryId = CategoryId,
                CreatedAt = CreatedAt,
                DeletedAt = DeletedAt,
                Id = Id,
                LatestUnitCostPrice = LatestUnitCostPrice,
                LatestUnitSellPrice = LatestUnitSellPrice,
                MinStockCountForAlert = MinStockCountForAlert,
                Name = Name,
                QuantityInStock = QuantityInStock,
                ShowStockAlerts = ShowStockAlerts,
                UpdatedAt = UpdatedAt,
                Brands = brandEntities
            };
        }
    }

    public class ProductModelForGridView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brands { get; set; }
        public bool ShowStockAlerts { get; set; }
        public decimal QuantityInStocks { get; set; }
        public int MinStockCountForAlert { get; set; }

        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

    }
}
