using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    public class ProductVariantValue
    {
        public int Id { get; set; }
        // each variation 
        public int ProductVariantId { get; set; }
        // otpion . e.g. color
        public int OptionId { get; set; }
        // option's value: e.g. Red
        public string Value { get; set; }


        // ===== Table Objects ===== //
        public virtual ProductVariant ProductVariant { get; set; }

        public virtual Option Option { get; set; }
    }
}
