using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Purchases.Order
{
    public partial class PurchaseOrderAddItemForm : Form
    {
        public PurchaseOrderAddItemForm()
        {
            InitializeComponent();



        }

        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
