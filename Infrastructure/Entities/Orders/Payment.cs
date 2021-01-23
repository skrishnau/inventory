using Infrastructure.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Orders
{
    public class Payment
    {
        public int Id { get; set; }

        //public int? OrderId { get; set; }
        //public virtual Order Order { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        // required 
        [Required]
        public string UserType { get; set; }

        public string ReferenceNumber { get; set; }

        public decimal Amount { get; set; }
        public decimal DueAmount { get; set; }
        public DateTime? DueDate { get; set; }
        /// <summary>
        /// Incoming, Outgoing
        /// </summary>
        public string PaymentType { get; set; }
        /// <summary>
        /// Cash, Cheque, Draft, Advance
        /// </summary>
        public string PaymentMethod { get; set; }

        public DateTime Date { get; set; }
        public string PaidBy { get; set; }
        /// <summary>
        /// If PaymentMethod is Cheque
        /// </summary>
        public string ChequeNo { get; set; }
        public string Bank { get; set; }

        public bool IsVoid { get; set; }
        
    }
}
