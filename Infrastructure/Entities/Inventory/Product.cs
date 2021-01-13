using Infrastructure.Entities.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    /// <summary>
    /// Lokad has many definitions: <link>www.lokad.com</link>
    /// 
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        // ================ Basic Info ================ //
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Barcode { get; set; }
        public bool Use { get; set; } // to show or not show in product lists of other views
        // does this product have variants. For variants this value is always false
        public bool HasVariants { get; set; } // NOTE: if this is root product then it may or may not have variants. But if this is a variant then it never has variants
        // is this a variant product; false: means root product
        public bool IsVariant { get; set; }
        // parent product Id for variants
        public int? ParentProductId { get; set; }
        public virtual Product ParentProduct { get; set; }
        public int? CategoryId { get; set; } // variant can't change category; changing category on parent should be reflected in Variants
        public virtual Category Category { get; set; }
        public bool IsDiscontinued { get; set; }
        // ============== Package ============== //
        public int? PackageId { get; set; }
        public virtual Package Package { get; set; }
        public int? BaseUomId { get; set; }
        public virtual Uom BaseUom { get; set; }
        public decimal UnitsInPackage { get; set; }
        public decimal UnitNetWeight { get; set; }
        public decimal UnitGrossWeight { get; set; }

        // ================ Stocking Detail ================= //
        public bool IsBuy { get; set; }
        public bool IsSell { get; set; }
        public bool IsBuild { get; set; }
        public bool IsNotMovable { get; set; }
        public int? WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }

        // ========= Replenishments ========== //
        public decimal ReorderPoint { get; set; }
        public decimal ReorderQuantity { get; set; }
        public bool ReorderAlert { get; set; }
        // ------------ Order ----------------- //
        public int LeadDays { get; set; }
        // economic order quantity
        public decimal EOQ { get; set; } // Formula in : https://www.lokad.com/economic-order-quantity-eoq-definition-and-formula
        public decimal MonthlyDemand { get; set; }

        // ==== current informations (calculated at runtime) ==== //
        public decimal InStockQuantity { get; set; } // in whole inventory; incl. Hold
        public decimal OnHoldQuantity { get; set; }
        public decimal CommittedQuantity { get; set; }
        public decimal OnOrderQuantity { get; set; }
        // ------------ Price -------------- //
        public decimal SupplyPrice { get; set; }
        public decimal MarkupPercent { get; set; } // percent to keep for ourselves
        public decimal RetailPrice { get; set; }

        // ============= Extra Information ============= //
        //public string Label { get; set; }
        public string Manufacturer { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string AttributesJSON { get; set; }

        // ============ Time Stamps ============ //
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
       // public DateTime? DeletedAt { get; set; }

        // ------ table objects ------ //
      //  public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
      //  public virtual ICollection<Variant> Variants { get; set; }

            public virtual ICollection<WarehouseProduct> WarehouseProducts { get; set; }

        public Product()
        {
            ProductAttributes = new List<ProductAttribute>();
           // Brands = new List<Brand>();
           // Variants = new List<Variant>();
        }


    }
}


//// stock quantity
//public decimal QuantityInStock { get; set; }
//// lastly purchase price of the same product
//public decimal LatestUnitCostPrice { get; set; }
//// lastly selling price of the same product
//public decimal LatestUnitSellPrice { get; set; }
