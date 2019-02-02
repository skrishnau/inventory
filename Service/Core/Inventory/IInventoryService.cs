using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;

namespace Service.Core.Inventory
{
    public interface IInventoryService
    {
        void AddUpdateBrand(BrandModel brand);

        void AddUpdateCategory(CategoryModel category);

        void AddProduct(ProductModel product);

        List<BrandModel> GetBrandList();

        List<CategoryModel> GetCategoryList(int? parentCategoryId);

        List<ProductModel> GetProductList();

        void DeleteCategory(CategoryModel categoryModel);

        CategoryModel GetCategory(string v);
    }
}
