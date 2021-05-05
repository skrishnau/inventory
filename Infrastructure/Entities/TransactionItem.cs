using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    /// <summary>
    /// Only used to store Transaction Items of Sale in order to track which Inventory 
    /// Item is given as sale for use in zero rate case to update the cost price after rate is updated
    /// </summary>
    public class TransactionItem
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public virtual Transaction Transaction { get; set; }

        // Purchase Order Item Id from inventory Unit
        public int? PurchaseOrderItemId { get; set; }
        public virtual Orders.OrderItem PurchaseOrderItem { get; set; }

        // Order Item of the sale
        public int? SaleOrderItemId { get; set; }
        public virtual Orders.OrderItem SaleOrderItem { get; set; }

        public decimal UnitQuantity { get; set; }
        public decimal CostPriceRate { get; set; }
        public decimal CostPriceTotal { get; set; }
    }
}
