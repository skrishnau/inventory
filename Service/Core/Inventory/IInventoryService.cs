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

        List<ProductModelForGridView> GetProductListForGridView();

        void DeleteCategory(CategoryModel categoryModel);

        CategoryModel GetCategory(string v);

        bool AddOrUpdateAttribute(AttributeModel attributeModel);

        ProductModelForGridView GetProduct(int productId);

        List<AttributeModel> GetAttributeList();

        List<OptionModel> GetDistinctAttributes();

        List<OptionModel> GetOptionList();

        void DeleteAttribute(AttributeModel attributeModel);

        List<AttributeModel> GetOptionList(int productId);

        void SaveVariant(VariantModel variantModel);

        List<VariantModel> GetVariantList();

        VariantModel GetVariantBySKU(string sku);

        VariantModel GetVariantById(string sku);


    }
}
