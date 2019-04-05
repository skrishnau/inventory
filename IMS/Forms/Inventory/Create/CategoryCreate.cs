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
using ViewModel.Core.Inventory;

namespace IMS.Forms.Inventory.Create
{
    public partial class CategoryCreate : Form
    {
        private readonly IInventoryService _productService;
        private CategoryModel _categoryModel;
        private int? _parentCategoryId;
        private CategoryUpdateType _categoryUpdateType;

        // inject in constructor
        public CategoryCreate(IInventoryService productService)
        {
            _categoryUpdateType = CategoryUpdateType.ADD_CATEGORY;
            this._productService = productService;

            InitializeComponent();

            InitializeEvents();

            this.ActiveControl = tbCategory;
        }

        private void InitializeEvents()
        {
            btnSave.Click += BtnSave_Click;

            this.Load += CategoryCreate_Load;
        }

        /// <summary>
        /// Called from another class to set data for edit 
        /// </summary>
        /// <param name="categoryModel"></param>
        /// <param name="parentCategoryId"></param>
        public void SetData(CategoryUpdateType updateType, CategoryModel categoryModel)
        {
            this._categoryUpdateType = updateType;
            this._categoryModel = categoryModel;

            switch (updateType)
            {
                case CategoryUpdateType.ADD_CATEGORY:
                    this._parentCategoryId = null;
                    tbCategory.Text = "";
                    this.Text = "Add Category";
                    tbParentCategory.Text = "None";
                    break;
                case CategoryUpdateType.ADD_SUBCATEGORY:
                    this._parentCategoryId = categoryModel.Id; // subcategory in the given category
                    tbCategory.Text = "";
                    this.Text = "Create Sub-Category";
                    tbParentCategory.Text = categoryModel.Name;
                    break;
                case CategoryUpdateType.EDIT_CATEGORY:
                    this._parentCategoryId = categoryModel.ParentCategoryId; // parent is the data given in it
                    tbCategory.Text = categoryModel.Name;
                    this.Text = "Edit Category";
                    tbParentCategory.Text = string.IsNullOrEmpty(categoryModel.ParentCategory) ? "None" : categoryModel.ParentCategory;
                    break;
            }
        }

        private void CategoryCreate_Load(object sender, EventArgs e)
        {
            //this.StartPosition = FormStartPosition.Manual;
            //var point = new Point(MousePosition.X + 15, MousePosition.Y);
            //this.Location = point;
            tbCategory.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (tbCategory.Text == "")
            {
                tbCategory.BackColor = Color.LightPink;
                return;
            }
            CategoryModel cat = null;
            switch (_categoryUpdateType)
            {
                case CategoryUpdateType.ADD_CATEGORY:
                   cat = new CategoryModel
                   {
                       Name = tbCategory.Text,
                       CreatedAt = DateTime.Now,
                       UpdatedAt = DateTime.Now,
                       ParentCategoryId = null, // null cause its root catgory
                   };
                    break;
                case CategoryUpdateType.ADD_SUBCATEGORY:
                    cat = new CategoryModel
                    {
                        Name = tbCategory.Text,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ParentCategoryId = _categoryModel.Id, // Id of the given catgory; cause the given catgory is parent
                    };
                    break;
                case CategoryUpdateType.EDIT_CATEGORY:
                    cat = _categoryModel;
                    cat.UpdatedAt = DateTime.Now;
                    cat.ParentCategoryId = _parentCategoryId; // don't care about the parent category cause we are editing what's given
                    cat.Name = tbCategory.Text;
                    break;
            }
            if (cat != null)
            {
                _productService.AddUpdateCategory(cat);
                this.Close();
            }
        }

        
    }

    public enum CategoryUpdateType
    {
        ADD_CATEGORY, // add category
        EDIT_CATEGORY, // edit category
        ADD_SUBCATEGORY // subcategory creaate
    }


}
