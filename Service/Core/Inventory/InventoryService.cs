using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Products;

namespace Service.Core.Inventory
{
    public class InventoryService : IInventoryService
    {

        private readonly DatabaseContext context;

        public InventoryService(DatabaseContext context)
        {
            this.context = context;
        }

        public void AddBrand(BrandModel brand)
        {
            var brandEntity = brand.ToEntity();
            brandEntity.CreatedAt = DateTime.Now;
            brandEntity.UpdatedAt = DateTime.Now;
            context.Brand.Add(brandEntity);
            context.SaveChanges();
        }

        public void AddCategory(CategoryModel category)
        {
            var categoryEntity = category.ToEntity();
            context.Category.Add(categoryEntity);
            context.SaveChanges();
        }

        public void AddProduct(ProductModel product)
        {
            var productEntity = product.ToEntity();
            context.Product.Add(productEntity);
            context.SaveChanges();
        }

        public List<BrandModel> GetBrandList()
        {
            var brands = context.Brand
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

        public List<CategoryModel> GetCategoryList()
        {
            var cats = context.Category
                .Where(x => x.DeletedAt == null)
                .Select(x => new CategoryModel()
                {
                    Name = x.Name,
                    ParentCategoryId = x.ParentCategoryId,
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                })
                .ToList();

            return cats;
        }

        public List<ProductModel> GetProductList()
        {
            var cats = context.Product
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
    }
}
