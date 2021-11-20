using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core
{
    public class ManufactureProductModel
    {
        public int ManufactureId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public bool InOut { get; set; }
        public Nullable<decimal> CostRate { get; set; }
        public Nullable<decimal> BuildRate { get; set; }
    }
}
