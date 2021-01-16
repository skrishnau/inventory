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

        public void Save(PaymentModel model)
        {
            using (var _context = new DatabaseContext())
            {
                var entity = model.MapToEntity();
                _context.Payment.Add(entity);
                model.Id = entity.Id;
                User user = null;
                Order order = null;

                if (model.OrderId > 0)
                {
                    order = _context.Order.Find(model.OrderId);
                    if (order != null)
                    {
                        user = order.User;
                        model.UserId = order.UserId;
                        order.PaidAmount += model.Amount;
                        if (order.PaidAmount >= order.TotalAmount)
                        {
                            order.PaymentCompleteDate = DateTime.Now;
                        }
                    }
                }
                else if (model.UserId > 0)
                {
                    user = _context.User.Find(model.UserId);
                }
                var tempOrder = new Order
                {
                    TotalAmount = 0,
                    PaidAmount = model.Amount,
                    ReferenceNumber = $"Paid by {(string.IsNullOrEmpty(model.PaidBy)? user !=null ? user.Name : order?.ReferenceNumber: model.PaidBy)}",
                    UserId = user?.Id, //model.UserId,
                    Id = order?.Id??0,
                    OrderType = "Sale",
                };
                var txn = OrderService.GetTransactionWithoutCommit(_context, tempOrder.MapToModel());
                if (user != null)
                {
                    user.Transactions.Add(txn);
                    user.PaymentDueDate = model.TotalAmount <= model.Amount ? null : user.PaymentDueDate;
                }
                if (order != null)
                    order.Transactions.Add(txn);
                _context.SaveChanges();


                if (order != null)
                {
                    var orderModel = order.MapToModel();
                    BaseEventArgs<OrderModel> orderEventArgs = BaseEventArgs<OrderModel>.Instance;
                    orderEventArgs.Mode = Utility.UpdateMode.EDIT;
                    orderEventArgs.Model = orderModel;
                    _listener.TriggerOrderUpdateEvent(null, orderEventArgs);
                }
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
                eventArgs.Model = model;
                _listener.TriggerPaymentUpdateEvent(null, eventArgs);

            }
        }

      
    }
}
