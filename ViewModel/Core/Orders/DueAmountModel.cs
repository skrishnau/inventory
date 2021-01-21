using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Orders
{
    public class DueAmountModel
    {
        public string User { get; set; }
        public string DueAmount { get; set; }
        public string TransactionAmount { get; set; }
        public string PaidAmount { get; set; }
        public string DueDate { get; set; }
        public int DueDays { get; set; }
    }
}
