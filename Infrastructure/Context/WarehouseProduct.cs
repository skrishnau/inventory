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
    
    public partial class WarehouseProduct
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public decimal InStockQuantity { get; set; }
        public decimal OnHoldQuantity { get; set; }
        public System.DateTime UpdatedAt { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
