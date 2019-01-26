using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Products;

namespace Service.Core.Product.Details
{
    public interface IProductService
    {
        void AddBrand(BrandModel brand);

        void AddCategory(CategoryModel category);

        void AddProduct(ProductModel product);

        List<BrandModel> GetBrandList();
        List<CategoryModel> GetCategoryList();
        List<ProductModel> GetProductList();
    }
}
