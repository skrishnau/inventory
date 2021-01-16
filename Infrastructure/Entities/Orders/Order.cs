using Infrastructure.Entities.Accounts;
using Infrastructure.Entities.Business;
using Infrastructure.Entities.Inventory;
using Infrastructure.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Orders
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
            Payments = new List<Payment>();
            Transactions = new List<Transaction>();
        }

        public int Id { get; set; }
        // Either of Purchase, Sale, Move
        public string OrderType { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

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
        public DateTime DeliveryDate { get; set; }
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
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool IsReceiptGenerated { get; set; }
        public DateTime? ReceiptGeneratedDate { get; set; }
        // timestamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }

        public string PaymentType { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public DateTime? PaymentCompleteDate { get; set; }

        #endregion



        #region Purchase Order

        public int? WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        // supplier's invoice
        public string SupplierInvoice { get; set; }
        

        #endregion



        #region Sale Order

        public string VatNumber { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        #endregion



        #region Move Order

        public int? ToWarehouseId { get; set; }
        public virtual Warehouse ToWarehouse { get; set; }

        #endregion


        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }


    }
}
