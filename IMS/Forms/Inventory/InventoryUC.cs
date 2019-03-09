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
            dgvProductList.CellContentDoubleClick += DgvProductList_CellContentDoubleClick;
            dgvAttributeList.CellDoubleClick += DgvAttributeList_CellDoubleClick;
            dgvAttributeList.CellMouseDown += dgvAttributeList_MouseClick;
            //dgvAttributeList.
        }

        private void DgvAttributeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAttributeList.SelectedRows != null && dgvAttributeList.SelectedRows.Count > 0)
            {
                var attributes = (AttributeModel)dgvAttributeList.SelectedRows[0].DataBoundItem;
                tbAttributeName.Text = attributes.Name.ToString();
                tbValue.Text = attributes.Value.ToString();

            }
        }

        private void DgvProductList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductList.SelectedRows != null && dgvProductList.SelectedRows.Count > 0)
            {
                var product = (ProductModelForGridView)dgvProductList.SelectedRows[0].DataBoundItem;

                lblProductName.Text = product.Name;//.ToString();

                //tbProductName.Text = products.Name.ToString();
                //tbAttributes.Text = 


            }
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
            dgvAttributeList.AutoGenerateColumns = false;
            var attributes = inventoryService.GetAttributeList();
            dgvAttributeList.DataSource = attributes;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAttributeList.SelectedRows != null && dgvAttributeList.SelectedRows.Count > 0)
            {
                var attribute = (ViewModel.Core.Inventory.AttributeModel)dgvAttributeList.SelectedRows[0].DataBoundItem;
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

        // Mouse right click event handler for datagridview
        private void dgvAttributeList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu menu = new ContextMenu();
                menu.MenuItems.Add(new MenuItem("Edit"));
                menu.MenuItems.Add(new MenuItem("Delete"));

                int currentMouseOverRow = dgvAttributeList.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {

                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAttributeList.SelectedRows != null && dgvAttributeList.SelectedRows.Count > 0)
            {
                var attribute = (ViewModel.Core.Inventory.AttributeModel)dgvAttributeList.SelectedRows[0].DataBoundItem;
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAttributeList.SelectedRows != null && dgvAttributeList.SelectedRows.Count > 0)
            {
                var attribute = (ViewModel.Core.Inventory.AttributeModel)dgvAttributeList.SelectedRows[0].DataBoundItem;
                inventoryService.DeleteAttribute(attribute);
                PopulateAttributetData();
            }
        }

        private void dgvProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProductList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductList.SelectedRows.Count > 0)
            {
                var data = (ProductModelForGridView)dgvProductList.SelectedRows[0].DataBoundItem;

                lblProductName.Text = data.Name;

            }
        }

        private void btnEditSKU_Click(object sender, EventArgs e)
        {

        }
    }
}
