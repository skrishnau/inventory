using IMS.Forms.Common.Base;
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
        OrderEditModel _editModel;
        bool _saveOrderImmediatelyAfterLoading;

        public TransactionCreateLargeForm()
        {
            InitializeComponent();
            this.Load += TransactionCreateLargeForm_Load;
        }

        public void SetDataForEdit(OrderEditModel editModel, bool saveOrderImmediatelyAfterLoading = false)//(OrderTypeEnum orderType, int orderId, bool showPrintView = false)
        {
            _editModel = editModel;
            _saveOrderImmediatelyAfterLoading = saveOrderImmediatelyAfterLoading;
        }

        private void TransactionCreateLargeForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ShowInTaskbar = true;
            var uc = Program.container.GetInstance<Transaction.TransactionCreateLargeUC>();
            //var orderEditModel = new OrderEditModel
            //{
            //    OrderType = OrderTypeEnum.Purchase,
            //    OrderId = 0,
            //    OrderOrDirect = OrderOrDirectEnum.Order
            //};
            uc.Dock = DockStyle.Fill;
            uc.SetDataForEdit(_editModel);//OrderTypeEnum.Purchase, 0
            //uc.ShowDialog();
            this.Controls.Add(uc);
            uc.CloseParentForm += Uc_CloseParentForm;
        }

        private void Uc_CloseParentForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
