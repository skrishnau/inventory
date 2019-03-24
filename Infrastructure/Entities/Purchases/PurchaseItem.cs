using Infrastructure.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Purchases
{
    public class PurchaseItem
    {
        public int Id { get; set; }
        // to which purchase transaction does this item belongs 
        public int PurchaseId { get; set; }
        // the product
        public int VariantId { get; set; }
        // no of items
        public decimal Quantity { get; set; }
        // implement discount in rate in version 2
        public decimal Rate { get; set; }
        // totalAmount = quantity * rate 
        public decimal TotalAmount { get; set; }
        // an item can be cancelled by customer at any point during transaction
        public DateTime? DeletedAt { get; set; }

        // ================= Table Objects ==================== //
        public virtual Purchase Purchase { get; set; }

        public virtual Variant Variant{ get; set; }
    }
}
