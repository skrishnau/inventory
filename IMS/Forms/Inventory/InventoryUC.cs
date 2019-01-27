using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Inventory.Create;
using Service.Core.Inventory;
using SimpleInjector.Lifestyles;
using ViewModel.Core.Inventory;
using IMS.Forms.Inventory.Lists;
using IMS.Forms.Inventory.Lists.Category;

namespace IMS.Forms.Inventory
{
    public partial class InventoryUC : UserControl
    {
        private readonly IInventoryService productService;

        // dependency injection
        public InventoryUC(IInventoryService productService)
        {
            this.productService = productService;

            InitializeComponent();

            AddUserControls();

            InitializeEvents();
            PopulateBrandData();
            PopulateProductData();
        }

        private void AddUserControls()
        {
            var categoryListUC = Program.container.GetInstance<CategoryListUC>();
            categoryListUC.Dock = DockStyle.Fill;
            tabCategories.Controls.Add(categoryListUC);
        }

        private void InitializeEvents()
        {
            btnAddProduct.Click += BtnAddProduct_Click;
            btnAddBrand.Click += BtnAddBrand_Click;
           
        }

    

        private void BtnAddBrand_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var brandCreate = Program.container.GetInstance<BrandCreate>();
                brandCreate.ShowInTaskbar = false;
                brandCreate.ShowDialog();
                PopulateBrandData();
            }
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var productCreate = Program.container.GetInstance<ProductCreate>();
                productCreate.ShowInTaskbar = false;
                productCreate.ShowDialog();
                PopulateProductData();
            }
        }

       

        private void PopulateBrandData()
        {
            dgvBrandList.AutoGenerateColumns = false;
            var brands = productService.GetBrandList();
            dgvBrandList.DataSource = brands;
        }

       


        private void PopulateProductData()
        {
            dgvProductList.AutoGenerateColumns = false;
            var products = productService.GetProductList();
            dgvProductList.DataSource = products;
        }

    }
}
