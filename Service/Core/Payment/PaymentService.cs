using DTO.Core.Inventory;
using Infrastructure.Context;
using Service.DbEventArgs;
using Service.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Orders;
using ViewModel.Core.Users;

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

                if (model.OrderId > 0)
                {
                    var order = _context.Order.Find(model.OrderId);
                    if (order != null)
                    {
                        model.UserId = order.UserId;
                        order.PaidAmount += model.Amount;
                        if (order.PaidAmount >= order.TotalAmount)
                        {
                            order.PaymentCompleteDate = DateTime.Now;
                        }
                        _context.SaveChanges();

                        var orderModel = order.MapToModel();
                        BaseEventArgs<OrderModel> orderEventArgs = BaseEventArgs<OrderModel>.Instance;
                        orderEventArgs.Mode = Utility.UpdateMode.EDIT;
                        orderEventArgs.Model = orderModel;
                        _listener.TriggerOrderUpdateEvent(null, orderEventArgs);
                    }
                }
                if (model.UserId > 0)
                {
                    var user = _context.User.Find(model.UserId);
                    if (user != null)
                    {
                        user.PaidAmount += model.Amount;
                        _context.SaveChanges();

                        var userModel = UserMapper.MapToUserModel(user);
                        BaseEventArgs<UserModel> userEventArgs = BaseEventArgs<UserModel>.Instance;
                        userEventArgs.Mode = Utility.UpdateMode.EDIT;
                        userEventArgs.Model = userModel;
                        _listener.TriggerUserUpdateEvent(null, userEventArgs);
                    }
                }


                BaseEventArgs<PaymentModel> eventArgs = BaseEventArgs<PaymentModel>.Instance;
                eventArgs.Mode = Utility.UpdateMode.ADD;
                eventArgs.Model = model;
                _listener.TriggerPaymentUpdateEvent(null, eventArgs);

            }
        }
    }
}
