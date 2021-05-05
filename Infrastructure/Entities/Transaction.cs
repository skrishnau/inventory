using Infrastructure.Entities.Orders;
using Infrastructure.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Transaction
    {

        public Transaction()
        {
            TransactionItems = new List<TransactionItem>();
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public int? OrderId { get; set; }
        public virtual Order Order { get; set; } 

        public string Particulars { get; set; }

        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
       
        /// <summary>
        /// Balance is positively stored. To get actual balance multiply Balance with DrCr to get amount in Debit or Credit form
        /// Debit is negative and Credit is positive
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// In case of Sale, it's the total cost price of the items
        /// </summary>
        public decimal? CostPriceTotal { get; set; }
        /// <summary>
        /// -1: Dr , 1:Cr for Balance
        /// </summary>
        public int DrCr { get; set; } // 

        /// <summary>
        /// Transaction Type also: called Caption
        /// e.g. 
        /// Journal(direct entry), 
        /// Receipt(payment received from Customer), 
        /// Payment (payment done to Supplier), 
        /// Purchase (payment done in direct relation to an order), 
        /// Sale (payment received in direct relation to an order),
        /// </summary>
        public string Type { get; set; }
        public bool IsVoid { get; set; }

        public virtual ICollection<TransactionItem> TransactionItems { get; set; }
        
    }
}
