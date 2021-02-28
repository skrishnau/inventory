using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ViewModel.Core.Orders;
using Service.Core.Settings;
using ViewModel.Utility;

namespace IMS.Forms.Inventory.Payment
{
    public partial class PaymentPrintUC : UserControl
    {
        private readonly IAppSettingService _settingService;

        PaymentModel _paymentModel;

        public PaymentPrintUC(IAppSettingService appSettingService, PaymentModel paymentModel)
        {
            this._settingService = appSettingService;
            this._paymentModel = paymentModel;
            InitializeComponent();

            this.Load += PaymentPrintUC_Load;
        }


        

        private void PaymentPrintUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            var reportParams = GetReportParametersForSaleTransaction(_paymentModel);
            this.reportViewer1.LocalReport.SetParameters(reportParams);

            // datasource
            //ReportDataSource reportDataSource = new ReportDataSource("OrderItemDataset", _orderModel.OrderItems);
            //this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            this.reportViewer1.RefreshReport();

        }

        public IEnumerable<ReportParameter> GetReportParametersForSaleTransaction(PaymentModel paymentModel)
        {
            var reportParam = new List<ReportParameter>();
            var company = _settingService.GetCompanyInfoSetting();
            reportParam.Add(new ReportParameter("CompanyName", company.CompanyName));
            reportParam.Add(new ReportParameter("CompanyAddress", company.Address));
            reportParam.Add(new ReportParameter("CompanyPhone", company.Phone));
            reportParam.Add(new ReportParameter("ReferenceNumber", paymentModel.ReferenceNumber));
            reportParam.Add(new ReportParameter("Date", DateConverter.Instance.ToBS(paymentModel.Date).ToString()));//.ToString("yyyy/MM/dd")));
            reportParam.Add(new ReportParameter("CustomerName", paymentModel.User));
            reportParam.Add(new ReportParameter("AmountInWords", NumberHelper.ConvertNumbertoWords((long) paymentModel.Amount) + " ONLY."));
            reportParam.Add(new ReportParameter("AmountInFigure", paymentModel.Amount.ToString("#,##,##0.00 /-")));
            reportParam.Add(new ReportParameter("Bank", string.IsNullOrEmpty(paymentModel.Bank)? "-": paymentModel.Bank));
            reportParam.Add(new ReportParameter("ChequeNumber", string.IsNullOrEmpty(paymentModel.ChequeNo) ? "-" : paymentModel.ChequeNo));
            reportParam.Add(new ReportParameter("PaymentType", paymentModel.PaymentType.ToString()));
            reportParam.Add(new ReportParameter("PaymentMethod", paymentModel.PaymentMethod.ToString()));
            reportParam.Add(new ReportParameter("DueAmount", (paymentModel.DueAmount).ToString("#,##,##0.00 /-")));

            return reportParam.AsEnumerable();
        }
    }
}
