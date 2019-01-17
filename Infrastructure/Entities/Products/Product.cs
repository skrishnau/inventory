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

        public string Name { get; set; } // textbox 

        public int ProductCategoryId { get; set; } //dropdown

        public int BrandId { get; set; } // dropdown

        // current informations

        public decimal QuantityInStock { get; set; }

        public decimal LatestUnitCostPrice { get; set; }

        public decimal LatestUnitSellPrice { get; set; }


        // Alerts // checkbox
        public bool ShowStockAlerts { get; set; }

        public int MinStockCountForAlert { get; set; }


        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }



        // ------ table objects ------ //
        public virtual ProductCategory ProductCategory { get; set; }

        public virtual Brand Brand { get; set; }


    }
}
