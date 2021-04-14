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
using Service.Core.Inventory.Units;
using Service.Listeners;
using Service.Interfaces;
using ViewModel.Core.Common;
using IMS.Forms.Common.Pagination;

namespace IMS.Forms.Inventory.Units.Details
{
    public partial class InventoryMovementUC : UserControl
    {
        private readonly IInventoryUnitService _inventoryUnitService;
        private readonly IDatabaseChangeListener _listener;
        private readonly IProductService _productService;

        BindingSource _bindingSource = new BindingSource();
        private MovementListPaginationHelper helper;

        public InventoryMovementUC(IInventoryUnitService inventoryUnitService, IDatabaseChangeListener listener, IProductService productService)
        {
            _inventoryUnitService = inventoryUnitService;
            _productService = productService;
            _listener = listener;
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            this.Load += InventoryMovementUC_Load;
        }

        private void InventoryMovementUC_Load(object sender, EventArgs e)
        {
            dgvMovement.AutoGenerateColumns = false;
            helper = new MovementListPaginationHelper(_bindingSource, dgvMovement, bindingNavigator1, _inventoryUnitService, 0);


            PopulateMovements();

            PopulateProducts();


            _listener.InventoryUnitUpdated += _listener_InventoryUnitUpdated;
            cbProduct.SelectedValueChanged += CbProduct_SelectedValueChanged;
        }
        private void PopulateProducts()
        {
            var products = _productService.GetProductListForCombo();
            var allProduct = new IdNamePair { Id = 0, Name = " ---- All ---- " };
            products.Insert(0, allProduct);
            cbProduct.DataSource = products;
            cbProduct.DisplayMember = "Name";
            cbProduct.ValueMember = "Id";
        }
        private void _listener_InventoryUnitUpdated(object sender, Service.DbEventArgs.BaseEventArgs<List<ViewModel.Core.Inventory.InventoryUnitModel>> e)
        {
            PopulateMovements();
        }

        private void PopulateMovements()
        {
            int productId = 0;
            int.TryParse(cbProduct.SelectedValue?.ToString()??"" , out productId);
            //var movements = _inventoryUnitService.GetMovementList(productId);
            //dgvMovement.DataSource = movements;
            if (helper != null)
                helper.Reset(productId);
        }
        private void CbProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateMovements();
        }
    }
}
