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

        void AddUpdateProduct(ProductModelForSave product);


        List<BrandModel> GetBrandList();

        List<CategoryModel> GetCategoryList(int? parentCategoryId);

        List<ProductModelForSave> GetProductList();

        List<ProductModelForGridView> GetProductListForGridView();

        void DeleteCategory(CategoryModel categoryModel);

        CategoryModel GetCategory(string v);

        ProductModelForGridView GetProduct(int productId);

        ProductModelForSave GetProductForEdit(int productId);

        //List<AttributeModel> GetAttributeList();

        // List<OptionModel> GetDistinctAttributes();

        // List<OptionModel> GetOptionList();

        // void DeleteAttribute(AttributeModel attributeModel);

        // List<AttributeModel> GetOptionList(int productId);

        void SaveVariant(VariantModel variantModel);


        List<VariantModel> GetVariantList();

        VariantModel GetVariantBySKU(string sku);

        void SaveUom(UomModel data);

        VariantModel GetVariantById(string sku);

        void DeleteProduct(int id);

        List<UomModel> GetUomList();

        string SavePackage(PackageModel package);

        List<PackageModel> GetPackageList();


        //        bool AddOrUpdateAttribute(AttributeModel attributeModel);

    }
}

