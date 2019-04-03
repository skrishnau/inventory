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
    public partial class BranchCreate : Form
    {
        private readonly IBusinessService businessService;

        private int branchId;
        // private int warehouseId;

        public BranchCreate(IBusinessService businessService)
        {
            this.businessService = businessService;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbBranchName.Text == "")
            {
                tbBranchName.BackColor = Color.LightPink;
                return;
            }
            var branchModel = new BranchModel
            {
                Name = tbBranchName.Text,
                Id = branchId,
                Warehouses = new List<WarehouseModel>()
                {
                    new WarehouseModel()
                    {
                        //Id = warehouseId,
                       // BranchId = update,
                        CanMoveStocksToBranch = true,
                        Code = tbBranchName.Text + "Warehouse",
                        Location = tbBranchName.Text,

                    }
                }
            };

            var update = businessService.AddOrUpdateBranch(branchModel);

            /*
            if (update == 0)
            {
                MessageBox.Show(this, "Branch Name " + tbBranchName.Text + " is already in database.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //MessageBox.Show("Branch Name " + tbBranchName.Text + " is already in database.");
                return;
            }
            //var branchEntity = businessService.GetBranchWithId()

            // to add warehouse
            var warehouseModel = new WarehouseModel()
            {
                //Id = warehouseId,
                BranchId = update,
                CanMoveStocksToBranch = true,
                Code = tbBranchName.Text + "Warehouse",
                Location = tbBranchName.Text,

            };

            businessService.AddOrUpdateWarehouse(warehouseModel);
            */
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void SetData(BranchModel branch)
        {
            branchId = branch.Id;
            tbBranchName.Text = branch.Name;
        }
    }
}
