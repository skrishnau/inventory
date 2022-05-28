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

namespace IMS.Forms.Inventory.Transaction
{
    public partial class TransactionAdvanceSearchForm : Form
    {
        public event EventHandler<TransactionAdvanceSearchEventArgs> DoneClicked;
        public TransactionAdvanceSearchForm()
        {
            InitializeComponent();
            btnDone.Click += BtnDone_Click;
            btnResetInputs.Click += BtnReset_Click;
            this.Load += TransactionAdvanceSearchForm_Load;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void TransactionAdvanceSearchForm_Load(object sender, EventArgs e)
        {
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            var args = new TransactionAdvanceSearchEventArgs();
            if (!string.IsNullOrWhiteSpace(dtDate.Text))
            {
                dtDate.Validate = true;
                if (dtDate.IsValid())
                {
                    args.NepaliDate = dtDate.Text;
                    args.Date = dtDate.GetValue();
                }
            }
            args.CashCredit = cmbCashCredit.SelectedItem as string;
            DoneClicked?.Invoke(this, args);
            this.Close();
        }

        internal void ClearInputs()
        {
            cmbCashCredit.SelectedItem = "Both";
            dtDate.Text = string.Empty;
        }
    }
    public class TransactionAdvanceSearchEventArgs : EventArgs
    {
        public string NepaliDate { get; set; }
        public DateTime? Date { get; set; }
        public string CashCredit { get; set; }

        public bool AreAllDataEmpty()
        {
            return Date == null && string.IsNullOrWhiteSpace(CashCredit);
        }
    }
}
