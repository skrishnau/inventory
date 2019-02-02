using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Inventory.Products
{
    public partial class ProductOptionUC : Form
    {
        public ProductOptionUC()
        {
            InitializeComponent();

            PopulateTypeCombo();

            InitializeEvents();
        }

        private void InitializeEvents()
        {
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void PopulateTypeCombo()
        {
            
        }
    }
}
