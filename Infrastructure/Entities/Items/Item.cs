using Infrastructure.Entities.Products;
using Infrastructure.Entities.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Items
{
    public class Item
    {
        public int Id { get; set; }
        // product's item
        public int ProductId { get; set; }
        // to which purchase this item belongs to 
        public int PurchaseId { get; set; }
        // item's barcode 
        public string Barcode { get; set; }
        //

        // ============ Table Objects ============ //

        public virtual Product Product { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}
