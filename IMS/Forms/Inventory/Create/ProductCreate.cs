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
using ViewModel.Core.Inventory;

namespace IMS.Forms.Inventory.Create
{
    public partial class ProductCreate : Form
    {
        private readonly IInventoryService _inventoryService;

        public ProductCreate(IInventoryService inventoryService)
        {
            this._inventoryService = inventoryService;

            InitializeComponent();

            PopulateCategoryCombo();

            PopulateBrandCombo();

            InitializeEvents();
        }

        private void PopulateCategoryCombo()
        {
            cbCategory.FlatStyle = FlatStyle.Popup;
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            var categories = _inventoryService.GetCategoryList(null);
            //cbCategory.ValueMember = "Id";
            //cbCategory.DisplayMember = "Name";
            AddCategoryToCombo(null, null, null);
            cbCategory.Text = "Select";
            //cbCategory.SelectedIndex = 0;
        }

        private void AddCategoryToCombo(int? categoryId, CategoryModel category, string spaces)
        {
            if (category != null)
                cbCategory.Items.Add(spaces + category.Name);
            var subCategories = _inventoryService.GetCategoryList(categoryId);
            foreach (var sub in subCategories)
            {
                AddCategoryToCombo(sub.Id, sub, spaces == null ? "" : spaces + "   ");
            }
        }

        private void PopulateBrandCombo()
        {
            cbBrand.FlatStyle = FlatStyle.Popup;
            cbBrand.DropDownStyle = ComboBoxStyle.DropDownList;
            var brands = _inventoryService.GetBrandList();
            cbBrand.ValueMember = "Id";
            cbBrand.DisplayMember = "Name";
            cbBrand.DataSource = brands;
        }

        private void InitializeEvents()
        {
            btnSave.Click += btnSave_Click;
            //btnAddBrand.Click += btnAddBrand_Click;
            //btnAddCategory.Click += BtnAddCategory_Click;

            tbProductName.Validating += TbProductName_Validating;
            cbCategory.Validating += CbCategory_Validating;

            //btnAddOption.Click += BtnAddOption_Click;
        }

        private void BtnAddOption_Click(object sender, EventArgs e)
        {
            
        }


        //private void BtnAddCategory_Click(object sender, EventArgs e)
        //{

        //    var categoryCreate = Program.container.GetInstance<CategoryCreate>();
        //    categoryCreate.StartPosition = FormStartPosition.CenterParent;
        //    categoryCreate.ShowDialog();
        //}

        //private void btnAddBrand_Click(object sender, EventArgs e)
        //{
        //    var brandCreate = Program.container.GetInstance<BrandCreate>();
        //    brandCreate.StartPosition = FormStartPosition.CenterParent;
        //    brandCreate.ShowDialog();
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProductModel product = null;
            try
            {
                var valName = ValidateProductName();
                var valCategory = ValidateCategory();
                var valBrand = ValidateBrand();
                if (!(valName && valCategory && valBrand))
                {
                    return;
                }

                var category = _inventoryService.GetCategory(cbCategory.SelectedItem.ToString());
                product = new ProductModel()
                {
                    BrandId = ((BrandModel)cbBrand.SelectedItem).Id,
                    CategoryId = category.Id,
                    CreatedAt = DateTime.Now,
                    MinStockCountForAlert = int.Parse(tbStockThreshold.Text),
                    ShowStockAlerts = checkboxShowStockAlert.Checked,
                    Name = tbProductName.Text,
                    UpdatedAt = DateTime.Now,
                };
            }
            catch (Exception ex) { throw; }
            if (product != null)
            {
                _inventoryService.AddProduct(product);
                this.Close();
            }
        }


        #region Validation

        private void CbCategory_Validating(object sender, CancelEventArgs e)
        {
            ValidateCategory();
        }

        private void TbProductName_Validating(object sender, CancelEventArgs e)
        {
            ValidateProductName();
        }

        private bool ValidateProductName()
        {
            if (tbProductName.Text.Trim() == "")
            {
                errorProvider1.SetError(tbProductName, "Required");
                return false;
            }
            errorProvider1.SetError(tbProductName, "");
            return true;
        }

        private bool ValidateCategory()
        {
            if (cbCategory.SelectedItem == null || (string)cbCategory.SelectedItem == "")
            {
                errorProvider1.SetError(cbCategory, "Required");
                return false;
            }
            errorProvider1.SetError(cbCategory, "");
            return true;
        }

        private bool ValidateBrand()
        {
            if (cbBrand.SelectedItem == null)
            {
                errorProvider1.SetError(cbBrand, "Required");
                return false;
            }
            errorProvider1.SetError(cbBrand, "");
            return true;
        }

        #endregion


    }
}
