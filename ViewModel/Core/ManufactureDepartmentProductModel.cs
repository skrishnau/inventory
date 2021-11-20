using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core
{
    public class ManufactureDepartmentProductModel
    {
        public int Id { get; set; }
        //public int ManufactureDepartmentId { get; set; }
        public int DepartmentId { get; set; }
        public int ProductId { get; set; }
        public int PackageId { get; set; }
        public decimal Quantity { get; set; }
        public bool InOut { get; set; }
        public Nullable<decimal> BuildRate { get; set; }

        public string ProductName { get; set; }
        public string PackageName { get; set; }
    }
}
