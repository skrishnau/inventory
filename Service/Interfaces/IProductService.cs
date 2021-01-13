using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Common;
using ViewModel.Core.Inventory;

namespace Service.Interfaces
{
    public interface IProductService
    {
        List<IdNamePair> GetProductListForCombo();
        List<ProductModel> GetProductListForGridView();
        ProductModel GetProduct(int productId);
        ProductModel GetProductForEdit(int productId);
        ProductModel GetProductBySKU(string sku);
        ProductModel GetProductByNameOrSKU(string v);
        ProductModel GetProductById(int id);
        List<IdNamePair> GetUnderStockProducts();
        void AddUpdateProduct(ProductModel product);


        // category
        List<CategoryModel> GetCategoryList(int? parentCategoryId);
        CategoryModel GetCategory(string v);
        void AddUpdateCategory(CategoryModel category);
        void DeleteCategory(CategoryModel categoryModel);
    }
}
