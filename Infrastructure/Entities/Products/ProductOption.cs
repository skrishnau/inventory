using Infrastructure.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Products
{
    /// <summary>
    /// The options(attributes) that a product has; These options will have values 
    /// when product variant is created. in return those values will be used to generate SKU
    /// </summary>
    public class ProductOption
    {
        public int Id { get; set; }
        // to which product this sku belongs to 
        public int ProductId { get; set; }
       
        public int OptionId { get; set; }

        // json formatted values of the option; user many add additional values for product specific
        public string Values { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // ============ Table objects ============ //
        public virtual Product Product{ get; set; }
        public virtual Option Option { get; set; }
    }
}
