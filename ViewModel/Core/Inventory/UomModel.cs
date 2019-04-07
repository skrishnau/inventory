using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Inventory
{
    public class UomModel
    {
        public int Id { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public string BaseUnit { get; set; }
        public int? BaseUnitId { get; set; }
        public bool Use { get; set; }
    }
}
