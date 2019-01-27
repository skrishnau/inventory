using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;

namespace Service.Core.Inventory
{
    public class InventoryService : IInventoryService
    {

        private readonly DatabaseContext _context;

        public InventoryService(DatabaseContext context)
        {
            this._context = context;
        }

        public void AddUpdateBrand(BrandModel brand)
        {
            var dbEntity = _context.Brand.FirstOrDefault(x => x.Id == brand.Id);
            if (dbEntity == null)
            {
                var brandEntity = brand.ToEntity();
                brandEntity.CreatedAt = DateTime.Now;
                brandEntity.UpdatedAt = DateTime.Now;
                _context.Brand.Add(brandEntity);
            }
            else
            {
                dbEntity.Name = brand.Name;
                dbEntity.UpdatedAt = DateTime.Now; // brand.UpdatedAt;
            }
            _context.SaveChanges();
        }

        public void AddUpdateCategory(CategoryModel category)
        {
            var dbEntity = _context.Category.FirstOrDefault(x => x.Id == category.Id);
            if (dbEntity == null)
            {
                var categoryEntity = category.ToEntity();
                _context.Category.Add(categoryEntity);
            }
            else
            {
                dbEntity.Name = category.Name;
                dbEntity.UpdatedAt = DateTime.Now; // category.UpdatedAt;
            }
            _context.SaveChanges();
        }

        public void AddProduct(ProductModel product)
        {
            var productEntity = product.ToEntity();
            _context.Product.Add(productEntity);
            _context.SaveChanges();
        }

        public List<BrandModel> GetBrandList()
        {
            var brands = _context.Brand
                .Where(x => x.DeletedAt == null)
                .Select(x => new BrandModel()
                {
                    Name = x.Name,
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                })
                .ToList();

            return brands;
        }

        public List<CategoryModel> GetCategoryList(int? parentCateogryId)
        {
            var cats = _context.Category
                .Where(x => x.DeletedAt == null && x.ParentCategoryId == parentCateogryId)
                .Select(x => new CategoryModel()
                {
                    Name = x.Name,
                    ParentCategoryId = x.ParentCategoryId,
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    ParentCategory = (x.ParentCategory == null? "": x.ParentCategory.Name)

                }).ToList();

            foreach(var cat in cats)
            {
                cat.SuCategories = GetCategoryList(cat.Id);  // TODO:: use property "SubCategories" of the entity instead of recursive call
            }
            return cats;
        }

        //public List<CategoryModel> GetSubCategoryList(int parentCategoryId)
        //{

        //}

        public List<ProductModel> GetProductList()
        {
            var cats = _context.Product
                .Where(x => x.DeletedAt == null)
                .Select(x => new ProductModel()
                {
                    Name = x.Name,
                    BrandId = x.BrandId,
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                })
                .ToList();

            return cats;
        }

        public void DeleteCategory(CategoryModel categoryModel)
        {
            var dbEntity = _context.Category.FirstOrDefault(x => x.Id == categoryModel.Id);
            if (dbEntity != null)
            {
                dbEntity.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public void DeleteBrand(BrandModel brandModel)
        {
            var dbEntity = _context.Brand.FirstOrDefault(x => x.Id == brandModel.Id);
            if (dbEntity != null)
            {
                dbEntity.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public void DeleteProduct(ProductModel produtModel)
        {
            var dbEntity = _context.Product.FirstOrDefault(x => x.Id == produtModel.Id);
            if (dbEntity != null)
            {
                dbEntity.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }
    }
}
