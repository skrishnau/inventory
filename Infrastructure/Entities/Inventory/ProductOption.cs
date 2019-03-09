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
    public class ProductOption
    {
        public int Id { get; set; }
        // product .. e.g. T-shirt
        public int ProductId { get; set; }
        // option . e.g. "Color", 
        public int OptionId { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Product Product { get; set; }

        public virtual Option Option { get; set; }

    }
}
