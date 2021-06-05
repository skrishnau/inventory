using Infrastructure.Context;
using System;
using System.Collections.Generic;
using ViewModel.Core.Inventory;

namespace Service.Core.Inventory.Units
{
    public interface IInventoryUnitService
    {
        Warehouse FindWarehouseOrReturnMainWarehouse(DatabaseContext _context, int? warehouseId);

        #region Inventory

        int GetInventoryUnitCount(int warehouseId, int productId);
        InventoryUnitListModel GetInventoryUnitList(int warehouseId, int productId, int pageSize, int offset);

        int GetMovementListCount(int productId, DateTime? date);
        MovementListModel GetMovementList(int productId, DateTime? date, int pageSize, int offset);

        string MoveInventoryUnits(int warehouseId, List<InventoryUnitModel> dataList);

        string MergeInventoryUnits(List<InventoryUnitModel> list);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="splitRule">Format: For "5" splitRule is "2+2+1"</param>
        /// <param name="model"></param>
        void SplitInventoryUnit(List<decimal> quantityList, InventoryUnitModel model);

        

        //void UpdateWarehouseProductWithoutCommit(InventoryMovementModel model, Product product);

        #endregion

        #region Adjustments

        string SaveDirectReceive(List<InventoryUnitModel> list, DateTime receivedDate, string adjustmentCode);
        string SaveDirectReceiveListWithoutCommit(DatabaseContext _context, List<InventoryUnitModel> list, DateTime receivedDate, string adjustmentCode);
        InventoryUnit SaveDirectReceiveItemWithoutCommit(DatabaseContext _context, InventoryUnitModel unit, DateTime movementDate, string adjustmentCode, ref string msg, Product product, string reference, OrderItem orderItem);
        //
        // Direct Issue of whole Inventory-Unit
        //
        string SaveDirectIssueInventoryUnit(List<InventoryUnitModel> list, string adjustmentCode);
        //
        // Direct Issue of any product
        //
        string SaveDirectIssueAny(List<InventoryUnitModel> list, string adjustmentCode, string referenceNo);
        string SaveDirectIssueAnyListWithoutCommit(DatabaseContext _context, List<InventoryUnitModel> list, string adjustmentCode, string referenceNo);
        List<InventoryUnit> SaveDirectIssueAnyItemWithoutCommit(DatabaseContext _context, InventoryUnitModel model, string adjustmentCode, ref string msg, string referenceNo);
        #endregion


        //PriceHistory GetRate(int productId, DateTime? completedDate);

    }
}
