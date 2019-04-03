using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    public class VariantAttribute
    {
        public int Id { get; set; }
        // each variation 
        public int VariantId { get; set; }
        // otpion . e.g. color
        public int ProductAttributeId { get; set; }
        // option's value: e.g. Red
        public string Value { get; set; }

        // ===== Table Objects ===== //
        public virtual Variant Variant { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }



    }
}
