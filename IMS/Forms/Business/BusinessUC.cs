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

namespace IMS.Forms.Business
{
    public partial class BusinessUC : UserControl
    {
        private readonly IBusinessService businessService;

        public BusinessUC(IBusinessService businessService)
        {
            this.businessService = businessService;
            InitializeComponent();
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
            var warehouses = businessService.GetWarehouseList();
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
                var wareHouseCreate = Program.container.GetInstance<WarehouseCreate>();
                wareHouseCreate.ShowInTaskbar = false;
                wareHouseCreate.ShowDialog();
                PopulateWarehouseData();
            }
        }
    }
}
