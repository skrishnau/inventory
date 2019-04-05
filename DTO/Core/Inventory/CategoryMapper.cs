using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Inventory;
using ViewModel.Core.Inventory;

namespace DTO.Core.Inventory
{
    public static class CategoryMapper
    {
        public static CategoryModel MapToCategoryModel(Category category)
        {
            return new CategoryModel()
            {
                CreatedAt = category.CreatedAt,
                DeletedAt = category.DeletedAt,
                Id = category.Id,
                Name = category.Name,
                //ParentCategory = category.
                ParentCategoryId = category.ParentCategoryId,
                ParentCategory = category.ParentCategory==null ? "": category.ParentCategory.Name, 
                UpdatedAt = category.UpdatedAt,
                //SuCategories = 
            };
        }

    }
}
