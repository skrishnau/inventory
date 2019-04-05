using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using IMS.Forms.Common;
using Service.Core.Business;
using Service.Listeners;
using Service.Listeners.Business;
using ViewModel.Core.Business;

namespace IMS.Forms.Business.Create
{
    public partial class BranchCreate : Form
    {
        private readonly IBusinessService businessService;
        private readonly IDatabaseChangeListener _listener;

        private int branchId;
        // private int warehouseId;

        
        public BranchCreate(IBusinessService businessService, IDatabaseChangeListener listener)
        {
            this.businessService = businessService;
            this._listener = listener;
            InitializeComponent();
            this.ActiveControl = tbBranchName;

            AddValidation();
        }

        private void AddValidation()
        {
            tbBranchName.Validating += TbBranchName_Validating;
        }

        private void TbBranchName_Validating(object sender, CancelEventArgs e)
        {
            ValidateBranch();
        }

        private bool ValidateBranch()
        {
            if (string.IsNullOrEmpty(tbBranchName.Text))
            {
                errorProvider1.SetError(tbBranchName, "Required");
                return false;
            }
            errorProvider1.SetError(tbBranchName, "");
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsModelValid())
            {
                var branchModel = new BranchModel
                {
                    Name = tbBranchName.Text,

                };
                branchModel.Warehouses.Add(new WarehouseModel()
                {
                    CanMoveStocksToBranch = true,
                    Code = tbWarehouse.Text,
                    CreatedAt = DateTime.Now,
                    Location = tbBranchName.Text,
                    UpdatedAt = DateTime.Now,
                });

                branchModel.Counters.Add(new CounterModel()
                {
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Name = tbCounter.Text,
                    OutOfOrder = false,
                });

                businessService.AddOrUpdateBranch(branchModel);
                this.Close();
            }
            else
            {
                PopupMessage.ShowMissingInputsMessage();
            }
        }

        private bool IsModelValid()
        {
            return ValidateBranch();
            if (tbBranchName.Text == "")
            {
                tbBranchName.BackColor = Color.LightPink;
                return false;
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

        private void tbBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            string branchShortcutName = "";
            // get first four letters of branch and append with W-01
            if (tbBranchName.Text.Length > 4)
            {
                branchShortcutName = tbBranchName.Text.Substring(0, 4);
            }
            else
            {
                branchShortcutName = tbBranchName.Text;
            }
            tbWarehouse.Text = branchShortcutName + "-W-01";
            tbCounter.Text = branchShortcutName + "-C-01";
        }

        internal void SetData(BranchModel branch)
        {
            branchId = branch.Id;
            tbBranchName.Text = branch.Name;
        }
    }
}
