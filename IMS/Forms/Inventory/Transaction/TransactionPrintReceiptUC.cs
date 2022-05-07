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
using ViewModel.Enums;
using IMS.Reports.Helpers;
using Service.Core.Settings;
using ViewModel.Utility;
using System.IO;

namespace IMS.Forms.Inventory.Transaction
{
    public partial class TransactionPrintReceiptUC : UserControl
    {
        private readonly IAppSettingService _appSettingService;
        private OrderModel _orderModel;

        public TransactionPrintReceiptUC(IAppSettingService appSettingService, OrderModel orderModel)
        {
            this._appSettingService = appSettingService;

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


            //var billPrintFormat = _appSettingService.GetAppSetting(AppSettingsKeys.TXN_BILL_PRINT_FORMAT.ToString())?.Value;
            var billPrintFormat = Constants.TXN_BILL_PRINT_FORMAT.ToString();
            if (string.IsNullOrEmpty(billPrintFormat))
            {
                billPrintFormat = TransactionBillPrintFormat.Double.ToString();
                //this.reportViewer1.LocalReport.ReportEmbeddedResource = "IMS.Reports.SalesTransactionReport_" + billPrintFormat+"Print.rdlc";
                //string exeFolder = Application.StartupPath;
                //string reportPath = Path.Combine(exeFolder, @"Reports\SalesTransactionReport_" + billPrintFormat + "Print.rdlc");
            }
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "IMS.Reports.SalesTransactionReport_" + billPrintFormat + "Print.rdlc";



            var reportParams = GetReportParametersForSaleTransaction(_orderModel);
            this.reportViewer1.LocalReport.SetParameters(reportParams);

            
            // datasource
            ReportDataSource reportDataSource = new ReportDataSource("OrderItemDataset", _orderModel.OrderItems);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            this.reportViewer1.RefreshReport();

        }

        public  IEnumerable<ReportParameter> GetReportParametersForSaleTransaction(OrderModel _orderModel)
        {
            var reportParam = new List<ReportParameter>();

            var company = _appSettingService.GetCompanyInfoSetting();
            reportParam.Add(new ReportParameter("CompanyName", company.CompanyName));
            reportParam.Add(new ReportParameter("CompanyAddress", company.Address));
            reportParam.Add(new ReportParameter("CompanyPhone", company.Phone));
            reportParam.Add(new ReportParameter("CompanyPan", company.PANNo));

            string customerName = "", supplierName = "";
            if (_orderModel.OrderType == OrderTypeEnum.Sale.ToString())
                customerName = _orderModel.User;
            else if (_orderModel.OrderType == OrderTypeEnum.Purchase.ToString())
                supplierName = _orderModel.User;
            reportParam.Add(new ReportParameter("CustomerName", customerName));
            reportParam.Add(new ReportParameter("SupplierName", supplierName));

            reportParam.Add(new ReportParameter("CustomerPhone", _orderModel.Phone));
            reportParam.Add(new ReportParameter("ReferenceNumber", _orderModel.ReferenceNumber));

            reportParam.Add(new ReportParameter("IsCash", (_orderModel.IsCash).ToString()));
            reportParam.Add(new ReportParameter("IsCredit", (_orderModel.IsCredit).ToString()));

            reportParam.Add(new ReportParameter("Date", _orderModel.CompletedDate.HasValue ? DateConverter.Instance.ToBS(_orderModel.CompletedDate.Value).ToString() : ""));//.ToString("yyyy/MM/dd") 

            var dueAmt = _orderModel.DueAmount;
            reportParam.Add(new ReportParameter("PaidAmount", _orderModel.PaidAmount.ToString("#.00")));
            reportParam.Add(new ReportParameter("DueAmount", dueAmt == 0 ? " - " : dueAmt.ToString("#.00")));

            reportParam.Add(new ReportParameter("DiscountAmount", (_orderModel.DiscountAmount).ToString("#.00")));
            reportParam.Add(new ReportParameter("DiscountPercent", _orderModel.DiscountPercent.ToString("#.00")));

            return reportParam.AsEnumerable();
        }
    }
}
