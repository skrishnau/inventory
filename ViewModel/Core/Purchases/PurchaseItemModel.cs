using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Purchases
{
   public class PurchaseItemModel
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int VariantId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? DeletedAt { get; set; }
    }

    public class PurchaseItemModelForListing
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Product { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
