﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Enums;

namespace ViewModel.Core.Orders
{
    public class PaymentModel
    {
        public int Id { get; set; }

        public int? OrderId { get; set; }
        public int? UserId { get; set; }
        public string Order { get; set; }
        public string User { get; set; }

        /// <summary>
        /// Dr amt in case of sales , Cr amt in case of purchase
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// Paid Amount
        /// Cr amt in case of sales, Dr. amt in case of purchase
        /// </summary>
        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }
        public DateTime Date { get; set; }
        public string PaidBy { get; set; }
        /// <summary>
        /// If PaymentMethod is Cheque
        /// </summary>
        public string ChequeNo { get; set; }


    }
}
