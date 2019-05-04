using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Orders
{
    class Receipt
    {
        public int Id { get; set; }
        public int ReceiptNo { get; set; }
        public int SupplierId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int BillNo { get; set; } // or string??
        public decimal ReceiptTotal { get; set; }
    }
}
