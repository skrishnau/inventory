using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Inventory
{
    [Obsolete("Variant is no longer used", true)]
    public class VariantModel
    {

        public VariantModel()
        {
            // intialize in constructor such that the property is never null
            OptionIds = new List<int>();
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public string SKU { get; set; }

        public decimal QuantityInStock { get; set; }
        public decimal LatestUnitCostPrice { get; set; }
        public decimal LatestUnitSellPrice { get; set; }

        public bool? ShowStockAlerts { get; set; }
        public int? MinStockCountForAlert { get; set; }

        public List<int> OptionIds { get; set; }

    }



}
