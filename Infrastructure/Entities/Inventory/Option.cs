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
        public string DispalyName { get; set; }
        // types: predefined types "Multiple Choice", "Single Select"
        public string Type { get; set; }

        // json formatted values. This column is used to store values in case of multiple choice type
        // e.g. for Color the values can be Black, Blue and Red, for Size the values can be XL, L, SM
        public string Values { get; set; }
        

    }
}
