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

namespace IMS.Forms.Inventory.Variants
{
    public partial class VariantEditForm : Form
    {
        private IInventoryService _inventoryService;
        private int _id; // edit mode
        private int _productId;

        public VariantEditForm(IInventoryService inventoryService, int productId)
        {
            this._inventoryService = inventoryService;
            this._productId = productId;

            InitializeComponent();

            PopulateData();
        }


        private void PopulateData()
        {
            var product = this._inventoryService.GetProduct(_productId);

            this.Text = (_id > 0 ? "Edit" : "Add") + " Variant (" + product.Name + ")";


           // lblProductName.Text = product.Name;

            // get Product Attributes
            //var options = _inventoryService.GetOptionList(product.Id);
            //foreach (var optionGroup in options.GroupBy(x => x.Name))
            //{
            //    var comboWithLabel = new ComboWithLabelUC();
            //    comboWithLabel.lblLabel.Text = optionGroup.Key;
            //    var groupedOptions = optionGroup.ToList();

            //    // insert empty to allow users not to select some attributes
            //    groupedOptions.Insert(0, new ViewModel.Core.Inventory.AttributeModel
            //    {
            //        Id = 0,
            //        Value = "",
            //        Name = ""
            //    });
            //    comboWithLabel.cbCombo.DataSource = groupedOptions; // optionGroup.ToList();
            //    comboWithLabel.cbCombo.ValueMember = "Id";
            //    comboWithLabel.cbCombo.DisplayMember = "Value";
            //    comboWithLabel.cbCombo.DropDownStyle = ComboBoxStyle.DropDownList;

            //    pnlOptions.Controls.Add(comboWithLabel);

            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // save
            Save();
        }

        private void Save()
        {
            var optionList = new List<OptionModel>();
            if (!ValidateData())
            {
                // show message
                PopupMessage.ShowPopupMessage("Invalid Inputs", "Please fill out required fields", PopupMessageType.INFO);
                return;
            }
            //var variantModel = new VariantModel()
            //{
            //    Id = _id, // currently _id is zero since not assigned anywhere
            //    SKU = tbSKU.Text,
            //    ProductId = _productId,
            //    //MinStockCountForAlert = tbStockThreshold.Value,
            //    ShowStockAlerts = cbShowStockAlert.Checked,

            //};
            //foreach (ComboWithLabelUC control in pnlOptions.Controls)
            //{
            //    var value = control.cbCombo.SelectedValue;
            //    if (value != null)
            //    {
            //        variantModel.OptionIds.Add((int)value);
            //    }
            //}
            //_inventoryService.SaveVariant(variantModel);
            //this.Close();
        }

        private bool ValidateData()
        {
            var valid = true;
            if (string.IsNullOrEmpty(tbSKU.Text))
            {
                valid = false;
                PopupMessage.ShowPopupMessage("Empty SKU", "Stock Keeping Unit is empty. Please fill out.", PopupMessageType.INFO);
                this.Focus();
            }


            return valid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
