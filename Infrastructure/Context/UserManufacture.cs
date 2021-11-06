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
    
    public partial class UserManufacture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserManufacture()
        {
            this.UserManufactureProducts = new HashSet<UserManufactureProduct>();
        }
    
        public int Id { get; set; }
        public int ManufactureDepartmentUserId { get; set; }
        public Nullable<System.DateTime> StartedAt { get; set; }
        public Nullable<System.DateTime> CompletedAt { get; set; }
        public Nullable<System.DateTime> CancelledAt { get; set; }
        public Nullable<decimal> BuildRate { get; set; }
        public string Remarks { get; set; }
    
        public virtual ManufactureDepartmentUser ManufactureDepartmentUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserManufactureProduct> UserManufactureProducts { get; set; }
    }
}