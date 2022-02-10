using Microsoft.Reporting.WinForms;
using Service.Core.Settings;
using Service.Core.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Reports;

namespace IMS.Forms.Inventory.Accounts.All
{
    public partial class LedgerPrintForm : Form
    {
        public event EventHandler LedgerPrinted;

        private readonly IAppSettingService _settingService;
        private readonly IUserService _userService;
        private LedgerMasterModel _ledgerMasterModel;


        public LedgerPrintForm(IAppSettingService appSettingService, LedgerMasterModel ledgerMasterModel, IUserService userService)
        {
            this._settingService = appSettingService;
            this._ledgerMasterModel = ledgerMasterModel;
            _userService = userService;

            InitializeComponent();

            this.Load += LedgerPrintForm_Load;
        }

        private void LedgerPrintForm_Load(object sender, EventArgs e)
        {

            var reportParams = GetReportParametersForSaleTransaction(_ledgerMasterModel);
            this.reportViewer1.LocalReport.SetParameters(reportParams);

            // datasource
            ReportDataSource reportDataSource = new ReportDataSource("LedgerDataset", _ledgerMasterModel.LedgerData);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            this.reportViewer1.RefreshReport();
            
            this.reportViewer1.PrintingBegin += ReportViewer1_PrintingBegin;
            
        }

        private void ReportViewer1_PrintingBegin(object sender, ReportPrintEventArgs e)
        {
            var printed = _userService.SaveLedgerPrintDate(_ledgerMasterModel.UserId);
            if (printed)
            {
                LedgerPrinted?.Invoke(this, new EventArgs());
            }
        }


        public IEnumerable<ReportParameter> GetReportParametersForSaleTransaction(LedgerMasterModel model)
        {
            var reportParam = new List<ReportParameter>();
            var company = _settingService.GetCompanyInfoSetting();
            reportParam.Add(new ReportParameter("CompanyName", company.CompanyName));
            reportParam.Add(new ReportParameter("CompanyAddress", company.Address));
            reportParam.Add(new ReportParameter("CompanyPhone", company.Phone));

            reportParam.Add(new ReportParameter("CustomerName", model.User));
            reportParam.Add(new ReportParameter("CustomerAddress", model.Address));
            reportParam.Add(new ReportParameter("CustomerPhone", model.Phone));
            reportParam.Add(new ReportParameter("FromDate", model.FromDate));
            reportParam.Add(new ReportParameter("ToDate", model.ToDate));
            reportParam.Add(new ReportParameter("DebitTotal", model.DebitSum));
            reportParam.Add(new ReportParameter("CreditTotal", model.CreditSum));
            reportParam.Add(new ReportParameter("DrCrTotal", model.DrCrString));
            reportParam.Add(new ReportParameter("BalanceTotal", model.BalanceSum));

            return reportParam.AsEnumerable();
        }
    }
}
