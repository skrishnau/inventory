using IMS.Forms.Common;
using Service.Core.Inventory;
using Service.Core.Inventory.Units;
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

namespace IMS.Forms.Inventory.Units.Actions
{
    public partial class InventorySplitForm : Form
    {

        private readonly IInventoryUnitService _inventoryUnitService;

        private InventoryUnitModel _data;

        // list to hold the parsed quantities
        List<decimal> _qtyList = new List<decimal>();

        public InventorySplitForm(IInventoryUnitService inventoryUnitService)
        {
            _inventoryUnitService = inventoryUnitService;

            InitializeComponent();
        }

        public void SetData(InventoryUnitModel model)
        {
            _data = model;
            tbTotalQuantity.Text = model.UnitQuantity.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            var errorMsg = errorProvider1.GetError(tbSplits);
            if (!string.IsNullOrEmpty(errorMsg))
            {
                PopupMessage.ShowInfoMessage(errorMsg);
                this.Focus();
                return;
            }

            _inventoryUnitService.SplitInventoryUnit(_qtyList, _data);
            PopupMessage.ShowSuccessMessage("Split Success");
            this.Focus();
            this.Close();
        }

        private void tbSplits_TextChanged(object sender, EventArgs e)
        {
            var msg = ValidateInput();
            errorProvider1.SetError(tbSplits, msg);
        }

        private string ValidateInput()
        {
            var splits = tbSplits.Text.Split(new char[] { '+' });//e.Input.Split(new char[] { '+' });
            if (splits.Length <= 1)
            {
                return "At least 2 splits expected";
            }
            // clear the earlier calculated quantity
            _qtyList.Clear();
            lblSum.Text = "Sum: ";
            var sum = 0M;
            foreach (var sp in splits)
            {
                var qty = 0M;
                if (!decimal.TryParse(sp.Trim(), out qty))
                {
                    return "Only numbers allowed";
                }
                else if (qty == 0)
                {
                    return "Can't input zero in quantity splits";
                }
                _qtyList.Add(qty);
                sum += qty;
            }
            lblSum.Text += _qtyList.Sum().ToString();
            if (sum > _data.UnitQuantity)
                return "Sum can't be greater than the inventory unit quantity";
            else if (sum < _data.UnitQuantity)
                return "Sum can't be less than the inventory unit quantity";

            return string.Empty;
        }
    }
}
