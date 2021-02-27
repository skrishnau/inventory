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
        int GetAllProductsCount(int categoryId, string searchText);
        Task<ProductListModel> GetAllProducts(int categoryId, string searchText, int pageSize, int offset);
        Task<ProductListModel> GetAllProducts();

        List<IdNamePair> GetProductListForCombo();

        ProductModel GetProduct(int productId);
        ProductModel GetProductForEdit(int productId);
        ProductModel GetProductBySKU(string sku);
        ProductModel GetProductByNameOrSKU(string v);
        ProductModel GetProductById(int id);
        List<IdNamePair> GetUnderStockProducts();
        void AddUpdateProduct(ProductModel product);


        // category
        List<IdNamePair> GetAllCategoriesForCombo();
        List<CategoryModel> GetCategoryList(int? parentCategoryId);
        CategoryModel GetCategory(string v);
        void AddUpdateCategory(CategoryModel category);
        void DeleteCategory(CategoryModel categoryModel);
        bool DeleteProduct(int id);
    }
}
