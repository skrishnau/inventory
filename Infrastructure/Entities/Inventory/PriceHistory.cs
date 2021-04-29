using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Inventory
{
    public class PriceHistory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        // from PriceTypeEnum: CostPrice:Purchase or SellingPrice:Sell same to OrderType
        public string PriceType { get; set; }
        public int? PackageId { get; set; }
        public virtual Package Package { get; set; }
    }
}
