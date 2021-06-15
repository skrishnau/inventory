using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Reports
{
    public class ProductLedgerMasterModel
    {
        public ProductLedgerMasterModel()
        {
            ProductLedgerData = new List<ProductLedgerModel>();
        }
        public List<ProductLedgerModel> ProductLedgerData { get; set; }


        //public string DebitSum { get; set; }
        //public string CreditSum { get; set; }
        //public string BalanceSum { get; set; }
        //public int DrCr { get; set; }
        //public string DrCrString { get; set; }

        // for use in ProductLedger print
        public string Category { get; set; }
        public string Product { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

    }
    public class ProductLedgerModel
    {
        public string Date { get; set; }
        public string ReferenceNo { get; set; }
        public string OrderType { get; set; }
        public string Client { get; set; }
        //public string Particulars { get; set; }
        public string UnitQuantity { get; set; }
        public string Package { get; set; }
        public string Rate { get; set; }
        public string CostPrice { get; set; }
        public string Total { get; set; }
        //public string Balance { get; set; }
        // indicates the data is from DB, true when new list-item is added manually (e.g. to show total row)
        public bool IsManualNewRow { get; set; }
    }

    public class ProductLedgerRequestModel
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool ApplyDateFilter { get; set; }

    }
}
