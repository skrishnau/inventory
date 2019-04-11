using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Purchases
{
    public class PurchaseOrderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OrderNumber { get; set; }
        public int? ParentPurchaseOrderId { get; set; }
        public string ParentPurchaseOrder { get; set; }
        public int LotNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public int WarehouseId { get; set; }
        public string Warehouse { get; set; }
        public string SupplierInvoice { get; set; }
        public int? SupplierId { get; set; }
        public string Supplier { get; set; }
        public DateTime ExpectedDate { get; set; }
        public bool IsOrderSent { get; set; }
        public DateTime? OrderSentDate { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime? CancelledDate { get; set; }
        public bool IsReceived { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string Note { get; set; }

        public string Status { get; set; }
        
        public virtual ICollection<PurchaseOrderItemModel> PurchaseOrderItems { get; set; }


        public PurchaseOrderModel()
        {
            PurchaseOrderItems = new List<PurchaseOrderItemModel>();
        }
    }

    //public class PurchaseOrderModelForGridView
    //{
    //    public int Id { get; set; }

    //    public string ReceiptNo { get; set; }
    //    public string Supplier { get; set; }

    //    public int LotNo { get; set; }

    //    public string OrderDate { get; set; }
    //    public string ReceivedDate { get; set; }

    //    public string TotalAmount { get; set; }
    //    public int ItemsCount { get; set; }

    //    public string Status { get; set; }
    //}
}
