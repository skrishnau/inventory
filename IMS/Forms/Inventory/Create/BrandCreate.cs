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
using ViewModel.Core.Products;

namespace IMS.Forms.Inventory.Create
{
    public partial class BrandCreate : Form
    {
        private readonly IInventoryService productService;

        public BrandCreate(IInventoryService productService)
        {
            this.productService = productService;

            InitializeComponent();

            InitializeEvents();
        }



        private void InitializeEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            this.Load += BrandCreate_Load;
        }

        private void BrandCreate_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            var point = new Point(MousePosition.X + 15, MousePosition.Y);
            this.Location = point;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (tbBrandName.Text == "")
            {
                tbBrandName.BackColor = Color.LightPink;
                return;
            }
            var brandModel = new BrandModel
            {
                Name = tbBrandName.Text
            };
            productService.AddBrand(brandModel);
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
