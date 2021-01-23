using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core;
using ViewModel.Core.Orders;
using ViewModel.Enums;

namespace Service.Core.Payment
{
    public interface IPaymentService
    {
        ResponseModel<PaymentModel> Save(PaymentModel model);
        int GetAllPaymentsCount(ClientTypeEnum clientType, string searchName);
        PaymentListModel GetAllPayments(ClientTypeEnum clientType, int pageSize, int offset, string searchName);
    }
}
