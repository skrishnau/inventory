using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Products;

namespace Service.Core.Product.Details
{
    public class ProductService : IProductService
    {

        public ProductService()
        {

        }

        public void AddBrand(BrandModel brand)
        {
            using (var context = new DatabaseContext())
            {

                var brandEntity = brand.ToEntity();
                brandEntity.CreatedAt = DateTime.Now;
                brandEntity.UpdatedAt = DateTime.Now;
                context.Brand.Add(brandEntity);
                context.SaveChanges();
            }
        }

        public void AddCategory(CategoryModel category)
        {
            using (var context = new DatabaseContext())
            {
                var categoryEntity = category.ToEntity();
                context.Category.Add(categoryEntity);
                context.SaveChanges();
            }
        }

        public void AddProduct(ProductModel product)
        {
            using (var context = new DatabaseContext())
            {
                var productEntity = product.ToEntity();
                context.Product.Add(productEntity);
                context.SaveChanges();
            }
        }

        public List<BrandModel> GetBrandList()
        {
            using (var context = new DatabaseContext())
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
        }

        public List<CategoryModel> GetCategoryList()
        {
            using (var context = new DatabaseContext())
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
        }

        public List<ProductModel> GetProductList()
        {
            using (var context = new DatabaseContext())
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
}
