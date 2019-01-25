using IMS.Forms.Products.Listing;
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
            splitContainer.Panel2.Controls.Clear();
            splitContainer.Panel2.Controls.Add(new ProductListUC());
        }
    }
}
