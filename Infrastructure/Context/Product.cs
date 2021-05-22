//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infrastructure.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.InventoryUnits = new HashSet<InventoryUnit>();
            this.Movements = new HashSet<Movement>();
            this.OrderItems = new HashSet<OrderItem>();
            this.PriceHistories = new HashSet<PriceHistory>();
            this.ProductAttributes = new HashSet<ProductAttribute>();
            this.ProductPackages = new HashSet<ProductPackage>();
            this.Products1 = new HashSet<Product>();
            this.Uoms = new HashSet<Uom>();
            this.WarehouseProducts = new HashSet<WarehouseProduct>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Barcode { get; set; }
        public bool Use { get; set; }
        public bool HasVariants { get; set; }
        public bool IsVariant { get; set; }
        public Nullable<int> ParentProductId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public bool IsDiscontinued { get; set; }
        public decimal UnitsInPackage { get; set; }
        public decimal UnitNetWeight { get; set; }
        public decimal UnitGrossWeight { get; set; }
        public bool IsBuy { get; set; }
        public bool IsSell { get; set; }
        public bool IsBuild { get; set; }
        public bool IsNotMovable { get; set; }
        public Nullable<int> WarehouseId { get; set; }
        public decimal ReorderPoint { get; set; }
        public decimal ReorderQuantity { get; set; }
        public bool ReorderAlert { get; set; }
        public int LeadDays { get; set; }
        public decimal EOQ { get; set; }
        public decimal MonthlyDemand { get; set; }
        public decimal InStockQuantity { get; set; }
        public decimal OnHoldQuantity { get; set; }
        public decimal CommittedQuantity { get; set; }
        public decimal OnOrderQuantity { get; set; }
        public decimal SupplyPrice { get; set; }
        public decimal MarkupPercent { get; set; }
        public decimal RetailPrice { get; set; }
        public string Manufacturer { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string AttributesJSON { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryUnit> InventoryUnits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movement> Movements { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PriceHistory> PriceHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPackage> ProductPackages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products1 { get; set; }
        public virtual Product Product1 { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uom> Uoms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseProduct> WarehouseProducts { get; set; }
    }
}
