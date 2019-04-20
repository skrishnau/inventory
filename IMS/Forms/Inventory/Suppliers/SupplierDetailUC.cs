using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Inventory.Suppliers
{
    public partial class SupplierDetailUC : UserControl
    {
        public SupplierDetailUC()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
        }

        internal void SetData(int supplierId)
        {
            
        }
    }
}
