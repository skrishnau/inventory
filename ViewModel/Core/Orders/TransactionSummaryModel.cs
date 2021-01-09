using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Enums;

namespace ViewModel.Core.Orders
{
    public class TransactionSummaryModel
    {
        public decimal Value { get; set; }
        public string Key { get; set; }
    }

    public enum TransactionSummaryKeys
    {
        Sale,
        Purchase,
        Customer,
        Product,
        InventoryQuantity
    }
}
