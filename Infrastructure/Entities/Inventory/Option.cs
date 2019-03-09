using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    /// <summary>
    /// Product's variant types are stored in this table
    /// Some data are seeded at initial, like: Color, Size, Swatch; user can add more later
    /// </summary>
    public class Option
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<ProductOption> ProductOptions{ get; set; }
    }
}
