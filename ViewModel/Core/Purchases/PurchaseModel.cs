using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Purchases
{
    // for add
    public class PurchaseModel
    {
        public PurchaseModel()
        {
            PurchaseItems = new List<PurchaseItemModel>();
        }

        public int Id { get; set; }
        // we may not know the supplier in case of direct purchase
        public int? SupplierId { get; set; }
        // receipt is not yet created when Purchase is created...
        // incrementing number with custom prefix and suffix given by user
        // will be generated as per the settings and the last Invoice number
        public string ReceiptNo { get; set; }
       
        // Caluculated sum of amount of each purchase item
        public decimal TotalAmount { get; set; }
        // created Date
        public DateTime CreatedAt { get; set; }
        // if null then this data is not deleted; if NOT null then this data is deleted
        public DateTime? DeletedAt { get; set; }

        public List<PurchaseItemModel> PurchaseItems { get; set; }


    }

    public class PurchaseOrderModelForGridView
    {
        public int Id { get; set; }

        public string ReceiptNo { get; set; }
        public string Supplier { get; set; }

        public int LotNo { get; set; }

        public string OrderDate { get; set; }
        public string ReceivedDate { get; set; }

        public string TotalAmount { get; set; }
        public int ItemsCount { get; set; }

        public string Status { get; set; }
    }
}
