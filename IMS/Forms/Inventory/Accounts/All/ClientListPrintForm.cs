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
    public partial class ClientListPrintForm : Form
    {
        public event EventHandler LedgerPrinted;

        private readonly IAppSettingService _settingService;
        private readonly IUserService _userService;
        private ClientListMasterPrintModel _clientListMasterPrintModel;


        public ClientListPrintForm(IAppSettingService appSettingService, ClientListMasterPrintModel clientListMasterModel, IUserService userService)
        {
            this._settingService = appSettingService;
            this._clientListMasterPrintModel = clientListMasterModel;
            _userService = userService;

            InitializeComponent();

            this.Load += ClientListPrintForm_Load;
        }

        private void ClientListPrintForm_Load(object sender, EventArgs e)
        {

            var reportParams = GetReportParametersForClientList(_clientListMasterPrintModel);
            this.reportViewer1.LocalReport.SetParameters(reportParams);

            // datasource
            ReportDataSource reportDataSource = new ReportDataSource("ClientListDataset", _clientListMasterPrintModel.ClientList);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            this.reportViewer1.RefreshReport();
            
            
            
        }

       


        public IEnumerable<ReportParameter> GetReportParametersForClientList(ClientListMasterPrintModel model)
        {
            var reportParam = new List<ReportParameter>();
            var company = _settingService.GetCompanyInfoSetting();
            reportParam.Add(new ReportParameter("CompanyName", company.CompanyName));
            reportParam.Add(new ReportParameter("CompanyAddress", company.Address));
            reportParam.Add(new ReportParameter("CompanyPhone", company.Phone));

            //reportParam.Add(new ReportParameter("CustomerName", model.User));
            //reportParam.Add(new ReportParameter("CustomerAddress", model.Address));
            //reportParam.Add(new ReportParameter("CustomerPhone", model.Phone));

            reportParam.Add(new ReportParameter("UserType", model.UserType));
            reportParam.Add(new ReportParameter("SearchText", model.SearchText));

            //reportParam.Add(new ReportParameter("FromDate", model.FromDate));
            //reportParam.Add(new ReportParameter("ToDate", model.ToDate));
            reportParam.Add(new ReportParameter("DebitTotal", model.DebitSum));
            reportParam.Add(new ReportParameter("CreditTotal", model.CreditSum));
            reportParam.Add(new ReportParameter("DrCrTotal", model.DrCrString));
            reportParam.Add(new ReportParameter("BalanceTotal", model.BalanceSum));

            return reportParam.AsEnumerable();
        }

        private void ClientListPrintForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
