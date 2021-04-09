﻿using Infrastructure.Context;
using Infrastructure.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;

namespace Service.Core.Inventory.Units
{
    public interface IInventoryUnitService
    {
        #region Inventory

        List<InventoryUnitModel> GetInventoryUnitList(int warehouseId, int productId);

        List<MovementModel> GetMovementList();

        string MoveInventoryUnits(int warehouseId, List<InventoryUnitModel> dataList);

        void MergeInventoryUnits(List<InventoryUnitModel> list);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="splitRule">Format: For "5" splitRule is "2+2+1"</param>
        /// <param name="model"></param>
        void SplitInventoryUnit(List<decimal> quantityList, InventoryUnitModel model);

        

        //void UpdateWarehouseProductWithoutCommit(InventoryMovementModel model, Product product);

        #endregion

        #region Adjustments

        string SaveDirectReceive(List<InventoryUnitModel> list, string adjustmentCode);
        string SaveDirectReceiveWithoutCommit(DatabaseContext _context, List<InventoryUnitModel> list, string adjustmentCode);
        //
        // Direct Issue of whole Inventory-Unit
        //
        string SaveDirectIssueInventoryUnit(List<InventoryUnitModel> list, string adjustmentCode);
        //
        // Direct Issue of any product
        //
        string SaveDirectIssueAny(List<InventoryUnitModel> list, string adjustmentCode);
        string SaveDirectIssueAnyWithoutCommit(DatabaseContext _context, List<InventoryUnitModel> list, string adjustmentCode);

        #endregion

    }
}
