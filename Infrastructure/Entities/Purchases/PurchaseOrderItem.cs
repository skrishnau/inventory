using Infrastructure.Entities.Business;
using Infrastructure.Entities.Inventory;
using Infrastructure.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Purchases
{
    public class PurchaseOrderItem
    {
        public int Id { get; set; }
        // to which purchase transaction does this item belongs 
        public int PurchaseOrderId { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        // the product
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        // the warehouse
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        // no of items
        public decimal Quantity { get; set; }
        // implement discount in rate in version 2
        public decimal Rate { get; set; }
        // totalAmount = quantity * rate 
        public decimal TotalAmount { get; set; }

        public bool IsReceived { get; set; }
        public bool IsHold { get; set; }

        // in next version
        //public decimal Discount { get; set; }
        //public decimal Tax { get; set; }

        public DateTime? ExpirationDate { get; set; }
        public DateTime? ProductionDate { get; set; }

        public int LotNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public string Adjustment { get; set; }
        
        public int? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        

        // items will be hard deleted; if the items need to be removed after "Sent" then cancel the whole order
        // an item can be cancelled by customer at any point during transaction
        // public DateTime? DeletedAt { get; set; }

        // ================= Table Objects ==================== //

    }
}
