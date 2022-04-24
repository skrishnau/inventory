using IMS.Forms.Common;
using Service.Core.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Inventory;

namespace IMS.Forms.Inventory.UOM
{
    public partial class UomCreateForm : Form
    {
        private readonly IInventoryService _inventoryService;

        private int _uomId;
        private ViewModel.Core.Inventory.UomModel _uomModel;

        public UomCreateForm(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;

            InitializeComponent();

            this.Load += UomCreateForm_Load;
        }
        private void UomCreateForm_Load(object sender, EventArgs e)
        {
            txtQuantity.Maximum = Int32.MaxValue;
            txtQuantity.Minimum = 0;
            PopulateUomData();
            PopulateBaseUomCombo();

            InitializeEvents();
            
        }

        private void PopulateBaseUomCombo()
        {
            txtBaseUnit.AutoCompleteCustomSource.Clear();
            var uoms = _inventoryService.GetUomListForCombo();
            txtBaseUnit.AutoCompleteCustomSource.AddRange(uoms.Select(x => x.Name).ToArray());
            txtBaseUnit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBaseUnit.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void InitializeEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void PopulateUomData()
        {
            _uomModel = _inventoryService.GetUom(_uomId);
            if (_uomModel != null)
            {
                this.Text = "Edit Package";
                txtName.Text = _uomModel.Package;
                chkUse.Checked = _uomModel.Use;
                txtQuantity.Value = _uomModel.Quantity;
                txtBaseUnit.Text = _uomModel.RelatedPackage;
            }
        }

        public void SetDataForEdit(int uomId)
        {
            this._uomId = uomId;
        }

        private void Save()
        {
            var isValid = ValidateInputs();
            if (!isValid)
            {
                PopupMessage.ShowInfoMessage("Some fields are missing");
                return;
            }
            var model = new UomModel
            {
                Use = chkUse.Checked,
                Package = txtName.Text,
                RelatedPackage = txtBaseUnit.Text,
                Quantity = txtQuantity.Value,
                Id = _uomId
            };
            var msg = _inventoryService.SaveUom(model);
            if (msg.Success)
            {
                PopupMessage.ShowSuccessMessage(msg.Message);
                this.Close();
                return;
            }
            PopupMessage.ShowInfoMessage(msg.Message);
            this.Focus();
        }

        private bool ValidateInputs()
        {
            var isValid = true;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                isValid = false;
                errorProvider1.SetError(txtName, "Required");
            }
            else
            {
                errorProvider1.SetError(txtName, string.Empty);
            }
            if (string.IsNullOrEmpty(txtBaseUnit.Text))
            {
                isValid = false;
                errorProvider1.SetError(txtBaseUnit, "Required");
            }
            else
            {
                errorProvider1.SetError(txtBaseUnit, string.Empty);
            }
            if (txtQuantity.Value <= 0)
            {
                isValid = false;
                errorProvider1.SetError(txtQuantity, "Should be greater than zero");
            }
            else
            {
                errorProvider1.SetError(txtQuantity, string.Empty);
            }
            return isValid;
        }
    }
}
