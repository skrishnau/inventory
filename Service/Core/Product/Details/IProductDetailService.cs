using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Products;

namespace Service.Core.Product.Details
{
    public interface IProductDetailService
    {
        void AddCategory(CategoryModel category);

        void AddProduct(ProductModel product);
    }
}
