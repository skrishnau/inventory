using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core
{
    public class UserManufactureModel
    {
        public int UserId { get; set; }
        public int ManufactureDepartmentUserId { get; set; }
        public Nullable<System.DateTime> StartedAt { get; set; }
        public Nullable<System.DateTime> CompletedAt { get; set; }
        public Nullable<System.DateTime> CancelledAt { get; set; }
        public Nullable<decimal> BuildRate { get; set; }
        public string Remarks { get; set; }

        public List<UserManufactureProductModel> UserManufactureProducts { get; set; }
    }

    public class UserManufactureProductModel
    {
        public string DateString { get; set; }
        public int UserId { get; set; }
        public int UserManufactureId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public decimal Quantity { get; set; }
        public bool InOut { get; set; }
    }
}
