using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Reports;

namespace Service.Core.Reports
{
    public interface IReportService
    {
        LedgerMasterModel GetLedger(int customerId, DateTime from, DateTime to);

    }
}
