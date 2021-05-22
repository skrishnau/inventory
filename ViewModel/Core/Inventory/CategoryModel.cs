using System;
using System.Collections.Generic;
using Infrastructure.Context;

namespace ViewModel.Core.Inventory
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            SuCategories = new List<CategoryModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        
        public int? ParentCategoryId { get; set; }
        public string ParentCategory { get; set; }
        public List<CategoryModel> SuCategories { get; set; }
        
        // time stamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // -------------------- Table Objects -------------------- //


        public  Category ToEntity()
        {
            return new Category
            {
                CreatedAt = CreatedAt,
                DeletedAt = DeletedAt,
                UpdatedAt = UpdatedAt,
                ParentCategoryId = ParentCategoryId,
                Name = Name,
                Id = Id,
            };
        }
    }
}
