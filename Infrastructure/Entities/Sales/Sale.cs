﻿using Infrastructure.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Sales
{
    /// <summary>
    /// Each transaction. A transaction is started by creating a Sale.
    ///     and ended by creating invoice number
    /// </summary>
    public class Sale
    {
        public int Id { get; set; }
       
        // invoice is not yet created when Sale is created
        // incrementing number with custom prefix and suffix given by user
        // will be generated as per the settings and the last Invoice number
        public string InvoiceNo { get; set; }

        public string VatNo { get; set; }

        // we may not know the customer during sale
        public int? CustomerId { get; set; }
        //public string BillNo { get; set; }
        // public string VatNo { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Date { get; set; }


        // Caluculated sum of amount of each Sale item
        public decimal Total { get; set; }
        // created Date
        public DateTime CreatedAt { get; set; }
        // if null then this data is not deleted; if NOT null then this data is deleted
        public DateTime? DeletedAt { get; set; }

        //============= table objects ===============//

        public virtual Customer Customer { get; set; }
        public virtual ICollection<SaleItem> SaleItems { get; set; }


    }
}
