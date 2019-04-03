using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Orders
{
    public partial class OrdersMenuBar : UserControl
    {
        public OrdersMenuBar()
        {
            InitializeComponent();
        }

        public void ClearSelection()
        {
            btnSalesOrderList.FlatStyle = FlatStyle.Standard;
            btnPurchaseOrderList.FlatStyle = FlatStyle.Standard;
        }

    }
}
