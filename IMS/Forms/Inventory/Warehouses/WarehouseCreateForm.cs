using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Business;
using Service.Core.Inventory;
using ViewModel.Core.Business;

namespace IMS.Forms.Inventory.Warehouses
{
    public partial class WarehouseCreateForm : Form
    {
        private readonly IInventoryService _inventoryService;

        private int _warehouseId;

        public WarehouseCreateForm(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
            InitializeComponent();

            InitializeValidationEvents();
        }


        #region Initializations

        private void InitializeValidationEvents()
        {
            tbLocation.Validated += TbLocation_Validated;
        }

        #endregion


        #region Validation Events & Functions

        private void TbLocation_Validated(object sender, EventArgs e)
        {
            ValidateLocation();
        }

        private bool ValidateLocation()
        {
            if (string.IsNullOrEmpty(tbLocation.Text))
            {
                errorProvider1.SetError(tbLocation, "Required");
                return false;
            }
            errorProvider1.SetError(tbLocation, "");
            return true;
        }

        #endregion


        #region Populate Functions

        public void SetDataForEdit(int warehouseId)
        {
            WarehouseModel warehouse = _inventoryService.GetWarehouse(warehouseId);
            if (warehouse != null)
            {
                this.Text = "Warehouse Edit (" + warehouse.Name + ")";
                _warehouseId = warehouseId;
                tbLocation.Text = warehouse.Name;
                chkHold.Checked = warehouse.Hold;
                chkMixedProduct.Checked = warehouse.MixedProduct;
                chkStaging.Checked = warehouse.Staging;
                chkUse.Checked = warehouse.Use;
            }
        }


        #endregion


        #region Save Functions

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsModelValid())
            {
                var warehouseModel = new WarehouseModel
                {
                    Id = _warehouseId,
                    Name = tbLocation.Text,
                    Hold = chkHold.Checked,
                    MixedProduct = chkMixedProduct.Checked,
                    Staging = chkStaging.Checked,
                    Use = chkUse.Checked,
                };
                _inventoryService.AddOrUpdateWarehouse(warehouseModel);
                this.Close();
            }
        }

        private bool IsModelValid()
        {
            return ValidateLocation();
        }

        #endregion


    }
}
