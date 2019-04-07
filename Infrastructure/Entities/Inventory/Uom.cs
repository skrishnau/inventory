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
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        // nullable; if NULL then its the root
        public int? BaseUnitId { get; set; }
        public bool Use { get; set; }

        // table Objects //
        public Uom BaseUnit { get; set; }
    }
}
