using Infrastructure.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Sales
{
    /// <summary>
    /// Each transaction
    /// A transaction is started by creating a Sale 
    /// </summary>
    public class Sale
    {
        public int Id { get; set; }
        // we may not know the customer during sale
        public int? CustomerId { get; set; }
        // invoice is not yet created when Sale is created
        public int? InvoiceId { get; set; }
        // Caluculated sum of amount of each Sale item
        public decimal TotalAmount { get; set; }
        // created Date
        public DateTime CreatedAt { get; set; }
        // if null then this data is not deleted; if NOT null then this data is deleted
        public DateTime? DeletedAt { get; set; }


        //============= table objects ===============//

        public virtual Customer Customer { get; set; }

        public virtual Invoice Invoice { get; set; }



    }
}
