using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    public class Uom
    {
        public int Id { get; set; }
        public string Name { get; set; } // Unit
        public decimal Quantity { get; set; }
        // nullable; if NULL then its the root
        public int? BaseUomId { get; set; }
        public bool Use { get; set; }

        // table Objects //
        public virtual Uom BaseUom { get; set; }
    }
}
