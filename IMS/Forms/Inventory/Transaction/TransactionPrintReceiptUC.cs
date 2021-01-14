using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Orders;
using Microsoft.Reporting.WinForms;

namespace IMS.Forms.Inventory.Transaction
{
    public partial class TransactionPrintReceiptUC : UserControl
    {
        private OrderModel _orderModel;

        public TransactionPrintReceiptUC(OrderModel orderModel)
        {
            InitializeComponent();

            this._orderModel = orderModel;
            this.Load += TransactionPrintReceiptUC_Load;
        }


        public OrderModel GetOrder()
        {
            return _orderModel;
        }

        private void TransactionPrintReceiptUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            var reportParam = new List<ReportParameter>();
            reportParam.Add(new ReportParameter("CustomerName", _orderModel.User));
            reportParam.Add(new ReportParameter("CustomerPhone", _orderModel.Phone));
            reportParam.Add(new ReportParameter("Date", _orderModel.CompletedDate.HasValue ? _orderModel.CompletedDate.Value.ToString("yyyy/MM/dd") : ""));
            this.reportViewer1.LocalReport.SetParameters(reportParam.AsEnumerable());

            // datasource
            ReportDataSource reportDataSource = new ReportDataSource("OrderItemDataset", _orderModel.OrderItems);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            this.reportViewer1.RefreshReport();

        }
    }
}
