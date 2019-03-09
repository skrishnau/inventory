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

namespace IMS.Forms.Inventory.SKU
{
    public partial class SkuEditForm : Form
    {
        private IInventoryService _inventoryService;
        private int _productId;

        public SkuEditForm(IInventoryService inventoryService, int productId)
        {
            this._inventoryService = inventoryService;
            this._productId = productId;

            InitializeComponent();

            PopulateData();
        }


        private void PopulateData()
        {
            var product = this._inventoryService.GetProduct(_productId);
            lblProductName.Text = product.Name;

            // get Attributes
            
        }
    }
}
