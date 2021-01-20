using DTO.Core.Inventory;
using Infrastructure.Context;
using Infrastructure.Entities.Orders;
using Infrastructure.Entities.Users;
using Service.Core.Orders;
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
        public PaymentService(IDatabaseChangeListener listener)
        {
            _listener = listener;
        }

        public ResponseModel<PaymentModel> Save(PaymentModel model)
        {
            using (var _context = new DatabaseContext())
            {
                var entity = model.MapToEntity();
                _context.Payment.Add(entity);
                model.Id = entity.Id;
                User user = null;
                if (model.UserId > 0)
                {
                    user = _context.User.Find(model.UserId);
                }
                // ----- Add Transaction of User ----- //
                var tempOrder = new Order
                {
                    TotalAmount = 0,
                    PaidAmount = model.Amount,
                    ReferenceNumber = $"Paid by {(string.IsNullOrEmpty(model.PaidBy)? (user?.Name??""): model.PaidBy)}",
                    UserId = user?.Id,
                    OrderType = "Sale",
                };
                var txn = OrderService.GetTransactionWithoutCommit(_context, tempOrder.MapToModel());
                if (user != null)
                {
                    user.Transactions.Add(txn);
                    user.PaymentDueDate = model.TotalAmount <= model.Amount ? null : user.PaymentDueDate;
                }
                _context.SaveChanges();
                
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

      
    }
}
