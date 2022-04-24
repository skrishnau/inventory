using Infrastructure.Context;
using Service.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Reports;
using ViewModel.Enums;
using ViewModel.Utility;

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
            using (var _context = DatabaseContext.Context)
            {
                var user = _context.Users.Find(userId);
                if (user != null)
                {
                    from = from.Date;
                    to = to.Date;
                    to = to.AddDays(1);

                    var query = _context.Transactions.Where(x => x.UserId == userId && !x.IsVoid);
                    var openingBalanceQuery = query;
                    if (model.OnlyAfterLastClearance)
                    {
                        query = query.Where(x => x.User.AllDuesClearDate == null || x.Date > x.User.AllDuesClearDate);
                        openingBalanceQuery = openingBalanceQuery.Where(x => x.User.AllDuesClearDate != null && x.Date <= x.User.AllDuesClearDate);

                    }
                    else
                    {
                        if (model.ApplyDateFilter)
                        {
                            query = query.Where(x => x.Date >= from && x.Date <= to);
                            openingBalanceQuery = openingBalanceQuery.Where(x => x.Date < from);
                        }
                        // else Logic should be to make opening Balance empty. but that is constly so we are doing the filter later
                    }

                    var transactions = query.OrderBy(x => x.Date).ToList();

                    List<LedgerModel> actualResult;
                    // transaction items
                    if (Constants.LEDGER_DISPLAY_TRANSACTION_ITEMS_ALSO) // get it from Appsettings later
                    {
                        actualResult = new List<LedgerModel>();
                        foreach (var txn in transactions)
                        {
                            var isIncoming = txn.Type == TransactionTypeEnum.Credit.ToString() || txn.Type == TransactionTypeEnum.Sale.ToString();

                            var order = txn.Order;
                            if (txn.Order == null)
                            {
                                // payment case
                                actualResult.Add(TransactionToLedgerModel(txn));
                            }
                            else
                            {
                                actualResult.Add(TransactionToLedgerModel(txn));
                                // order case
                                foreach (var x in txn.Order.OrderItems)
                                {
                                    var led = new LedgerModel
                                    {
                                        Balance = "",//isIncoming ? $"{x.Total}" : $"({x.Total})",//.ToString("#.00"),
                                        Credit = "",//isIncoming ? $"{x.Total}" : "",//.ToString("#.00"),
                                        Debit = "",//isIncoming ? "" : $"{x.Total}",//.ToString("#.00"),
                                        DrCr = 0,//isIncoming ? 1 : -1,
                                        DrCrString = "",//isIncoming ? "Cr" : "Dr",
                                        Date = "",//DateConverter.Instance.ToBS(order.CompletedDate.Value).ToString(),//.ToString("yyyy/MM/dd"),
                                        Particulars = $"    {x.Product.Name} ({x.UnitQuantity} {x.Package.Name} @ {x.Rate}) Tot.: {x.Total}",
                                    };
                                    actualResult.Add(led);
                                }
                            }

                        }
                    }
                    else
                    {
                        actualResult = transactions
                        .Select(x => TransactionToLedgerModel(x))
                        .ToList();
                    }

                    var fromDate = DateConverter.Instance.ToBS(from).ToString();// from.ToString("yyyy/MM/dd");
                    var toDate = DateConverter.Instance.ToBS(to.AddDays(-1)).ToString();// to.AddDays(-1).ToString("yyyy/MM/dd");
                    if (model.OnlyAfterLastClearance)
                    {
                        fromDate = user.AllDuesClearDate.HasValue ? DateConverter.Instance.ToBS(user.AllDuesClearDate.Value).ToString() : actualResult.FirstOrDefault()?.Date ?? "";//user.AllDuesClearDate.Value.ToString("yyyy/MM/dd") 
                        toDate = DateConverter.Instance.ToBS(DateTime.Now).ToString();//.ToString("yyyy/MM/dd");
                    }
                    decimal openingBalanceSum = 0;
                    if (model.OnlyAfterLastClearance || model.ApplyDateFilter)
                    {
                        openingBalanceSum = openingBalanceQuery.Sum(x => (decimal?)(x.DrCr * x.Balance)) ?? 0;
                    }
                    var openingBalanceModel = new LedgerModel
                    {
                        Balance = openingBalanceSum < 0 ? "(" + Math.Abs(openingBalanceSum).ToString("0.00") + ")" : openingBalanceSum.ToString("0.00"),
                        Particulars = "Opening Balance",
                    };
                    actualResult.Insert(0, openingBalanceModel);
                    var balance = transactions.Sum(x => x.Balance * x.DrCr);
                    balance = balance + openingBalanceSum;
                    var drcr = Math.Sign(balance);
                    var master = new LedgerMasterModel
                    {
                        BalanceSum = drcr < 0 ? $"({Math.Abs(balance).ToString("0.00")})" : balance.ToString("0.00"),
                        LedgerData = actualResult,
                        CreditSum = "" + transactions.Sum(x => x.Credit),
                        DebitSum = "" + transactions.Sum(x => x.Debit),
                        DrCr = drcr,
                        DrCrString = drcr > 0 ? "Cr" : drcr < 0 ? "Dr" : "",
                        // for ledger print
                        Phone = user.Phone,
                        Address = user.Address,
                        User = user.Name,
                        FromDate = DateConverter.Instance.ToBS(from).ToString(),//from.ToString("yyyy/MM/dd"),
                        ToDate = DateConverter.Instance.ToBS(to.AddDays(-1)).ToString(), //to.AddDays(-1).ToString("yyyy/MM/dd"),
                        UserId = model.CustomerId
                    };
                    return master;
                }
                return null;
            }
        }

        private LedgerModel TransactionToLedgerModel(Infrastructure.Context.Transaction x)
        {
            
            return new LedgerModel
            {
                Balance = x.DrCr < 0 ? $"({Math.Abs(x.Balance).ToString("0.00")})" : x.DrCr > 0 ? $"{x.Balance}" : "",//.ToString("#.00"),
                Credit = x.Credit == 0 ? "" : $"{x.Credit}",//.ToString("#.00"),
                Debit = x.Debit == 0 ? "" : $"{x.Debit}",//.ToString("#.00"),
                DrCr = x.DrCr,
                DrCrString = x.DrCr > 0 ? "Cr" : x.DrCr < 0 ? "Dr" : "",
                Date = DateConverter.Instance.ToBS(x.Date).ToString(),//.ToString("yyyy/MM/dd"),
                Particulars = x.Particulars,
            };
        }


        public ProductLedgerMasterModel GetProductLedger(ProductLedgerRequestModel model)
        {
            int productId = model.ProductId;
            DateTime from = model.From;
            DateTime to = model.To;
            using (var _context = DatabaseContext.Context)
            {
                var product = _context.Products.Find(productId);
                if (product != null)
                {
                    from = from.Date;
                    to = to.Date;
                    to = to.AddDays(1);

                    var query = _context.OrderItems.Where(x => x.ProductId == productId && !x.Order.IsVoid && !x.Order.IsCancelled && x.Order.IsCompleted);
                    var openingBalanceQuery = query;
                    if (model.ApplyDateFilter)
                    {
                        query = query.Where(x => x.Order.CompletedDate >= from && x.Order.CompletedDate <= to);
                        openingBalanceQuery = openingBalanceQuery.Where(x => x.Order.CompletedDate < from);
                    }

                    var transactions = query.OrderBy(x => x.Order.CompletedDate).ToList();

                    List<ProductLedgerModel> actualResult;
                    // order items
                    actualResult = transactions
                        .Select(x => OrderItemToProductLedgerModel(x))
                        .ToList();

                    string fromDate;
                    string toDate;

                    decimal openingBalanceSum = 0;
                    if (model.ApplyDateFilter)
                    {
                        fromDate = DateConverter.Instance.ToBS(from).ToString(); // from.ToString("yyyy/MM/dd");
                        toDate = DateConverter.Instance.ToBS(to.AddDays(-1)).ToString();// to.AddDays(-1).ToString("yyyy/MM/dd");
                        //openingBalanceSum = openingBalanceQuery.Sum(x => (decimal?)(x.DrCr * x.Balance)) ?? 0;
                    }
                    //var openingBalanceModel = new ProductLedgerModel
                    //{
                    //    Balance = openingBalanceSum > 0 ? openingBalanceSum.ToString("0.00") : "(" + openingBalanceSum.ToString("0.00") + ")",
                    //    Particulars = "Opening Balance",
                    //};
                    //actualResult.Insert(0, openingBalanceModel);
                    var balance = 0;//transactions.Sum(x => x.Balance * x.DrCr);
                    var drcr = Math.Sign(balance);
                    var master = new ProductLedgerMasterModel
                    {
                        //BalanceSum = drcr < 0 ? $"({Math.Abs(balance)})" : balance.ToString(),
                        ProductLedgerData = actualResult,
                        //CreditSum = "" + transactions.Sum(x => x.Credit),
                        //DebitSum = "" + transactions.Sum(x => x.Debit),
                        //DrCr = drcr,
                        //DrCrString = drcr > 0 ? "Cr" : drcr < 0 ? "Dr" : "",
                        // for ledger print
                        Category = product.Category.Name,
                        Product = product.Name,
                        FromDate = DateConverter.Instance.ToBS(from).ToString(),
                        ToDate = DateConverter.Instance.ToBS(to.AddDays(-1)).ToString(),
                    };
                    return master;
                }
                return null;
            }
        }

        private ProductLedgerModel OrderItemToProductLedgerModel(Infrastructure.Context.OrderItem x)
        {
            return new ProductLedgerModel
            {
                Client = x.Order.User?.Name,
                OrderType = x.Order.OrderType,
                UnitQuantity = x.UnitQuantity.ToString("0.00"),
                Package = x.Package.Name,
                Rate = x.Rate.ToString("0.00"),
                ReferenceNo = x.Order.ReferenceNumber,
                Total = x.Total.ToString("0.00"),
                CostPrice = x.Order.OrderType == OrderTypeEnum.Sale.ToString()
                ? (x.CostPriceRate.HasValue ? x.CostPriceRate.Value.ToString("0.00") : "0.00")
                : "",
                Date = x.Order.CompletedDate.HasValue ? DateConverter.Instance.ToBS(x.Order.CompletedDate.Value).ToString() : "",
                //Particulars = x.Order.transa.Particulars,

            };
        }


        public ProfitAndLossMasterModel GetProfitAndLoss(ProfitAndLossRequestModel model)
        {
            DateTime from = model.From;
            DateTime to = model.To;
            using (var _context = DatabaseContext.Context)
            {
                from = from.Date;
                to = to.Date;
                var isFromAndToEqual = from == to;
                to = to.AddDays(1);
                var query = _context.Transactions.Where(x => x.Type == TransactionTypeEnum.Sale.ToString() && !x.IsVoid);
                var openingBalanceQuery = query;
                if (!model.YearlyData)
                {
                    query = query.Where(x => x.Date >= from && x.Date <= to);
                    openingBalanceQuery = openingBalanceQuery.Where(x => x.Date < from);
                }
                var transactions = query.OrderBy(x => x.Date).ToList();
                var list = new List<ProfitAndLossModel>();
                if (model.YearlyData)
                {
                    var debitSum = transactions.Sum(a => a.Debit);
                    var costPriceSum = (transactions.Sum(a => a.CostPriceTotal ?? 0));
                    var profit = debitSum - costPriceSum;
                    var pl = new ProfitAndLossModel
                    {
                        Balance = profit < 0 ? $"({Math.Abs(profit).ToString("0.00")})" : profit > 0 ? $"{profit}" : "",//.ToString("#.00"),
                        Revenue = $"{debitSum}",//.ToString("#.00"),
                        Expense = $"{costPriceSum}",//.ToString("#.00"),
                        ProfitLoss = Math.Sign(profit),
                        ProfitLossString = profit > 0 ? "P" : profit < 0 ? "L" : "",
                        Date = "All",//DateConverter.Instance.ToBS(x.Key).ToString(),//.ToString("yyyy/MM/dd"),
                        Particulars = $"Total: {transactions.Count()} transactions",//(x.Order?.User?.Name?? "" ) +" ("+ x.Particulars + ")",
                    };
                    list.Add(pl);
                }
                else
                {
                    if (isFromAndToEqual)
                    {
                        foreach (var txn in transactions)
                        {
                            var profit = txn.Debit - (txn.CostPriceTotal ?? 0);
                            var pl = new ProfitAndLossModel
                            {
                                Balance = profit < 0 ? $"({Math.Abs(profit).ToString("0.00")})" : profit > 0 ? $"{profit}" : "",//.ToString("#.00"),
                                Revenue = $"{txn.Debit}",//.ToString("#.00"),
                                Expense = $"{txn.CostPriceTotal}",//.ToString("#.00"),
                                ProfitLoss = Math.Sign(profit),
                                ProfitLossString = profit > 0 ? "P" : profit < 0 ? "L" : "",
                                Date = DateConverter.Instance.ToBS(txn.Date).ToString(),//.ToString("yyyy/MM/dd"),
                                Particulars = (txn.Order?.User?.Name ?? "") + " (Bill No.: " + txn.Particulars + ")",
                            };
                            list.Add(pl);
                        }
                    }
                    else
                    {
                        foreach (var x in transactions.GroupBy(x => x.Date.Date))
                        {
                            var debitSum = x.Sum(a => a.Debit);
                            var costPriceSum = (x.Sum(a => a.CostPriceTotal ?? 0));
                            var profit = debitSum - costPriceSum;
                            var pl = new ProfitAndLossModel
                            {
                                Balance = profit < 0 ? $"({Math.Abs(profit).ToString("0.00")})" : profit > 0 ? $"{profit}" : "",//.ToString("#.00"),
                                Revenue = $"{debitSum}",//.ToString("#.00"),
                                Expense = $"{costPriceSum}",//.ToString("#.00"),
                                ProfitLoss = Math.Sign(profit),
                                ProfitLossString = profit > 0 ? "P" : profit < 0 ? "L" : "",
                                Date = DateConverter.Instance.ToBS(x.Key).ToString(),//.ToString("yyyy/MM/dd"),
                                Particulars = $"Total: {x.Count()} transactions",//(x.Order?.User?.Name?? "" ) +" ("+ x.Particulars + ")",
                            };
                            list.Add(pl);
                        }
                    }
                }

                var openingBalanceSum = model.YearlyData ? 0 : openingBalanceQuery.Sum(x => (decimal?)(x.Debit - x.CostPriceTotal)) ?? 0;
                var openingBalanceModel = new ProfitAndLossModel
                {
                    Balance = openingBalanceSum >= 0 ? openingBalanceSum.ToString("0.00") : "(" + Math.Abs(openingBalanceSum).ToString("0.00") + ")",
                    Particulars = "Opening Balance",
                };
                list.Insert(0, openingBalanceModel);
                var balance = transactions.Sum(x => x.Debit - (x.CostPriceTotal ?? 0));
                var profitLoss = Math.Sign(balance);
                var master = new ProfitAndLossMasterModel
                {
                    BalanceSum = profitLoss < 0 ? $"({Math.Abs(balance).ToString("0.00")})" : balance.ToString(),
                    ProfitAndLossData = list,
                    RevenueSum = "" + transactions.Sum(x => x.Debit),
                    ExpenseSum = "" + transactions.Sum(x => x.CostPriceTotal),
                    ProfitLoss = profitLoss,
                    ProfitLossString = profitLoss > 0 ? "P" : profitLoss < 0 ? "L" : "",
                    FromDate = DateConverter.Instance.ToBS(from).ToString(),//from.ToString("yyyy/MM/dd"),
                    ToDate = DateConverter.Instance.ToBS(to.AddDays(-1)).ToString(), //to.AddDays(-1).ToString("yyyy/MM/dd"),
                };
                return master;
            }
        }

    }
}
