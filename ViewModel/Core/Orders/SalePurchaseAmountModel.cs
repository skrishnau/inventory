using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Orders
{
    public class SalePurchaseAmountModel
    {
        public decimal SaleAmount { get; set; }
        public decimal PurchaseAmount { get; set; }
        public string Date { get; set; }
    }
}
