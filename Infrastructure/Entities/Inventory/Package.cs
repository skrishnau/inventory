using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    public class Package
    {
        public int Id { get; set; }

        public string Name { get; set; } // Unit
        
        public bool Use { get; set; }

        public ICollection<ProductPackage> ProductPackages { get; set; }
        
    }
}
