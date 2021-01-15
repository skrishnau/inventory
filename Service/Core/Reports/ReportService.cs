using Infrastructure.Context;
using Service.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Reports;

namespace Service.Core.Reports
{
    public class ReportService : IReportService
    {
        private readonly IUserService _userService;

        public ReportService(IUserService userService)
        {
            _userService = userService;

        }

        public LedgerMasterModel GetLedger(int userId, DateTime from, DateTime to)
        {
            using (var _context = new DatabaseContext())
            {
                from = from.Date;
                to = to.Date;
                to = to.AddDays(1);
                var transactions = _context.Transaction
                    .Where(x => x.UserId == userId && x.Date >= from && x.Date <= to && !x.IsVoid)
                    .ToList();
                var result = transactions
                    .Select(x => new LedgerModel
                    {
                        Balance = x.DrCr < 0 ? $"({x.Balance})" : x.DrCr > 0 ? $"{x.Balance}" : "",//.ToString("#.00"),
                        Credit = x.Credit == 0 ? "" : $"{x.Credit}",//.ToString("#.00"),
                        Debit = x.Debit == 0 ? "" : $"{x.Debit}",//.ToString("#.00"),
                        DrCr = x.DrCr,
                        DrCrString = x.DrCr > 0 ? "Cr" : x.DrCr < 0 ? "Dr" : "",
                        Date = x.Date.ToString("yyyy/MM/dd"),
                        Particulars = x.Particulars,
                    })
                    .ToList();
                var balance = transactions.Sum(x => x.Balance * x.DrCr);
                var drcr = Math.Sign(balance);
                var master = new LedgerMasterModel
                {
                    BalanceSum = drcr < 0 ? $"({Math.Abs(balance)})" : "",
                    LedgerData = result,
                    CreditSum = "" + transactions.Sum(x => x.Credit),
                    DebitSum = "" + transactions.Sum(x => x.Debit),
                    DrCr = drcr,
                    DrCrString = drcr > 0 ? "Cr" : drcr < 0 ? "Dr" : "",
                };
                return master;
            }
        }

    }
}
