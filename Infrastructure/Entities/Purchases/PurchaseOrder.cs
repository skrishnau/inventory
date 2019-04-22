using Infrastructure.Entities.Business;
using Infrastructure.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Purchases
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReferenceNumber { get; set; }
        // in case of partial receive New Purchase Order is created and earlier is received
        // the newly creaated purchase order will have parent Purchase OrderId
        public int? ParentPurchaseOrderId { get; set; }
        public virtual PurchaseOrder ParentPurchaseOrder { get; set; }
        // lot# ; incrementing...
        public int LotNo { get; set; }
        public decimal TotalAmount { get; set; }
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        // supplier's invoice
        public string SupplierInvoice { get; set; }
        // supplier can be "any"
        public int? SupplierId { get; set; }
        public virtual Suppliers.Supplier Supplier { get; set; }
        // ===== Dates ====== //
        public DateTime ExpectedDate { get; set; }

        // the order date is when the PO is sent
        public bool IsOrderSent { get; set; }
        public DateTime? OrderSentDate { get; set; }
        // cancels/receives
        public bool IsCancelled { get; set; }
        public DateTime? CancelledDate { get; set; }
        public bool IsReceived { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string Note { get; set; }

        // timestamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }


        public PurchaseOrder()
        {
            PurchaseOrderItems = new List<PurchaseOrderItem>();
        }

    }
}
