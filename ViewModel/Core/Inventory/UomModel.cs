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
        public string Name { get; set; }// Unit
        public decimal Quantity { get; set; }
        public string BaseUom { get; set; }
        public int? BaseUomId { get; set; }
        public bool Use { get; set; }
    }
}
