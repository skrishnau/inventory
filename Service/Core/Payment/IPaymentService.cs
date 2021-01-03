using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Orders;

namespace Service.Core.Payment
{
    public interface IPaymentService
    {
        void Save(PaymentModel model);
    }
}
