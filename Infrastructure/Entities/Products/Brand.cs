using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Products
{
    /// <summary>
    /// Brands; e.g. Xiaomi, Samsung, Nike; They have many products
    /// </summary>
   public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? DeletedAt { get; set; }


    }
}
