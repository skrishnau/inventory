using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Common;
using ViewModel.Core.Inventory;
using ViewModel.Core.Purchases;

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

        List<ProductModel> GetProductListForGridView();
        ProductModel GetProduct(int productId);
        ProductModel GetProductForEdit(int productId);
        List<IdNamePair> GetProductIdNameList();
        ProductModel GetProductBySKU(string sku);
        void AddUpdateProduct(ProductModel product);
        List<IdNamePair> GetAdjustmentCodeListForCombo();
        List<IdNamePair> GetPositiveAdjustmentCodeListForCombo();
        List<IdNamePair> GetNegativeAdjustmentCodeListForCombo();
        void DeleteProduct(int id);

        List<InventoryUnitModel> GetInventoryUnitList();


        List<UomModel> GetUomList();
        List<UomModel> GetUomListUsableOnly();
        List<WarehouseProductModel> GetWarehouseProductList(int warehouseId, int productId);
        void SaveUom(UomModel data);

        List<PackageModel> GetPackageList();
        void MoveInventoryUnits(int warehouseId, List<InventoryUnitModel> dataList);
        List<PackageModel> GetPackageListUsableOnly();
        string SavePackage(PackageModel package);

        List<AdjustmentCodeModel> GetAdjustmentCodeList();
        List<AdjustmentCodeModel> GetAdjustmentCodeListUsableOnly();
        string SaveAdjustmentCode(AdjustmentCodeModel model);

        // ===== Inventory Units ====== //
        void MergeInventoryUnits(List<InventoryUnitModel> list);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="splitRule">Format: For "5" splitRule is "2+2+1"</param>
        /// <param name="model"></param>
        void SplitInventoryUnit(List<decimal> quantityList, InventoryUnitModel model);

        void SaveDirectReceive(List<InventoryUnitModel> list);
    }
}


//        bool AddOrUpdateAttribute(AttributeModel attributeModel);

//List<AttributeModel> GetAttributeList();
// List<OptionModel> GetDistinctAttributes();
// List<OptionModel> GetOptionList();
// void DeleteAttribute(AttributeModel attributeModel);
// List<AttributeModel> GetOptionList(int productId);

//VariantModel GetVariantById(string sku);
//List<VariantModel> GetVariantList();
//VariantModel GetVariantBySKU(string sku);
//void SaveVariant(VariantModel variantModel);