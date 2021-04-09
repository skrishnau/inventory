using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Inventory
{
    public class InventoryMovementModel
    {
        public InventoryUnitModel InventoryUnit { get; set; }
        public decimal UnitQuantity { get; set; }
        public int? SourceWarehouseId { get; set; }
        public int? TargetWarehouseId { get; set; }
        public DateTime Date { get; set; }
    }
}
