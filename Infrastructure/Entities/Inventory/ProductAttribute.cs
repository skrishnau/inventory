using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    /// <summary>
    /// This table stores various options for a product... e.g. T-shirt may have options: Color, Size, Fabric, etc.
    /// </summary>
    public class ProductAttribute
    {
        public int Id { get; set; }
        // product .. e.g. T-shirt
        public int ProductId { get; set; }
        // attribute . e.g. "Color", "Fabric", "Style" , etc.
        public string Attribute { get; set; }
        
        public virtual Product Product { get; set; }
        public virtual ICollection<VariantAttribute> VariantAttributes { get; set; }

    }
}
