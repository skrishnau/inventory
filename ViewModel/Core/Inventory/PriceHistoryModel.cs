using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Inventory
{
    public class PriceHistoryModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        //public string Product { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string DateString { get; set; }
        // from PriceTypeEnum: CostPrice or SellingPrice
        public string PriceType { get; set; }
        public int? PackageId { get; set; }
       // public string Package { get; set; }
    }


}
