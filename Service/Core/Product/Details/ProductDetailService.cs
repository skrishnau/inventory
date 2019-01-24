using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Products;

namespace Service.Core.Product.Details
{
    public class ProductDetailService : IProductDetailService
    {
        

        public ProductDetailService()
        {
            
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
    }
}
