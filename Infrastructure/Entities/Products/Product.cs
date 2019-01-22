using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Products
{
    public class Product
    {
        public int Id { get; set; }
        // product name
        public string Name { get; set; }
        // implement Many-to-Many realtion later in version 2 
        // (i.e. one product can be in multiple categories)
        public int ProductCategoryId { get; set; }
        // brand; one product belongs to one brand 
        public int BrandId { get; set; }

        // ==== current informations (calculated at runtime) ==== //

        public decimal QuantityInStock { get; set; }

        public decimal LatestUnitCostPrice { get; set; }

        public decimal LatestUnitSellPrice { get; set; }


        // ========== Alerts ========== //

        // whether to show alerts for this product's stock count
        public bool ShowStockAlerts { get; set; }
        // Min. stock count which triggers alert
        public int MinStockCountForAlert { get; set; }


        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }



        // ------ table objects ------ //
        public virtual ProductCategory ProductCategory { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
