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
        private readonly IInventoryService inventoryService;

        // dependency injection
        public InventoryUC(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;

            InitializeComponent();

            AddUserControls();

            InitializeEvents();
            PopulateBrandData();
            PopulateProductData();
            PopulateAttributetData();
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
            var brands = inventoryService.GetBrandList();
            dgvBrandList.DataSource = brands;
        }

       


        private void PopulateProductData()
        {
            dgvProductList.AutoGenerateColumns = false;
            var products = inventoryService.GetProductListForGridView();
            dgvProductList.DataSource = products;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var attributeCreate = Program.container.GetInstance<AttributeCreate>();
                attributeCreate.ShowInTaskbar = false;
                attributeCreate.ShowDialog();
                PopulateAttributetData();
            }
        }
        void PopulateAttributetData()
        {
            dataGridView1.AutoGenerateColumns = false;
            var attributes = inventoryService.GetAttributeList();
            dataGridView1.DataSource = attributes;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
            {
                var attribute = (ViewModel.Core.Inventory.AttributeModel)dataGridView1.SelectedRows[0].DataBoundItem;
                //button1_Click(sender, e);
                using (AsyncScopedLifestyle.BeginScope(Program.container))
                {
                    var attributeCreate = Program.container.GetInstance<AttributeCreate>();
                    attributeCreate.ShowInTaskbar = false;
                    attributeCreate.SetData(attribute);
                    attributeCreate.ShowDialog();
                    PopulateAttributetData();
                }

              

              //  PopulateAttributetData();
            }
            else
            {
                MessageBox.Show("Please Select Row!!!");
            }
        }
    }
}
