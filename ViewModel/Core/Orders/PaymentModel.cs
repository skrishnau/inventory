using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Enums;

namespace ViewModel.Core.Orders
{

    public class PaymentListModel
    {
        public List<PaymentModel> DataList { get; set; }

        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int Offset { get; set; }
    }

    public class PaymentModel
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        public string User { get; set; }
        public string Company { get; set; }
        public string UserType { get; set; }

        //public int? OrderId { get; set; }
        //public string Order { get; set; }

        public string ReferenceNumber { get; set; }
        /// <summary>
        /// Dr amt in case of sales , Cr amt in case of purchase
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// Paid Amount
        /// Cr amt in case of sales, Dr. amt in case of purchase
        /// </summary>
        public decimal Amount { get; set; }

        // incoming , outgoing
        public string PaymentType{ get; set; }
        // cash, cheque, draft, advance
        public string PaymentMethod { get; set; }
        public DateTime Date { get; set; }
        public string PaidBy { get; set; }
        /// <summary>
        /// If PaymentMethod is Cheque
        /// </summary>
        public string ChequeNo { get; set; }
        public string Bank { get; set; }
        // 
        public decimal DueAmount { get; set; }
        public DateTime? DueDate { get; set; }

        public bool IsVoid { get; set; }

    }
}
