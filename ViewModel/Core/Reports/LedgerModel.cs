using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Reports
{
    public class LedgerMasterModel
    {
        public LedgerMasterModel()
        {
            LedgerData = new List<LedgerModel>();
        }
        public List<LedgerModel> LedgerData { get; set; }
        public string DebitSum { get; set; }
        public string CreditSum { get; set; }
        public string BalanceSum { get; set; }
        public int DrCr { get; set; }
        public string DrCrString { get; set; }
    }
    public class LedgerModel
    {
        public string Date { get; set; }
        public string Particulars { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
        public int DrCr { get; set; }
        public string DrCrString { get; set; }
        public string Balance { get; set; }
        // indicates the data is from DB, true when new list-item is added manually (e.g. to show total row)
        public bool IsManualNewRow { get; set; }
    }

    public class LedgerRequestModel
    {
        public int CustomerId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool OnlyAfterLastClearance { get; set; }

    }
}
