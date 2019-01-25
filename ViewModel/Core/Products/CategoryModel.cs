using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Products;

namespace ViewModel.Core.Products
{
    public class CategoryModel
    {
        public int Id { get; set; }
        // name of the category; should be unique
        public string Name { get; set; }
        // implement N tier 
        public int? ParentCategoryId { get; set; }

        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // -------------------- Table Objects -------------------- //

        public virtual Category ParentCategory { get; set; }

        public  Category ToEntity()
        {
            return new Category
            {
                CreatedAt = CreatedAt
            };
        }
    }
}
