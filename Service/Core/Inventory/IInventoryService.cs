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
        List<BrandModel> GetBrandList();
        void AddUpdateBrand(BrandModel brand);

        List<CategoryModel> GetCategoryList(int? parentCategoryId);
        CategoryModel GetCategory(string v);
        void AddUpdateCategory(CategoryModel category);
        void DeleteCategory(CategoryModel categoryModel);

        List<ProductModelForGridView> GetProductListForGridView();
        ProductModelForGridView GetProduct(int productId);
        ProductModel GetProductForEdit(int productId);
        List<ProductModel> GetProductList();
        ProductModel GetProductBySKU(string sku);
        void AddUpdateProduct(ProductModel product);
        void DeleteProduct(int id);

        //List<AttributeModel> GetAttributeList();
        // List<OptionModel> GetDistinctAttributes();
        // List<OptionModel> GetOptionList();
        // void DeleteAttribute(AttributeModel attributeModel);
        // List<AttributeModel> GetOptionList(int productId);

        //VariantModel GetVariantById(string sku);
        //List<VariantModel> GetVariantList();
        //VariantModel GetVariantBySKU(string sku);
        //void SaveVariant(VariantModel variantModel);

        List<UomModel> GetUomList();
        List<UomModel> GetUomListUsableOnly();
        void SaveUom(UomModel data);

        List<PackageModel> GetPackageList();
        List<PackageModel> GetPackageListUsableOnly();
        string SavePackage(PackageModel package);

        List<AdjustmentCodeModel> GetAdjustmentCodeList();
        List<AdjustmentCodeModel> GetAdjustmentCodeListUsableOnly();
        string SaveAdjustmentCode(AdjustmentCodeModel model);


        //        bool AddOrUpdateAttribute(AttributeModel attributeModel);

    }
}

