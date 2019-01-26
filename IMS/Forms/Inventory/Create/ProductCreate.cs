using Service.Core.Inventory;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Inventory.Create
{
    public partial class ProductCreate : Form
    {
        private readonly IInventoryService productService;

        public ProductCreate(IInventoryService productService)
        {
            this.productService = productService;

            InitializeComponent();

            InitializeListeners();
        }

        private void InitializeListeners()
        {
            btnSave.Click += btnSave_Click;
            btnAddBrand.Click += btnAddBrand_Click;
            btnAddCategory.Click += BtnAddCategory_Click;
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {

            var categoryCreate = Program.container.GetInstance<CategoryCreate>();
            categoryCreate.StartPosition = FormStartPosition.CenterParent;
            categoryCreate.ShowDialog();
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            var brandCreate = Program.container.GetInstance<BrandCreate>();
            brandCreate.StartPosition = FormStartPosition.CenterParent;
            brandCreate.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
