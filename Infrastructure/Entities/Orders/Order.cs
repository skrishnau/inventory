using Infrastructure.Entities.Business;
using Infrastructure.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Orders
{
    public class Order
    {
        public int Id { get; set; }
        // Either of Purchase, Sale, Move
        public string OrderType { get; set; }

        #region Common

        public string Name { get; set; }
        // Purchase Order : Order Number
        // Sale Order : Bill Number
        // Move Order : Transfer Number
        public string ReferenceNumber { get; set; }

        // in case of partial receive New Purchase Order is created and earlier is received
        // the newly creaated purchase order will have parent Purchase OrderId
        public int? ParentOrderId { get; set; }
        public virtual Order ParentOrder { get; set; }

        // lot# ; incrementing...
        public int LotNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public string Note { get; set; }
        // Expected Date means different for each Order Type
        // Purchase Order : Expected Date
        // Sale Order : Delivery Date
        // Move Order : Move  Date
        public DateTime ExpectedDate { get; set; }
        // no. of maximum delay days 
        public int? DueDays { get; set; }
        // Verified means different as per order type:
        // Purchase Order : Order Send Date
        // Sale Order : Order Verified Date
        // Move Order : Order Verified Date
        public bool IsVerified { get; set; }
        public DateTime? VerifiedDate { get; set; }
        // cancels
        public bool IsCancelled { get; set; }
        public DateTime? CancelledDate { get; set; }
        // Execution Date means different for each Order Type
        // Purchase Order : Received Date
        // Sale Order : Delivered Date
        // Move Order : Transfered Date
        public bool IsExecuted { get; set; }
        public DateTime? ExecutedDate { get; set; }
        // timestamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string PaymentMethod { get; set; }
        #endregion



        #region Purchase Order

        public int? WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        // supplier's invoice
        public string SupplierInvoice { get; set; }
        // supplier for purchase order only
        public int? SupplierId { get; set; }
        public virtual Suppliers.Supplier Supplier { get; set; }

        #endregion



        #region Sale Order

        public string VatNumber { get; set; }
        public int? CustomerId { get; set; }
        public virtual Customers.Customer Customer { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        #endregion



        #region Move Order

        public int? ToWarehouseId { get; set; }
        public virtual Warehouse ToWarehouse { get; set; }

        #endregion


        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

    }
}
