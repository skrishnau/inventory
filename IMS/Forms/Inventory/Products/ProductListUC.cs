using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Inventory;
using SimpleInjector.Lifestyles;
using IMS.Forms.Inventory.Create;
using IMS.Forms.Inventory.Variants;
using ViewModel.Core.Inventory;
using IMS.Forms.Common.Display;

namespace IMS.Forms.Inventory.Products
{
    public partial class ProductListUC : UserControl
    {
        private readonly IInventoryService inventoryService;

        private ProductModelForGridView _selectedProduct;
        private SubHeadingTemplate _header;

        public ProductListUC(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;

            InitializeComponent();
            // use Header template to display header.
            InitializeHeader();

             PopulateProductData();
            PopulateSKUGridView();

            dgvProductList.CellContentDoubleClick += DgvProductList_CellContentDoubleClick;

        }

        private void InitializeHeader()
        {
            _header = SubHeadingTemplate.Instance;
            _header.btnNew.Visible = true;
            _header.btnNew.Click += BtnAddProduct_Click;
            this.Controls.Add(_header);
            _header.SendToBack();
            // header text
            _header.lblHeading.Text = "Products";
        }

        public void PopulateSKUGridView()
        {
            var skus = inventoryService.GetVariantList();
            dgvSKUListing.AutoGenerateColumns = false;
            dgvSKUListing.DataSource = skus;
        }

        private void btnEditSKU_Click(object sender, EventArgs e)
        {
            //var skuEditForm = new VariantEditForm(inventoryService, _selectedProduct.Id);
            //skuEditForm.ShowDialog();
            //PopulateProductData();
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            ShowProductAddDialog();
        }

        private void ShowProductAddDialog()
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var productCreate = Program.container.GetInstance<ProductCreate>();
                productCreate.ShowInTaskbar = false;
                productCreate.ShowDialog();
                PopulateProductData();
            }
        }

        private void PopulateProductData()
        {
            dgvProductList.AutoGenerateColumns = false;
            var products = inventoryService.GetProductListForGridView();
            dgvProductList.DataSource = products;
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

        private void dgvProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProductList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductList.SelectedRows.Count > 0)
            {
                var data = (ProductModelForGridView)dgvProductList.SelectedRows[0].DataBoundItem;
                _selectedProduct = data;
                lblProductName.Text = data.Name;
                lblCategory.Text = data.Category;
                lblBrandName.Text = data.Brands;
               // var attributeList = inventoryService.GetOptionList(data.Id);
                lblProperties.Text = "";

                //foreach (var att in attributeList)
                //{

                //    lblProperties.Text += att.Name + " " + att.Value + "\n";
                //}

            }
        }

        private void btnAddProduct_Click_1(object sender, EventArgs e)
        {

        }

        //private void BtnAddProduct_Click(object sender, EventArgs e)
        //{
        //    using (AsyncScopedLifestyle.BeginScope(Program.container))
        //    {
        //        var productCreate = Program.container.GetInstance<ProductCreate>();
        //        productCreate.ShowInTaskbar = false;
        //        productCreate.ShowDialog();
        //        PopulateProductData();
        //    }
        //}
    }
}
