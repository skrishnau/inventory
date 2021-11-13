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
    
    public partial class ManufactureDepartmentUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ManufactureDepartmentUser()
        {
            this.UserManufactures = new HashSet<UserManufacture>();
        }
    
        public int Id { get; set; }
        public int ManufactureDepartmentId { get; set; }
        public int UserId { get; set; }
        public Nullable<decimal> BuildRate { get; set; }
    
        public virtual ManufactureDepartment ManufactureDepartment { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserManufacture> UserManufactures { get; set; }
    }
}
