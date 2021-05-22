using System.Collections.Generic;

namespace ViewModel.Core.Inventory
{
    // basic model. add more properties if needed
    //public class ProductModel
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    public class ProductListModel
    {
        public List<ProductModel> DataList { get; set; }

        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int Offset { get; set; }
    }

    public class ProductModel
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
        public string ParentProduct { get; set; }
        public int? CategoryId { get; set; } // variant can't change category; changing category on parent should be reflected in Variants
        public string Category { get; set; }
        public int? UserId { get; set; }
        public string User { get; set; }

        // ============== Package ============== //
        public int? BasePackageId { get; set; }
        public string BasePackage { get; set; }
        //public int? BaseUomId { get; set; }
        //public string BaseUom { get; set; }
        public decimal UnitsInPackage { get; set; }
        public decimal UnitNetWeight { get; set; }
        public decimal UnitGrossWeight { get; set; }

        // ================ Stocking Detail ================= //
        public bool IsBuy { get; set; }
        public bool IsSell { get; set; }
        public bool IsBuild { get; set; }
        public bool IsNotMovable { get; set; }
        public int? WarehouseId { get; set; }
        public string Warehouse { get; set; }

        // ========= Replenishments ========== //
        public decimal ReorderPoint { get; set; }
        public decimal ReorderQuantity { get; set; }
        public bool ReorderAlert { get; set; }
        // ------------  ----------------- //
        public int LeadDays { get; set; }
        // economic order quantity
        public decimal EOQ { get; set; } // Formula in : https://www.lokad.com/economic-order-quantity-eoq-definition-and-formula
        public decimal MonthlyDemand { get; set; }

        // ==== current informations (calculated at runtime) ==== //
        // public decimal AvailableQuantity { get; set; }
        public decimal InStockQuantity { get; set; }
        public decimal OnHoldQuantity { get; set; }
        public decimal CommittedQuantity { get; set; }
        public decimal OnOrderQuantity { get; set; }
        // ------------ Price -------------- //

        public decimal MarkupPercent { get; set; } // percent to keep for ourselves

        public string CostPriceWholeText { get; set; }
        public decimal CostPrice { get; set; }
        public string CostPriceDateBS { get; set; }
        public string CostPricePackage { get; set; }

        public string SellingPriceWholeText { get; set; }
        public decimal SellingPrice { get; set; }
        public string SellingPriceDateBS { get; set; }
        public string SellingPricePackage { get; set; }

        // ============= Extra Information ============= //
        //public string Label { get; set; }
        public string Manufacturer { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string AttributesJSON { get; set; }

        // ============ Time Stamps ============ //
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
        //public DateTime? DeletedAt { get; set; }


        // used for dynamic attributes adding and for adding SKU directly in Product Create
        public virtual List<ProductAttributeModel> ProductAttributes { get; set; }
        public virtual List<UomModel> Uoms { get; set; }
        // public List<ProductVariantModel> Variants { get; set; }
        //  public virtual List<BrandModel> Brands { get; set; }

        public List<PackageModel> Packages { get; set; }

        public bool IsLessThanMinimumStock { get; set; }

        public ProductModel()
        {
            // Category = new CategoryModel();
            // Brands = new List<BrandModel>();
            ProductAttributes = new List<ProductAttributeModel>();
            Uoms = new List<UomModel>();
            //Variants = new List<ProductVariantModel>();
            // only used for entity to model conversion to be used in views
            Packages = new List<PackageModel>();
        }

    }



    //public class ProductModelForGridView
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Category { get; set; }
    //    public string Brands { get; set; }
    //    public string OptionValues { get; set; }
    //    public bool ShowStockAlerts { get; set; }
    //    public decimal QuantityInStocks { get; set; }
    //    public decimal MinStockCountForAlert { get; set; }

    //    public string CreatedAt { get; set; }
    //    public string UpdatedAt { get; set; }

    //    public int VariantCount { get; set; }

    //}
}



//public class ProductVariantModel
//{
//    public ProductVariantModel()
//    {
//        Attributes = new List<NameValuePair>();//new Dictionary<string, string>();
//    }
//    public int Id { get; set; }
//    public string SKU { get; set; }

//    public bool Alert { get; set; }
//    public int AlertThreshold { get; set; }

//    // public Dictionary<string, string> Attributes { get; set; }
//    public List<NameValuePair> Attributes { get; set; }

//    public Variant ToEntity()
//    {
//        return new Variant()
//        {
//            SKU = SKU,
//            Id = Id,
//            MinStockCountForAlert = AlertThreshold,
//            Alert = Alert,

//        };
//    }

//}