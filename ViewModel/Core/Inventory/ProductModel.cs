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
        public int BrandId { get; set; }

        public decimal QuantityInStock { get; set; }
        public decimal LatestUnitCostPrice { get; set; }
        public decimal LatestUnitSellPrice { get; set; }

        public bool ShowStockAlerts { get; set; }

       

        public int MinStockCountForAlert { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual CategoryModel Category { get; set; }
        public virtual BrandModel Brand { get; set; }


        public Product ToEntity()
        {
            return new Product()
            {
                //Brand = Brand.ToEntity(),
                BrandId = BrandId,
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
                UpdatedAt = UpdatedAt
            };
        }
    }
}
