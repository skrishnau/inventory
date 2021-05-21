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
        public string Product { get; set; }
        public decimal? Rate { get; set; }
        public DateTime Date { get; set; }
        public string DateString { get; set; }
        // from PriceTypeEnum: CostPrice or SellingPrice
        public string PriceType { get; set; }
        public int? PackageId { get; set; }
        public string Package { get; set; }
    }

    //public class RateModel
    //{
    //    public int Id { get; set; }
    //    public int ProductId { get; set; }
    //    public string Product { get; set; }
    //    //public string CostPrice { get; set; }
    //    //public string SellingPrice { get; set; }
    //    //public DateTime Date { get; set; }
    //    public string DateString { get; set; }
    //    // from PriceTypeEnum: CostPrice or SellingPrice
    //    //public string PriceType { get; set; }
    //    //public int? PackageId { get; set; }
    //    //public string CostPricePackage { get; set; }
    //    //public string SellingPricePackage { get; set; }
    //}


}
