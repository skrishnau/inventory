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
    
    public partial class DepartmentUser
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int UserId { get; set; }
        public Nullable<decimal> BuildRate { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual User User { get; set; }
    }
}
