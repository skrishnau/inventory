using System;
using System.ComponentModel;
using System.Windows.Forms;
using IMS.Forms.Common;
using Service.Core.Business;
using Service.Listeners;
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
            this.ActiveControl = tbBranchName;

            InitializateValidation();
        }



        #region Initialization Functions

        private void InitializateValidation()
        {
            tbBranchName.Validating += TbBranchName_Validating;
        }

        #endregion



        #region Populating Functions

        public void SetData(BranchModel branch)
        {
            if (branch != null)
            {
                branchId = branch.Id;
                tbBranchName.Text = branch.Name;
                lblNote.Visible = false;
                this.Height = this.Height - 35;
                this.Text = "Branch Edit (" + branch.Name +")";
            }
            else
            {
                branchId = 0;
                tbBranchName.Text = "";
            }
        }

        #endregion



        #region Data Save Functions

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (IsModelValid())
            {
                var branchModel = new BranchModel
                {
                    Name = tbBranchName.Text,
                    Id = branchId,
                };
                //branchModel.Warehouses.Add(new WarehouseModel()
                //{
                //    CanMoveStocksToBranch = true,
                //    Code = tbBranchName.Text + "-W-01",// tbWarehouse.Text,
                //    CreatedAt = DateTime.Now,
                //    Location = tbBranchName.Text,
                //    UpdatedAt = DateTime.Now,
                //});

                branchModel.Counters.Add(new CounterModel()
                {
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Name = tbBranchName.Text + "-C-01", // tbCounter.Text,
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
        }

        #endregion



        #region Validations

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

        #endregion

    }
}

//private void tbBranchName_KeyPress(object sender, KeyPressEventArgs e)
//{
//    string branchShortcutName = "";
//    // get first four letters of branch and append with W-01
//    if (tbBranchName.Text.Length > 4)
//    {
//        branchShortcutName = tbBranchName.Text.Substring(0, 4);
//    }
//    else
//    {
//        branchShortcutName = tbBranchName.Text;
//    }
//    tbWarehouse.Text = branchShortcutName + "-W-01";
//    tbCounter.Text = branchShortcutName + "-C-01";
//}
