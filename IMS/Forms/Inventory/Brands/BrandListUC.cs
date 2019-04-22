using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleInjector.Lifestyles;
using Service.Core.Inventory;
using IMS.Forms.Inventory.Create;

namespace IMS.Forms.Inventory.Brands
{
    [Obsolete("Brand is not used anymore", true)]
    public partial class BrandListUC : UserControl
    {
        private readonly IInventoryService inventoryService;

        public BrandListUC(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;

            InitializeComponent();

            btnAddBrand.Click += BtnAddBrand_Click;

          //  PopulateBrandData();

        }

        private void BtnAddBrand_Click(object sender, EventArgs e)
        {
            ShowBrandAddDialog();
        }

        private void ShowBrandAddDialog()
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var brandCreate = Program.container.GetInstance<BrandCreate>();
                brandCreate.ShowInTaskbar = false;
                brandCreate.ShowDialog();
               // PopulateBrandData();
            }
        }
        //private void PopulateBrandData()
        //{
        //    dgvBrandList.AutoGenerateColumns = false;
        //    var brands = inventoryService.GetBrandList();
        //    dgvBrandList.DataSource = brands;
        //}

    }



}


