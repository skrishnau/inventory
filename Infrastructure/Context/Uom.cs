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
    
    public partial class Uom
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public bool Use { get; set; }
        public int PackageId { get; set; }
        public int RelatedPackageId { get; set; }
        public Nullable<int> ProductId { get; set; }
    
        public virtual Package Package { get; set; }
        public virtual Package Package1 { get; set; }
        public virtual Product Product { get; set; }
    }
}