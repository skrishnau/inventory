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
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Departments = new HashSet<Department>();
            this.DepartmentUsers = new HashSet<DepartmentUser>();
            this.InventoryUnits = new HashSet<InventoryUnit>();
            this.InventoryUnits1 = new HashSet<InventoryUnit>();
            this.ManufactureDepartments = new HashSet<ManufactureDepartment>();
            this.ManufactureDepartments1 = new HashSet<ManufactureDepartment>();
            this.ManufactureDepartments2 = new HashSet<ManufactureDepartment>();
            this.ManufactureDepartments3 = new HashSet<ManufactureDepartment>();
            this.ManufactureDepartmentUsers = new HashSet<ManufactureDepartmentUser>();
            this.ManufactureDepartmentUsers1 = new HashSet<ManufactureDepartmentUser>();
            this.ManufactureDepartmentUsers2 = new HashSet<ManufactureDepartmentUser>();
            this.ManufactureDepartmentUsers3 = new HashSet<ManufactureDepartmentUser>();
            this.Manufactures = new HashSet<Manufacture>();
            this.Manufactures1 = new HashSet<Manufacture>();
            this.Manufactures2 = new HashSet<Manufacture>();
            this.Manufactures3 = new HashSet<Manufacture>();
            this.Manufactures4 = new HashSet<Manufacture>();
            this.OrderItems = new HashSet<OrderItem>();
            this.Orders = new HashSet<Order>();
            this.Payments = new HashSet<Payment>();
            this.ProductOwnerHistories = new HashSet<ProductOwnerHistory>();
            this.ProductOwnerHistories1 = new HashSet<ProductOwnerHistory>();
            this.ProductOwners = new HashSet<ProductOwner>();
            this.Transactions = new HashSet<Transaction>();
        }
    
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsCompany { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool Use { get; set; }
        public string SalesPerson { get; set; }
        public string DeliveryAddress { get; set; }
        public string UserType { get; set; }
        public bool CanLogin { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Company { get; set; }
        public string Gender { get; set; }
        public string IsMarried { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> PaymentDueDate { get; set; }
        public Nullable<System.DateTime> AllDuesClearDate { get; set; }
        public Nullable<System.DateTime> LastLedgerPrintDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Department> Departments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentUser> DepartmentUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryUnit> InventoryUnits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryUnit> InventoryUnits1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManufactureDepartment> ManufactureDepartments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManufactureDepartment> ManufactureDepartments1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManufactureDepartment> ManufactureDepartments2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManufactureDepartment> ManufactureDepartments3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManufactureDepartmentUser> ManufactureDepartmentUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManufactureDepartmentUser> ManufactureDepartmentUsers1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManufactureDepartmentUser> ManufactureDepartmentUsers2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManufactureDepartmentUser> ManufactureDepartmentUsers3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manufacture> Manufactures { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manufacture> Manufactures1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manufacture> Manufactures2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manufacture> Manufactures3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manufacture> Manufactures4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOwnerHistory> ProductOwnerHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOwnerHistory> ProductOwnerHistories1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOwner> ProductOwners { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
