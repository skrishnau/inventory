using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Core;
using ViewModel.Core.Common;
using ViewModel.Core.Inventory;
using ViewModel.Enums;

namespace Service.Interfaces
{
    public interface IProductService
    {
        int GetAllProductsCount(int categoryId, string searchText);
        Task<ProductListModel> GetAllProducts(int categoryId, string searchText, int pageSize, int offset);
        Task<ProductListModel> GetAllProducts();

        List<IdNamePair> GetProductListForCombo(int categoryId = 0, List<ProductTypeEnum> productTypes = null);
        List<IdNamePair> GetBuildProductListForCombo(int categoryId = 0);

        ProductModel GetProduct(int productId);
        ProductModel GetProductForEdit(int productId);
        ProductModel GetProductBySKU(string sku);
        ProductModel GetProductByNameOrSKU(string v);//, int orderId
        ProductModel GetProductById(int id);//, int orderId
        List<IdNamePair> GetUnderStockProducts();
        string AddUpdateProduct(ProductModel product);


        // category
        List<IdNamePair> GetAllCategoriesForCombo();
        List<CategoryModel> GetCategoryList(int? parentCategoryId);
        CategoryModel GetCategory(string v);
        void AddUpdateCategory(CategoryModel category);
        ResponseModel<CategoryModel> DeleteCategory(CategoryModel categoryModel);
        bool DeleteProduct(int id);
        List<PriceHistoryModel> GetPriceHistory(int productId);
        //List<RateModel> GetPriceHistory(int productId, DateTime? date, OrderTypeEnum? type);
        List<PriceHistoryModel> GetPriceHistory(int productId, DateTime? date, OrderTypeEnum? type);
        PriceHistoryModel GetPrice(int id, DateTime date, MovementTypeEnum movementType, int packageId, string package);

        // price History
        void AddPriceHistoryWithoutCommit(Product product, decimal rate, string orderType, DateTime? completedDate, Package package, int? packageId);
        ResponseModel<bool> SavePriceHistory(List<InventoryUnitModel> data, DateTime date, OrderTypeEnum type);
        List<IdNamePair> GetPackagesOfProduct(int productId);
        // for assigning product's instock quantity from order items while editing completed transaction
        //decimal AssignInStockQuantityBasedOnOrderForTxnEdit(DatabaseContext _context, ProductModel product, int orderId, Order order);
    }
}
