using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Inventory.Payment
{
    public partial class PaymentPrintUC : UserControl
    {
        public PaymentPrintUC()
        {
            InitializeComponent();

            this.Load += PaymentPrintUC_Load;
        }
        

        private void PaymentPrintUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            //var reportParams = GetReportParametersForSaleTransaction(_orderModel);
            //this.reportViewer1.LocalReport.SetParameters(reportParams);

            // datasource
            //ReportDataSource reportDataSource = new ReportDataSource("OrderItemDataset", _orderModel.OrderItems);
            //this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            this.reportViewer1.RefreshReport();

        }

        //public static IEnumerable<ReportParameter> GetReportParametersForSaleTransaction(OrderModel _orderModel)
        //{
        //    var reportParam = new List<ReportParameter>();

        //    string customerName = "", supplierName = "";
        //    if (_orderModel.OrderType == OrderTypeEnum.Sale.ToString())
        //        customerName = _orderModel.User;
        //    else if (_orderModel.OrderType == OrderTypeEnum.Purchase.ToString())
        //        supplierName = _orderModel.User;
        //    reportParam.Add(new ReportParameter("CustomerName", customerName));
        //    reportParam.Add(new ReportParameter("SupplierName", supplierName));

        //    reportParam.Add(new ReportParameter("CustomerPhone", _orderModel.Phone));
        //    reportParam.Add(new ReportParameter("ReferenceNumber", _orderModel.ReferenceNumber));

        //    reportParam.Add(new ReportParameter("IsCash", (_orderModel.IsCash).ToString()));
        //    reportParam.Add(new ReportParameter("IsCredit", (_orderModel.IsCredit).ToString()));

        //    reportParam.Add(new ReportParameter("Date", _orderModel.CompletedDate.HasValue ? _orderModel.CompletedDate.Value.ToString("yyyy/MM/dd") : ""));
        //    return reportParam.AsEnumerable();
        //}
    }
}
