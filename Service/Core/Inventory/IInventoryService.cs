﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core;
using ViewModel.Core.Business;
using ViewModel.Core.Common;
using ViewModel.Core.Inventory;
using ViewModel.Core.Orders;

namespace Service.Core.Inventory
{
    public interface IInventoryService
    {
        #region Warehouse

        WarehouseModel GetWarehouse(int warehouseId);
        List<WarehouseModel> GetWarehouseList();
        void AddOrUpdateWarehouse(WarehouseModel model);
       // void DeleteWarehouse(int id);
        List<IdNamePair> GetWarehouseListForCombo();

        #endregion

        #region Package

        List<IdNamePair> GetPackageListForCombo();
        List<PackageModel> GetPackageList();
        PackageModel GetPackage(int packageId);
        ResponseModel<PackageModel> SavePackage(PackageModel package);

        #endregion

        #region UOM

        ResponseModel<UomModel> SaveUom(UomModel data);
        List<UomModel> GetUomList();
        UomModel GetUom(int uomId);
        List<IdNamePair> GetUomListForCombo();

        #endregion

        #region Supplier

        List<IdNamePair> GetSupplierListForCombo();


        #endregion


        #region Product

       // void DeleteProduct(int id);

        #endregion

        List<WarehouseProductModel> GetWarehouseProductList(int warehouseId, int productId);
        List<TransactionSummaryModel> GetTransactionSummary(DateTime start, DateTime end);
        List<TransactionSummaryModel> GetInventorySummary();


        #region Category



        #endregion

        //List<BrandModel> GetBrandList();
        //void AddUpdateBrand(BrandModel brand);

        #region Adjustment Codes

        List<AdjustmentCodeModel> GetAdjustmentCodeList();
        List<AdjustmentCodeModel> GetAdjustmentCodeListUsableOnly();
        List<IdNamePair> GetAdjustmentCodeListForCombo();
        List<IdNamePair> GetPositiveAdjustmentCodeListForCombo();
        List<IdNamePair> GetNegativeAdjustmentCodeListForCombo();
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