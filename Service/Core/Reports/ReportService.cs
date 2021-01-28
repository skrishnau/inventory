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

        public LedgerMasterModel GetLedger(LedgerRequestModel model)
        {
            int userId = model.CustomerId;
            DateTime from = model.From;
            DateTime to = model.To;
            using (var _context = new DatabaseContext())
            {
                var user = _context.User.Find(userId);
                if (user != null)
                {
                    from = from.Date;
                    to = to.Date;
                    to = to.AddDays(1);

                    var query = _context.Transaction.Where(x => x.UserId == userId);
                    var openingBalanceQuery = query;
                    if (model.OnlyAfterLastClearance)
                    {
                        query = query.Where(x => x.User.AllDuesClearDate == null || x.Date > x.User.AllDuesClearDate);
                        openingBalanceQuery = openingBalanceQuery.Where(x => x.User.AllDuesClearDate != null && x.Date <= x.User.AllDuesClearDate);
                       
                    }
                    else
                    {
                        query = query.Where(x => x.Date >= from && x.Date <= to && !x.IsVoid);
                        openingBalanceQuery = openingBalanceQuery.Where(x => x.Date < from);
                    }

                    var transactions = query.OrderBy(x => x.Date).ToList();
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
                    var fromDate = from.ToString("yyyy/MM/dd");
                    var toDate = to.AddDays(-1).ToString("yyyy/MM/dd");
                    if (model.OnlyAfterLastClearance)
                    {
                        fromDate = user.AllDuesClearDate.HasValue ? user.AllDuesClearDate.Value.ToString("yyyy/MM/dd") : result.FirstOrDefault()?.Date??"";
                        toDate = DateTime.Now.ToString("yyyy/MM/dd");
                    }

                    var openingBalanceSum = openingBalanceQuery.Sum(x => (decimal?)(x.DrCr * x.Balance)) ?? 0;
                    var openingBalanceModel = new LedgerModel
                    {
                        Balance = openingBalanceSum > 0 ? openingBalanceSum.ToString("0.00") : "(" + openingBalanceSum.ToString("0.00") + ")",
                        Particulars = "Opening Balance",
                    };
                    result.Insert(0, openingBalanceModel);
                    var balance = transactions.Sum(x => x.Balance * x.DrCr);
                    var drcr = Math.Sign(balance);
                    var master = new LedgerMasterModel
                    {
                        BalanceSum = drcr < 0 ? $"({Math.Abs(balance)})" : balance.ToString(),
                        LedgerData = result,
                        CreditSum = "" + transactions.Sum(x => x.Credit),
                        DebitSum = "" + transactions.Sum(x => x.Debit),
                        DrCr = drcr,
                        DrCrString = drcr > 0 ? "Cr" : drcr < 0 ? "Dr" : "",
                        // for ledger print
                        Address = user.Address,
                        User = user.Name,
                        FromDate = from.ToString("yyyy/MM/dd"),
                        ToDate = to.AddDays(-1).ToString("yyyy/MM/dd"),
                    };
                    return master;
                }
                return null;
            }
        }

    }
}
