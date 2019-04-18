using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO.AutoMapperBase;
using Infrastructure.Entities.Inventory;
using ViewModel.Core.Inventory;

namespace DTO.Core.Inventory
{
    public static class CategoryMapper
    {
        public static CategoryModel MapToCategoryModel(Category category)
        {
            return Mappings.Mapper.Map<CategoryModel>(category);
        }
    }

    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>();
        }
    }
}


//public static CategoryModel MapToCategoryModel(Category category)
//{
//    return new CategoryModel()
//    {
//        CreatedAt = category.CreatedAt,
//        DeletedAt = category.DeletedAt,
//        Id = category.Id,
//        Name = category.Name,
//        //ParentCategory = category.
//        ParentCategoryId = category.ParentCategoryId,
//        ParentCategory = category.ParentCategory==null ? "": category.ParentCategory.Name, 
//        UpdatedAt = category.UpdatedAt,
//        //SuCategories = 
//    };
//}
