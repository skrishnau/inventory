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
using Service.Listeners;
using ViewModel.Core.Inventory;
using IMS.Forms.Inventory.Units;
using Service.Interfaces;

namespace IMS.Forms.Inventory.InventoryDetail
{
    public partial class InventoryDetailUC : UserControl
    {

        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;
        private readonly IDatabaseChangeListener _listener;


        public InventoryDetailUC(IInventoryService inventoryService, IProductService productService, IDatabaseChangeListener listener)
        {

            _inventoryService = inventoryService;
            _productService = productService;
            _listener = listener;

            InitializeComponent();

            this.Dock = DockStyle.Fill;



            this.Load += InventoryDetailUC_Load;
        }

        private void InventoryDetailUC_Load(object sender, EventArgs e)
        {
            this._heading.Text = "Inventory";

            this.dgvProductList.AutoGenerateColumns = false;
            this.dgvWarehouseProducts.AutoGenerateColumns = false;

            PopulateProductList();
            _listener.ProductUpdated += _listener_ProductUpdated;
            _listener.WarehouseUpdated += _listener_WarehouseUpdated;

            dgvProductList.SelectionChanged += DgvProductList_SelectionChanged;
            dgvWarehouseProducts.SelectionChanged += DgvWarehouseProducts_SelectionChanged;
        }

        private void DgvWarehouseProducts_SelectionChanged(object sender, EventArgs e)
        {
            //var inventoryUnitList = Program.container.GetInstance<InventoryUnitUC>();
            //pnlDetail.Controls.Add(inventoryUnitList);
            //inventoryUnitList.BringToFront();
        }

        #region Product List


        private void DgvProductList_SelectionChanged(object sender, EventArgs e)
        {
            ShowSelectedProductDetail();
        }

        private void _listener_ProductUpdated(object sender, Service.Listeners.Inventory.ProductEventArgs e)
        {
            PopulateProductList();
        }

        private ProductModel GetSelectedProduct()
        {
            return dgvProductList.SelectedRows.Count > 0 ?
                (ProductModel)dgvProductList.SelectedRows[0].DataBoundItem :
                null;
        }

        private void ShowSelectedProductDetail()
        {
            // show loading animation

            var product = GetSelectedProduct();
            if (product == null)
            {
                pnlDetail.Visible = false;
                return;
            }
            // if product is not null then...
            pnlDetail.Visible = true;
            lblProduct.Text = product.Name;
            lblSKU.Text = product.SKU;
            // load warehouse products
            PopulateWarehouseProductList();
        }

        private void PopulateProductList()
        {
            var products = _productService.GetAllProducts();
            dgvProductList.DataSource = products;
        }

        #endregion



        #region WarehouseProductList


        private void _listener_WarehouseUpdated(object sender, Service.DbEventArgs.BaseEventArgs<ViewModel.Core.Business.WarehouseModel> e)
        {
            PopulateWarehouseProductList();
        }


        private void PopulateWarehouseProductList()
        {
            var product = GetSelectedProduct();
            var warehouseProducts = _inventoryService.GetWarehouseProductList(0, product.Id);
            dgvWarehouseProducts.DataSource = warehouseProducts;
        }

        #endregion



       

      


       



    }
}
