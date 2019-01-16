using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Sales
{
    /// <summary>
    /// For Orders. i.e. for transactions that are pre-ordered. (i.e. not on the spot)
    /// Need to record Sales Order because it has different process than sales from shop
    /// </summary>
    public class SaleOrder
    {
        public int Id { get; set; }
        // always incrementing order number
        public int OrderNumber { get; set; }

        // ... still needs implementations

    }
}
