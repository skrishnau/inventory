using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Orders
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string OrderType { get; set; }
        public string Status { get; set; }
        #region Common
        public string Name { get; set; }
        public string ReferenceNumber { get; set; }
        public int? ParentOrderId { get; set; }
        public string ParentOrder { get; set; }
        public int LotNumber { get; set; }
        public decimal TotalAmount { get; set; }

        public string Note { get; set; }
        public DateTime ExpectedDate { get; set; }
        public int? DueDays { get; set; }
        public bool IsVerified { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime? CancelledDate { get; set; }
        public bool IsExecuted { get; set; }
        public DateTime? ExecutedDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // DiscountPercent is not used for now
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }

        public decimal PaidAmount { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public DateTime? PaymentCompleteDate { get; set; }

        public decimal RemainingAmount
        {
            get
            {
                if(DiscountAmount > 0)
                    return TotalAmount - DiscountAmount - PaidAmount;
                if (DiscountPercent > 0)
                    return TotalAmount - ( TotalAmount * DiscountPercent / 100) - PaidAmount;
                return TotalAmount - PaidAmount;
            }
        }

        #endregion
        #region Purchase Order
        public int? WarehouseId { get; set; }
        public string Warehouse { get; set; }
        public string SupplierInvoice { get; set; }
        public int? SupplierId { get; set; }
        public string Supplier { get; set; }
        #endregion
      
        #region Sale Order
        public string VatNumber { get; set; }
        public int? CustomerId { get; set; }
        public string Customer { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        #endregion
     
        #region Move Order
        public int? ToWarehouseId { get; set; }
        public string ToWarehouse { get; set; }
        #endregion

        public virtual ICollection<OrderItemModel> OrderItems { get; set; }
        public virtual ICollection<PaymentModel> Payments { get; set; }
        public OrderModel()
        {
            OrderItems = new List<OrderItemModel>();
        }
    }

}
