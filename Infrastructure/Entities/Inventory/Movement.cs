using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    public class Movement
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string Type { get; set; }

        public int? PurchaseOrderId { get; set; }
        public int? TransferId { get; set; }

        // any unique no. associated with the inventory txn. 
        // e.g. For Transfer its transfer No., for PO receive its PO No., etc.
        public string ReceiptNumber { get; set; }
        public string LotNumber { get; set; }

        public decimal Quantity { get; set; }

        public DateTime Date { get; set; }

    }
}
