using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Enums
{


    public enum TransactionTypeEnum
    {
        // sale and purcahse transaction type occur when transaction is saved while creating Order
        Sale, 
        Purchase,
        // Credit and Debit transaction type occur when transaction is saved while creating Payment
        Credit,
        Debit
    }
    

    //public enum TransactionTypeEnum
    //{
    //    Incoming,
    //    Outgoing
    //}

    ///// <summary>
    ///// Transaction Type (also called Caption)
    ///// </summary>
    //public enum TransactionTypeEnum
    //{
    //    /// <summary>
    //    /// Journal(direct entry),
    //    /// </summary>
    //    Journal = 0,
    //    /// <summary>
    //    /// Receipt(payment received from Customer), 
    //    /// </summary>
    //    Receipt = 1,
    //    /// <summary>
    //    /// Voucher (payment done to Supplier), 
    //    /// </summary>
    //    Voucher = 2,
    //    /// <summary>
    //    /// Purchase (payment done in direct relation to an order), 
    //    /// </summary>
    //    Purchase = 3,
    //    /// <summary>
    //    /// Sale (payment received in direct relation to an order),
    //    /// </summary>
    //    Sale = 4
    //}

}
