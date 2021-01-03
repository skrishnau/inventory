using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Orders
{
    public class Payment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime Date { get; set; }
        public string PaidBy { get; set; }
        /// <summary>
        /// If PaymentMethod is Cheque
        /// </summary>
        public string ChequeNo { get; set; }
        
    }
}
