using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Core.Purchases;

namespace IMS.ControlEventArgs
{
    public class PurchaseOrderEventArgs:EventArgs
    {
        public PurchaseOrderModel Model{ get; set; }
    }
}
