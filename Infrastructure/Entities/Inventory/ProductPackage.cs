using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    public class ProductPackage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }

        public bool IsBasePackage { get; set; }

    }
}
