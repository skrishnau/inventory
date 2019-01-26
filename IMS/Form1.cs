using IMS.Forms.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitializeEvents();

        }

        private void InitializeEvents()
        {
            btnProducts.Click += BtnProducts_Click;
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            var productListUC = Program.container.GetInstance<InventoryUC>();//new InventoryUC();
            productListUC.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(productListUC);
        }
    }
}
