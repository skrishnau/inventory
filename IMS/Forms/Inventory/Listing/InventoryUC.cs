using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Product.Details;
using IMS.Forms.Inventory.Create;

namespace IMS.Forms.Inventory.Listing
{
    public partial class InventoryUC : UserControl
    {
        private readonly IProductService productService;


        public InventoryUC()
        {
            productService = new ProductService();

            InitializeComponent();
            
            InitializeListeners();

            PopulateBrandData();

            PopulateCategoryData();

            PopulateProductData();
        }


        private void InitializeListeners()
        {
            btnAddProduct.Click += BtnAddProduct_Click;
            btnAddBrand.Click += BtnAddBrand_Click;
            btnAddCategory.Click += BtnAddCategory_Click;
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            var categoryCreate = new CategoryCreate();
            categoryCreate.ShowInTaskbar = false;
            categoryCreate.ShowDialog();
            PopulateCategoryData();
        }

        private void BtnAddBrand_Click(object sender, EventArgs e)
        {
            var brandCreate = new BrandCreate();
            brandCreate.ShowInTaskbar = false;
            brandCreate.ShowDialog();
            PopulateBrandData();
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            var productCreate = new ProductCreate();
            productCreate.ShowInTaskbar = false;
            productCreate.ShowDialog();
            PopulateProductData();
        }

        private void PopulateBrandData()
        {
            dgvBrandList.AutoGenerateColumns = false;
            var brands = productService.GetBrandList();
            dgvBrandList.DataSource = brands;
        }

        private void PopulateCategoryData()
        {
            dgvCategoryList.AutoGenerateColumns = false;
            var categories= productService.GetCategoryList();
            dgvCategoryList.DataSource = categories;
        }


        private void PopulateProductData()
        {
            dgvProductList.AutoGenerateColumns = false;
            var products = productService.GetProductList();
            dgvProductList.DataSource = products;
        }

    }
}
