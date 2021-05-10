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

        // e.g. 1 PackageId Contains 1000 RelatedPackageId
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }

        public decimal Quantity { get; set; }

        public int RelatedPackageId { get; set; }
        public virtual Package RelatedPackage { get; set; }

        public bool Use { get; set; }

        // related to which product; if null then global UOM else if product has value then related to the given product
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }


        /*
         // earlier
        public string Name { get; set; } // Unit
        // nullable; if NULL then its the root
        public int? BaseUomId { get; set; }
        public virtual Uom BaseUom { get; set; }
         */
    }
}
