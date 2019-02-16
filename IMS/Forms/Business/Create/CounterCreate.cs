using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Business;
using ViewModel.Core.Business;

namespace IMS.Forms.Business.Create
{
    public partial class CounterCreate : Form
    {
        private readonly IBusinessService businessService;
        public CounterCreate(IBusinessService businessService)
        {
            this.businessService = businessService;
            InitializeComponent();
            PopulateBranchCombo();
        }

        private void PopulateBranchCombo()
        {
            cbBranchId.FlatStyle = FlatStyle.Popup;
            cbBranchId.DropDownStyle = ComboBoxStyle.DropDownList;
            var branches = businessService.GetBranchList();
            cbBranchId.DataSource = branches;
            cbBranchId.ValueMember = "Id";
            cbBranchId.DisplayMember = "Name";
            //cbBranchId.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(tbName.Text == "" )
            {
                tbName.BackColor = Color.LightPink;
                return;
            }
            var counterModel = new CounterModel
            {
                BranchId = int.Parse(cbBranchId.SelectedValue.ToString()),
                Name = tbName.Text, 
                OutOfOrder = cbOutOfOrder.Checked
            };
            businessService.AddOrUpdateCounter(counterModel);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
