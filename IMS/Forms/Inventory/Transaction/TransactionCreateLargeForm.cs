using IMS.Forms.Common.Base;
using Service.Core.Settings;
using Service.DbEventArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Orders;
using ViewModel.Enums;

namespace IMS.Forms.Inventory.Transaction
{
    public partial class TransactionCreateLargeForm : BaseDialogForm
    {

        private readonly IAppSettingService _appSettingService;

        OrderEditModel _editModel;
        bool _saveOrderImmediatelyAfterLoading;

        

        public TransactionCreateLargeForm(IAppSettingService appSettingService)
        {
            _appSettingService = appSettingService;

            InitializeComponent();
            this.Load += TransactionCreateLargeForm_Load;
        }

        public void SetDataForEdit(OrderEditModel editModel, bool saveOrderImmediatelyAfterLoading = false)
        {
            _editModel = editModel;
            _saveOrderImmediatelyAfterLoading = saveOrderImmediatelyAfterLoading;
        }

        private async void TransactionCreateLargeForm_Load(object sender, EventArgs e)
        {
            this.Text = _editModel.OrderType.ToString() + " Transaction";
            var showTransactionCreateInFullPage = await _appSettingService.GetShowTransactionCreateInFullPage();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Icon = Properties.Resources.ims_icon;
            if (showTransactionCreateInFullPage)
            {
                this.ShowInTaskbar = true;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.ShowInTaskbar = false;
            }
            var uc = Program.container.GetInstance<Transaction.TransactionCreateLargeUC>();
            
            uc.Dock = DockStyle.Fill;
            uc.SetDataForEdit(_editModel);//OrderTypeEnum.Purchase, 0
            //uc.ShowDialog();
            this.Controls.Add(uc);
            uc.CloseParentForm -= Uc_CloseParentForm;
            uc.CloseParentForm += Uc_CloseParentForm;
        }

        private async void Uc_CloseParentForm(object sender, IdEventArgs e)
        {
            if(e.Id > 0)
            {
                // reset
                if (await _appSettingService.GetIsTransactionCreatePageLocked())
                {
                    this.Controls.Clear();
                    TransactionCreateLargeForm_Load(this, EventArgs.Empty);
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}
