using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Reports
{
    public class ProfitAndLossMasterModel
    {
        public ProfitAndLossMasterModel()
        {
            ProfitAndLossData = new List<ProfitAndLossModel>();
        }
        public List<ProfitAndLossModel> ProfitAndLossData { get; set; }
        public string RevenueSum { get; set; }
        public string ExpenseSum { get; set; }
        public string BalanceSum { get; set; }
        public int ProfitLoss { get; set; }
        public string ProfitLossString { get; set; }

        // for use in Ledger print
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
    public class ProfitAndLossModel
    {
        public string Date { get; set; }
        public string Particulars { get; set; }
        public string Revenue { get; set; }
        public string Expense { get; set; }
        public int ProfitLoss { get; set; }
        public string ProfitLossString { get; set; }
        public string Balance { get; set; }
        // indicates the data is from DB, true when new list-item is added manually (e.g. to show total row)
        public bool IsManualNewRow { get; set; }
    }


    public class ProfitAndLossRequestModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }

}
