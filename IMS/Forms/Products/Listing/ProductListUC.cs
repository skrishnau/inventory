using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Create;

namespace IMS.Forms.Products.Listing
{
    public partial class ProductListUC : UserControl
    {
        public ProductListUC()
        {
            InitializeComponent();


            InitializeListeners();
        }

        private void InitializeListeners()
        {
            btnAdd.Click += BtnAdd_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var productCreate = new ProductCreate();
            productCreate.ShowInTaskbar = false;
            productCreate.ShowDialog();
        }
    }
}
