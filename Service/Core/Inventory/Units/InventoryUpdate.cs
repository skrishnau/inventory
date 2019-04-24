using Infrastructure.Context;
using Infrastructure.Entities.Inventory;
using Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;

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
