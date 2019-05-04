using System.Collections.Generic;
using ViewModel.Core.Inventory;
using ViewModel.Enums;

namespace Service.Core.Inventory.Units
{
    public static class InventoryUpdate
    {

        public static void UpdateMovement(InventoryActionEnum action,
            List<InventoryUnitModel> earlier, 
            List<InventoryUnitModel> current)
        {
            // split
            //if (action == InventoryActionEnum.Split)
            //{
            //    string splitString = "";
            //    current.ForEach(x => { splitString += x.UnitQuantity + "+"; });
            //    splitString.Trim(new char[] { '+' });
            //    var description = "Splitted a unit of "+ entity.Product.Name + "  with " + entity.UnitQuantity + " quantities " +  " into " + splitString + ".";
            //    SaveMovement(description, "----------------", "Split", entity.UnitQuantity, now);
            //}
        }

       

    }
}
