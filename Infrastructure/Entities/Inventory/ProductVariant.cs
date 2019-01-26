using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    /// <summary>
    /// A product's variant. i.e. different types in the same product
    /// For e.g. : the SKU for purple Ugg boots in the Bailey Bow style, size 6, may read UGG-BB-PUR-06
    /// </summary>
    public class ProductVariant
    {
        public int Id { get; set; }
        // product
        public int ProductId { get; set; }

        // TODO:: should be indexed.
        // stock keeping unit code. generated from values in ProductVariantValue table
        // Shoes have options: Name, Style, Size, Color 
        //          (Name=Shoes, Style=Bow, Size=6, Color=black)
        // e.g. the SKU for purple Ugg boots in the Bailey Bow style, size 6, may read UGG-BB-PUR-06
        public string SKU { get; set; }

        // ===== dynamic values; calculated in runtime ===== //
        public decimal QuantityInStock { get; set; }
        // lastly purchase price of the same product
        public decimal LatestUnitCostPrice { get; set; }
        // lastly selling price of the same product
        public decimal LatestUnitSellPrice { get; set; }


        // ====== Table Objects ====== //
        public ICollection<ProductVariantValue> ProductVariantValues { get; set; }
      
    }
}
