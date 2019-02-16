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
    public partial class WarehouseCreate : Form
    {
        private readonly IBusinessService businessService;
        public WarehouseCreate(IBusinessService businessService)
        {
            this.businessService = businessService;
            InitializeComponent();
            PopulateBranchCombo();
        }

        public void PopulateBranchCombo()
        {
            cbBranch.FlatStyle = FlatStyle.Popup;
            cbBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            var branches = businessService.GetBranchList();
            cbBranch.DataSource = branches;
            cbBranch.ValueMember = "Id";
            cbBranch.DisplayMember = "Name";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(tbLocation.Text == "")
            {
                tbLocation.BackColor = Color.LightPink;
                return;
            }
            if(tbCode.Text == "")
            {
                tbCode.BackColor = Color.LightPink;
                return;
            }
            var warehouseModel = new WarehouseModel
            {
                Location = tbLocation.Text,
                Code = tbCode.Text,
                BranchId = int.Parse(cbBranch.SelectedValue.ToString()),
                CanMoveStocksToBranch = cbCanMoveStock.Checked
            };
            businessService.AddOrUpdateWarehouse(warehouseModel);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
