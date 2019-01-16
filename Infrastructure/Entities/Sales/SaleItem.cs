using Infrastructure.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Sales
{

    /// <summary>
    /// How do we implement discount scheme? 
    /// </summary>
    public class SaleItem
    {
        public int Id { get; set; }
        // to which sale transaction does this item belongs 
        public int SaleId { get; set; }
        // the product
        public int ProductId { get; set; }
        // no of items
        public int Quantity { get; set; }
        // implement discount in rate in version 2
        public decimal Rate { get; set; }
        // totalAmount = quantity * rate 
        public decimal TotalAmount { get; set; }
        // an item can be cancelled by customer at any point during transaction
        public DateTime? DeletedAt { get; set; }

        // ================= Table Objects ==================== //
        public virtual Sale Sale { get; set; }

        public virtual Product Product { get; set; }

    }
}
