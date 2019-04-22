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

        List<InventoryUnitModel> GetInventoryUnitList();

        List<MovementModel> GetMovementList();

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

    }
}
