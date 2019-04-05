using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Inventory
{
    public partial class InventoryMenuBar : UserControl
    {
        public InventoryMenuBar()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public void ClearSelection()
        {
            btnProductList.FlatStyle = FlatStyle.Standard;
            btnCategoryList.FlatStyle = FlatStyle.Standard;
            btnSupplierList.FlatStyle = FlatStyle.Standard;
            btnWarehouseList.FlatStyle = FlatStyle.Standard;
        }


    }

}
