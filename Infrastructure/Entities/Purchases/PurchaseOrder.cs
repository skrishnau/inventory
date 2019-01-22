using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Purchases
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public int LotNumber { get; set; }
        public int PurchaseLotId { get; set; }
        
    }
}
