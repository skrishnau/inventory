using Service.Core.Product.Details;
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
    public partial class CategoryCreate : Form
    {
        private readonly IProductService productService;

        public CategoryCreate()
        {
            productService = new ProductService(); // later inject this in constructor

            InitializeComponent();

            InitializeEvents();
        }

        private void InitializeEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            this.Load += CategoryCreate_Load;
        }

        private void CategoryCreate_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            var point = new Point(MousePosition.X + 15, MousePosition.Y);
            this.Location = point;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (tbCategory.Text == "")
            {
                tbCategory.BackColor = Color.LightPink;
                return;
            }
            var categoryModel = new CategoryModel
            {
                Name = tbCategory.Text,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                
            };
            productService.AddCategory(categoryModel);
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
