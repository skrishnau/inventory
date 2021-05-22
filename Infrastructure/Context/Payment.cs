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
    
    public partial class Payment
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string UserType { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal Amount { get; set; }
        public decimal DueAmount { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public string PaymentType { get; set; }
        public string PaymentMethod { get; set; }
        public System.DateTime Date { get; set; }
        public string PaidBy { get; set; }
        public string ChequeNo { get; set; }
        public string Bank { get; set; }
        public bool IsVoid { get; set; }
        public Nullable<int> Order_Id { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}
