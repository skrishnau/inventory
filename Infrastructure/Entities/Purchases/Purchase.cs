using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Purchases
{
    /// <summary>
    /// All information realted to purchase 
    /// </summary>
    public class Purchase
    {
        public int Id { get; set; }
        // we may not know the supplier in case of direct purchase
        public int? SupplierId { get; set; }
        // receipt is not yet created when Purchase is created...
        // incrementing number with custom prefix and suffix given by user
        // will be generated as per the settings and the last Invoice number
        public string ReceiptNo { get; set; }
        
        // Caluculated sum of amount of each purchase item
        public decimal TotalAmount { get; set; }
        // created Date
        public DateTime CreatedAt { get; set; }
        // if null then this data is not deleted; if NOT null then this data is deleted
        public DateTime? DeletedAt { get; set; }

        //============= table objects ===============//

        public virtual Suppliers.Supplier Supplier { get; set; }
    }
}
