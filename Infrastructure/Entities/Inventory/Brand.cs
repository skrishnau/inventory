using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    /// <summary>
    /// Brands; e.g. Xiaomi, Samsung, Nike; They have many products
    /// </summary>
   [Obsolete("Brand table is not used anymore", true)]
   public class Brand
    {
        public int Id { get; set; }
        // brand name
        public string Name { get; set; }

        public int ProductId { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Product Product { get; set; } 
    }

}
