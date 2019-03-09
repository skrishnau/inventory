using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    public class Product
    {
        public int Id { get; set; }
        // product name
        public string Name { get; set; }
        // TODO:: implement Many-to-Many realtion later in version 2 
        // (i.e. one product can be in multiple categories)
        public int CategoryId { get; set; }

        // ==== current informations (calculated at runtime) ==== //

        // stock quantity
        public decimal QuantityInStock { get; set; }
        // lastly purchase price of the same product
        public decimal LatestUnitCostPrice { get; set; }
        // lastly selling price of the same product
        public decimal LatestUnitSellPrice { get; set; }


        // ========== Alerts ========== //

        // whether to show alerts for this product's stock count
        public bool ShowStockAlerts { get; set; }
        // Min. stock count which triggers alert
        public int MinStockCountForAlert { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


        // ------ table objects ------ //
        public virtual Category Category { get; set; }

        public virtual ICollection<Brand> Brands { get; set; }

        public virtual ICollection<ProductOption> ProductAttributes{ get; set; }
    }
}
