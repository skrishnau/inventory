using DTO.Core.Inventory;
using Infrastructure.Context;
using Service.Core.Orders;
using Service.Core.Settings;
using Service.DbEventArgs;
using Service.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core;
using ViewModel.Core.Orders;
using ViewModel.Core.Users;
using ViewModel.Enums;

namespace Service.Core.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly IDatabaseChangeListener _listener;
        private readonly IAppSettingService _appSettingService;
        public PaymentService(IAppSettingService appSettingService, IDatabaseChangeListener listener)
        {
            _appSettingService = appSettingService;
            _listener = listener;
        }

        public int GetAllPaymentsCount(ClientTypeEnum clientType, string searchName = "")
        {
            using (var _context = new DatabaseContext())
            {
                var query = GetPaymentQueryable(_context, clientType, searchName);
                return query.Count();
            }
        }
        
        public PaymentListModel GetAllPayments(ClientTypeEnum clientType, int pageSize, int offset, string searchName = "")
        {
            using (var _context = new DatabaseContext())
            {
                var query = GetPaymentQueryable(_context, clientType, searchName);
                var totalCount = query.Count();
                if (pageSize > 0 && offset >= 0)
                {
                    query = query.Skip(offset).Take(pageSize);
                }
                var list = query.MapToModel();// PaymentMapper.MapToPaymentModel(query);
                return new PaymentListModel
                {
                    DataList = list,
                    TotalCount = totalCount,
                    Offset = offset,
                    PageSize = pageSize,
                };
            }
        }

        private IQueryable<Infrastructure.Context.Payment> GetPaymentQueryable(DatabaseContext _context, ClientTypeEnum clientType, string searchName)
        {
            var query = _context.Payments.AsQueryable();
                    //.Where(x => x. == null);
            var customer = UserTypeEnum.Customer.ToString();
            var supplier = UserTypeEnum.Supplier.ToString();

            var clientTypeStr = clientType.ToString();
            if(clientType != ClientTypeEnum.All)
            {
                query = query.Where(x => x.User.UserType == clientTypeStr);
            }
            if (!string.IsNullOrEmpty(searchName))
            {
                var split = searchName.Split(new char[] { '-' });
                var namePart = split[0].Trim();
                // no need to do split[1] search cause it won't occur when user has typed the name manually
                query = query.Where(x => x.User.Name.Contains(namePart) || x.User.Company.Contains(namePart));
                
            }
            return query.OrderByDescending(x => x.Date);
        }

        public PaymentModel GetPayment(int paymentId)
        {
            using (var _context = new DatabaseContext())
            {
                return _context.Payments.Find(paymentId).MapToModel();
            }
        }

        public ResponseModel<PaymentModel> Save(PaymentModel model)
        {
            using (var _context = new DatabaseContext())
            {
                var entity = model.MapToEntity();
                _context.Payments.Add(entity);
                model.Id = entity.Id;
                User user = null;
                if (model.UserId > 0)
                {
                    user = _context.Users.Find(model.UserId);
                }
                // ----- Add Transaction of User ----- //
                var tempOrder = new Order
                {
                    TotalAmount = 0,
                    PaidAmount = model.Amount,
                    ReferenceNumber = $"{(string.IsNullOrEmpty(model.PaidBy)? (user?.Name??""): model.PaidBy)}",
                    UserId = user?.Id,
                    OrderType = model.PaymentType,//"Sale",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    DeliveryDate = DateTime.Now,
                };
                var txn = OrderService.GetTransactionWithoutCommit(_context, tempOrder.MapToModel());
                if (user != null)
                {
                    user.Transactions.Add(txn);
                    if(model.DueAmount <= 0)
                    {
                        user.PaymentDueDate = null;
                        user.AllDuesClearDate = DateTime.Now;
                    }
                    
                }
                _context.SaveChanges();

                _appSettingService.IncrementBillIndex(ReferencesTypeEnum.Payment);

                if (user != null)
                {
                    var userModel = UserMapper.MapToUserModel(user);
                    BaseEventArgs<UserModel> userEventArgs = BaseEventArgs<UserModel>.Instance;
                    userEventArgs.Mode = Utility.UpdateMode.EDIT;
                    userEventArgs.Model = userModel;
                    _listener.TriggerUserUpdateEvent(null, userEventArgs);
                }
                BaseEventArgs<PaymentModel> eventArgs = BaseEventArgs<PaymentModel>.Instance;
                eventArgs.Mode = Utility.UpdateMode.ADD;
                eventArgs.Model = entity.MapToModel();
                _listener.TriggerPaymentUpdateEvent(null, eventArgs);

                return ResponseModel<PaymentModel>.GetSaveSuccess(eventArgs.Model);
            }
        }

        public bool CancelPayment(int paymentId)
        {
            using(var _context = new DatabaseContext())
            {
                var payment = _context.Payments.Find(paymentId);
                if (payment != null)
                {
                    payment.IsVoid = true;
                    //Transaction.IsVoid = true;
                    return true;
                }
                return false;
            }
        }
    }
}
