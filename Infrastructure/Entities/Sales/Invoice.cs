﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Sales
{
    /// <summary>
    /// Invoice is generated againt a sale only. So it has SaleId as non-null foreign key
    /// </summary>
    public class Invoice
    {
        public int Id { get; set; }
        // incrementing number with custom prefix and suffix given by user
        public int InvoiceNo { get; set; }
        /// Invoice againt a sales transaction
        public int SaleId { get; set; }
        // total amount of the invoice. comes from "TotalAmount" of Sale
        public decimal TotalAmount { get; set; }
        /// Invoice may be created at other time than Sale Creation Date
        public DateTime CreatedAt { get; set; }
        // if null then NOT-Deleted ; if not null then deleted
        public DateTime? DeletedAt { get; set; }


        // ================ table objects ================ //
        public virtual Sale Sale { get; set; }


    }
}
