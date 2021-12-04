using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Inventory;

namespace ViewModel.Core
{
    public class UserManufactureModel
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int ManufactureDepartmentUserId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public bool InOut { get; set; }
        public Nullable<decimal> BuildRate { get; set; }

        // extra not needed for entity
        public int UserId { get; set; }
        public string ProductName { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string DateString { get; set; }

        public List<InventoryUnitModel> ConsumedProducts { get; set; }

        public List<ProductOwnerModel> NextProductOwners { get; set; }

        public int DepartmentId { get; set; }
    }
    
}
