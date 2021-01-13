using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Core.Reports
{
    public class LedgerModel
    {
        public DateTime Date { get; set; }
        public string Particulars { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
        public int DrCr { get; set; }
        public string DrCrString { get; set; }
        public string Balance { get; set; }
        // indicates the data is from DB, true when new list-item is added manually (e.g. to show total row)
        public bool IsManualNewRow { get; set; }
    }
}
