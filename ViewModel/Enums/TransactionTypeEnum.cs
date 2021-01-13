using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Enums
{
    /// <summary>
    /// Transaction Type (also called Caption)
    /// </summary>
    public enum TransactionTypeEnum
    {
        /// <summary>
        /// Journal(direct entry),
        /// </summary>
        Journal = 0,
        /// <summary>
        /// Receipt(payment received from Customer), 
        /// </summary>
        Receipt = 1,
        /// <summary>
        /// Payment (payment done to Supplier), 
        /// </summary>
        Payment = 2,
        /// <summary>
        /// Purchase (payment done in direct relation to an order), 
        /// </summary>
        Purchase = 3,
        /// <summary>
        /// Sale (payment received in direct relation to an order),
        /// </summary>
        Sale = 4
    }
}
