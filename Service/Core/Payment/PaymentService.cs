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

                var order = _context.Order.Find(model.OrderId);
                order.PaidAmount += model.Amount;
                if (order.PaidAmount >= order.TotalAmount)
                {
                    order.PaymentCompleteDate = DateTime.Now;
                }

                _context.SaveChanges();

                BaseEventArgs<PaymentModel> eventArgs = BaseEventArgs<PaymentModel>.Instance;
                eventArgs.Mode = Utility.UpdateMode.ADD;
                eventArgs.Model = model;
                _listener.TriggerPaymentUpdateEvent(null, eventArgs);


                var orderModel = order.MapToModel();
                BaseEventArgs<OrderModel> orderEventArgs = BaseEventArgs<OrderModel>.Instance;
                orderEventArgs.Mode = Utility.UpdateMode.EDIT;
                orderEventArgs.Model = orderModel;
                _listener.TriggerOrderUpdateEvent(null, orderEventArgs);

            }
        }
    }
}
