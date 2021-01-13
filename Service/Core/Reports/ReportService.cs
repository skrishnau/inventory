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

        public List<LedgerModel> GetLedger(int userId, DateTime from, DateTime to)
        {
            using (var _context = new DatabaseContext())
            {
                from = from.Date;
                to = to.Date;
                to = to.AddDays(1);
                return _context.Transaction
                    .Where(x => x.UserId == userId && x.Date >= from && x.Date <= to && !x.IsVoid)
                    .Select(x => new LedgerModel
                    {
                        Balance = x.DrCr < 0 ?"(" + x.Balance + ")" : ""+x.Balance,//.ToString("#.00"),
                        Credit = "" + x.Credit,//.ToString("#.00"),
                        Debit = "" + x.Debit,//.ToString("#.00"),
                        DrCr = x.DrCr,
                        DrCrString = x.DrCr > 0 ? "Cr" : x.DrCr < 0 ? "Dr" : "",
                        Date = x.Date,//.ToString("yyyy/MM/dd"),
                        Particulars = x.Particulars,
                    })
                    .ToList();
            }
        }

    }
}
