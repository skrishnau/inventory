using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Inventory.Categories
{
    public partial class CategoryEditControlPanel : UserControl
    {
        public event EventHandler AddSubCategoryClick;
        public event EventHandler DeleteCategoryClick;
        public event EventHandler EditCategoryClick;

        public CategoryEditControlPanel()
        {
            InitializeComponent();

            InitializeEvents();
        }

        private void InitializeEvents()
        {
            btnCreateSubCategory.Click += BtnCreateSubCategory_Click;
            btnDelete.Click += BtnDelete_Click;
            btnEdit.Click += BtnEdit_Click;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditCategoryClick(sender, e);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteCategoryClick(sender, e);
        }

        private void BtnCreateSubCategory_Click(object sender, EventArgs e)
        {
            AddSubCategoryClick(sender, e);
        }
    }
}
