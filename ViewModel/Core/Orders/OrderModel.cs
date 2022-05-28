using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Enums;

namespace ViewModel.Core.Orders
{
    public class OrderListModel
    {
        public List<OrderModel> OrderList { get; set; }

        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int Offset { get; set; }
    }

    public class OrderModel
    {
        public int Id { get; set; }
        public string OrderType { get; set; }
        public OrderOrDirectEnum OrderOrDirect { get; set; }
        public string Status { get; set; }
        #region Common
        public string Name { get; set; }
        public string ReferenceNumber { get; set; }
        public int? ParentOrderId { get; set; }
        public string ParentOrder { get; set; }
        public int LotNumber { get; set; }
        public decimal TotalAmount { get; set; }

        public string Note { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryDateBS { get; set; }
        public int? DueDays { get; set; }

        public bool IsVoid { get; set; }

        public bool IsVerified { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime? CancelledDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CompletedDateBS { get; set; }
        public bool IsReceiptGenerated { get; set; }
        public DateTime? ReceiptGeneratedDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedAtBS { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedAtBS { get; set; }

        // DiscountPercent is not used for now
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public string DiscountString
        {
            get
            {
                var ss =  DiscountPercent > 0
                ? DiscountPercent.ToString("0.0") + " %"
                : DiscountAmount > 0
                ? "Rs " + DiscountAmount.ToString("0.0")
                : string.Empty;
                return ss;
            }
        }
        // payment
        public string PaymentType { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public DateTime? PaymentCompleteDate { get; set; }

        public bool IsCash => PaidAmount >= SumAmount;
        public bool IsCredit => PaidAmount < SumAmount;

        public int PaymentDueDays
        {
            get
            {
                if (PaymentDueDate.HasValue)
                    return (PaymentDueDate.Value.Date - DateTime.Now.Date.AddDays(1)).Days;
                return 0;
            }
        }
        public decimal PaymentDueAmount
        {
            get
            {
                return SumAmount - PaidAmount;
            }
        }

        public int NoOfProducts { get; set; }

        public decimal DueAmount
        {
            get
            {
                //if(DiscountAmount > 0)
                //    return TotalAmount - DiscountAmount - PaidAmount;
                //if (DiscountPercent > 0)
                //    return TotalAmount - ( TotalAmount * DiscountPercent / 100) - PaidAmount;
                return SumAmount - PaidAmount;
            }
        }

        #endregion
        #region Purchase Order
        public int? WarehouseId { get; set; }
        public string Warehouse { get; set; }
        public string SupplierInvoice { get; set; }
        #endregion

        #region Sale Order
        public string VatNumber { get; set; }
        public int? UserId { get; set; }
        public string User { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        #endregion

        #region Move Order
        public int? ToWarehouseId { get; set; }
        public string ToWarehouse { get; set; }
        #endregion


        public int AdjustmentCodeId { get; set; }
        public string AdjustmentCode { get; set; }

        public virtual ICollection<OrderItemModel> OrderItems { get; set; }
        public virtual ICollection<PaymentModel> Payments { get; set; }
        public OrderModel()
        {
            OrderItems = new List<OrderItemModel>();
        }

        /// <summary>
        /// TotalAmount - discount Amount
        /// </summary>
        public decimal SumAmount
        {
            get { return DiscountAmount > 0 ? TotalAmount - DiscountAmount : TotalAmount - (TotalAmount * DiscountPercent / 100); }
        }
    }

    public class OrderEditModel
    {
        public OrderTypeEnum OrderType { get; set; }
        public int OrderId { get; set; }
        public bool ShowPrintView { get; set; }
        public OrderOrDirectEnum OrderOrDirect { get; set; }
    }
    /// <summary>
    /// Order List filter parameters
    /// </summary>
    public class OrderSearchModel
    {
        public OrderTypeEnum OrderType { get; set; }
        public OrderListTypeEnum OrderListType { get; set; }
        public string Client { get; set; }
        public string ReceiptNo { get; set; }
        public int ProductId { get; set; }
        // advance search
        public DateTime? CheckoutDate { get; set; }
        public string CashCredit { get; set; }
    }
    public class TransactionListSummaryModel
    {
        public int TotalCount { get; set; }
        public decimal? TotalTxnAmount { get; set; }
        public decimal? TotalPaidAmount { get; set; }
    }

}
