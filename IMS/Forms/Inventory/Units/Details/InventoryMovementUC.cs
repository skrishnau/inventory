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
using IMS.Forms.Common;

namespace IMS.Forms.Inventory.Units.Details
{
    public partial class InventoryMovementUC : BaseUserControl
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
            dtDate.SetValue(DateTime.Now);
            dgvMovement.AutoGenerateColumns = false;
            helper = new MovementListPaginationHelper(_bindingSource, dgvMovement, bindingNavigator1, _inventoryUnitService, 0, null);


            PopulateMovements();

            PopulateProducts();


            _listener.InventoryUnitUpdated += _listener_InventoryUnitUpdated;
            _listener.ProductUpdated += _listener_ProductUpdated;
            cbProduct.SelectedValueChanged += CbProduct_SelectedValueChanged;
            dgvMovement.DataSourceChanged += DgvMovement_DataSourceChanged;
            dtDate.TextChanged += DtDate_TextChanged;
            chkDateSelected.CheckedChanged += ChkDateSelected_CheckedChanged;
        }

        private void ChkDateSelected_CheckedChanged(object sender, EventArgs e)
        {
            dtDate.Enabled = chkDateSelected.Checked;
            PopulateMovements();
        }

        private void DtDate_TextChanged(object sender, EventArgs e)
        {
            PopulateMovements();
        }

        private void _listener_ProductUpdated(object sender, Service.Listeners.Inventory.ProductEventArgs e)
        {
            AddListenerAction(PopulateProducts, e);
        }

        private void DgvMovement_DataSourceChanged(object sender, EventArgs e)
        {
            PaginationHelper.SetRowNumber(dgvMovement, helper.offset);
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
            AddListenerAction(PopulateMovements, e);
        }

        private void PopulateMovements()
        {
            int productId = 0;
            int.TryParse(cbProduct.SelectedValue?.ToString() ?? "", out productId);
            DateTime? date = null;
            if (chkDateSelected.Checked)
            {
                dtDate.Validate = true;
                date = dtDate.GetValue();
                if (!dtDate.IsValid())
                {
                    PopupMessage.ShowInfoMessage("Invalid date");
                    this.Focus();
                    return;
                }
            }
            //var movements = _inventoryUnitService.GetMovementList(productId);
            //dgvMovement.DataSource = movements;
            if (helper != null)
                helper.Reset(productId, date);

        }
        private void CbProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateMovements();
        }
    }
}
