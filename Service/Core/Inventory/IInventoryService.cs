using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Business;
using ViewModel.Core.Common;
using ViewModel.Core.Inventory;
using ViewModel.Core.Purchases;

namespace Service.Core.Inventory
{
    public interface IInventoryService
    {
        #region Warehouse

        WarehouseModel GetWarehouse(int warehouseId);
        List<WarehouseModel> GetWarehouseList();
        void AddOrUpdateWarehouse(WarehouseModel model);
        void DeleteWarehouse(int id);
        List<IdNamePair> GetWarehouseListForCombo();

        #endregion

        #region Package

        List<IdNamePair> GetPackageListForCombo();
        List<PackageModel> GetPackageList();
        string SavePackage(PackageModel package);

        #endregion

        #region UOM

        List<UomModel> GetUomList();
        List<IdNamePair> GetUomListForCombo();

        #endregion

        #region Supplier

        List<IdNamePair> GetSupplierListForCombo();


        #endregion


        #region Product

        List<IdNamePair> GetProductListForCombo();
        List<ProductModel> GetProductListForGridView();
        ProductModel GetProduct(int productId);
        ProductModel GetProductForEdit(int productId);
        ProductModel GetProductBySKU(string sku);
        void AddUpdateProduct(ProductModel product);
        void DeleteProduct(int id);

        #endregion

        List<WarehouseProductModel> GetWarehouseProductList(int warehouseId, int productId);


        #region Category



        List<CategoryModel> GetCategoryList(int? parentCategoryId);
        CategoryModel GetCategory(string v);
        void AddUpdateCategory(CategoryModel category);
        void DeleteCategory(CategoryModel categoryModel);

        #endregion

        List<BrandModel> GetBrandList();
        void AddUpdateBrand(BrandModel brand);

        List<IdNamePair> GetAdjustmentCodeListForCombo();
        List<IdNamePair> GetPositiveAdjustmentCodeListForCombo();
        List<IdNamePair> GetNegativeAdjustmentCodeListForCombo();

        List<InventoryUnitModel> GetInventoryUnitList();



        void SaveUom(UomModel data);

        #region Inventory Actions

        void MoveInventoryUnits(int warehouseId, List<InventoryUnitModel> dataList);

        void MergeInventoryUnits(List<InventoryUnitModel> list);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="splitRule">Format: For "5" splitRule is "2+2+1"</param>
        /// <param name="model"></param>
        void SplitInventoryUnit(List<decimal> quantityList, InventoryUnitModel model);

        string SaveDirectReceive(List<InventoryUnitModel> list);
        string SaveDirectIssue(List<InventoryUnitModel> list);

        #endregion

        #region Adjustment Codes

        List<AdjustmentCodeModel> GetAdjustmentCodeList();
        List<AdjustmentCodeModel> GetAdjustmentCodeListUsableOnly();
        string SaveAdjustmentCode(AdjustmentCodeModel model);


        #endregion



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