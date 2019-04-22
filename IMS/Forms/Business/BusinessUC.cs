using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Business.Create;
using SimpleInjector.Lifestyles;
using Service.Core.Business;
using ViewModel.Core.Business;
using IMS.Forms.Business.Delete;
using IMS.Forms.Common;
using Service.Core.Inventory;
using IMS.Forms.Inventory.Warehouses;

namespace IMS.Forms.Business
{
    public partial class BusinessUC : UserControl
    {
        private readonly IBusinessService businessService;
        private readonly IInventoryService _inventoryService;

        public BusinessUC(IBusinessService businessService, IInventoryService inventoryService)
        {
            this.businessService = businessService;
            _inventoryService = inventoryService;

            InitializeComponent();
            this.Load += BusinessUC_Load;


        }

        private void BusinessUC_Load(object sender, EventArgs e)
        {
            PopulateBranchData();
            PopulateCounterData();
            PopulateWarehouseData();
        }

        private void btnAddBrand_Click(object sender, EventArgs e) //Add Branch (not brand)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var branchCreate = Program.container.GetInstance<BranchCreate>();
                branchCreate.ShowInTaskbar = false;
                branchCreate.ShowDialog();
                PopulateBranchData();

                //Also populate warehousedata since warehouse with same name is created
                // when new branch is added
                PopulateWarehouseData();

            }

        }

        private void PopulateBranchData()
        {
            gvBranch.AutoGenerateColumns = false;
            var branchs = businessService.GetBranchList();
            gvBranch.DataSource = branchs;
        }

        private void PopulateCounterData()
        {
            gvCounter.AutoGenerateColumns = false;
            var counters = businessService.GetCounterList();
            gvCounter.DataSource = counters;
        }

        private void PopulateWarehouseData()
        {
            gvWarehouse.AutoGenerateColumns = false;
            var warehouses = _inventoryService.GetWarehouseList();
            gvWarehouse.DataSource = warehouses;
        }

        private void btnAddCounter_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var counterCreate = Program.container.GetInstance<CounterCreate>();
                counterCreate.ShowInTaskbar = false;
                counterCreate.ShowDialog();
                PopulateCounterData();

            }


        }

        private void btnAddWarehouse_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var wareHouseCreate = Program.container.GetInstance<WarehouseCreateForm>();
                wareHouseCreate.ShowInTaskbar = false;
                wareHouseCreate.ShowDialog();
                PopulateWarehouseData();
            }
        }

        //edit branch
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var branch = (BranchModel)gvBranch.SelectedRows[0].DataBoundItem;
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var branchCreate = Program.container.GetInstance<BranchCreate>();
                branchCreate.ShowInTaskbar = false;
                branchCreate.SetData(branch);
                branchCreate.ShowDialog();
                PopulateBranchData();
            }
        }

        //private void btnDeleteBranch_Click(object sender, EventArgs e)
        //{
        //    var  branch = (BranchModel)gvBranch.SelectedRows[0].DataBoundItem;
        //    /*using (AsyncScopedLifestyle.BeginScope(Program.container))
        //    {
        //        var branchDelete = Program.container.GetInstance<BranchDeleteConfirmationForm>();
        //        branchDelete.ShowInTaskbar = false;
        //        branchDelete.SetData(branch);
        //        branchDelete.ShowDialog();
        //        PopulateBranchData();
        //    } */
        //    //var branchDelete = new BranchDeleteConfirmationForm(businessService, branch);

        //    var result = MessageBox.Show(this, "Are you sure to delete branch " + branch.Name + "?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        //    if (result.Equals(DialogResult.Yes))
        //    {
        //        //branchDelete.ShowInTaskbar = false;
        //        //branchDelete.SetData(branch);
        //        //branchDelete.ShowDialog();
        //       // businessService.DeleteBranch(branch.Id);
        //        //MessageBox.Show("Branch Deleted!!!");
        //        PopupMessage.ShowPopupMessage("Delete Success", "Branch is successfully deleted!", PopupMessageType.SUCCESS);
        //        PopulateBranchData();
        //    }
        //}
    }
}
