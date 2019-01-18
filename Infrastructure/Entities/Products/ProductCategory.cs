using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Products
{
    /// <summary>
    /// Category; e.g. Electronics, Watch,  Mobile, Tablets, Computer, Laptop...
    /// </summary>
    public class ProductCategory
    {
        public int Id { get; set; }
        // name of the category; should be unique
        public string Name { get; set; }
        // implement N tier 
        public int? ParentProductCategoryId { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


        // -------------------- Table Objects -------------------- //

        public virtual ProductCategory ParentProductCategory { get; set; }
    }
}
