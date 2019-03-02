using IMS.Forms.Common;
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
using Tulpep.NotificationWindow;
using ViewModel.Core.Inventory;

namespace IMS.Forms.Inventory.Create
{
    public partial class ProductCreate : Form
    {
        private readonly IInventoryService _inventoryService;

        private int Id;
        private List<BrandModel> _brands;

        public ProductCreate(IInventoryService inventoryService)
        {
            this._inventoryService = inventoryService;

            _brands = _inventoryService.GetBrandList();

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
            
            cbBrand.ValueMember = "Id";
            cbBrand.DisplayMember = "Name";
            cbBrand.DataSource = _brands;
        }

        private void InitializeEvents()
        {
            //btnSave.Click += btnSave_Click;
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
            SaveProduct();
        }

        private string errorMessage = "Please Fill all required Fields";

        private void SaveProduct()
        {
            ProductModel product = null;
            try
            {
                var valName = ValidateProductName();
                var valCategory = ValidateCategory();
                if (!(valName && valCategory))
                {
                    ShowPopupMessage("Unfilled Inputs", "Please fill all the required fields");
                    return;
                }
                var brands = GetBrands();
                if(brands == null)
                {
                    ShowPopupMessage("Missing Brand Names", "Some of the brands are without name!");
                    return;
                } else if (!IsBrandNamesUnique(brands))
                {
                    ShowPopupMessage("Duplicate Brands", "There are duplicate Brand names in the list");
                    return;
                }

                var category = _inventoryService.GetCategory(cbCategory.SelectedItem.ToString());
                product = new ProductModel()
                {
                    Brands = brands, // GetBrands(), //((BrandModel)cbBrand.SelectedItem).Id,
                    CategoryId = category.Id,
                    CreatedAt = DateTime.Now,
                    MinStockCountForAlert = int.Parse(tbStockThreshold.Text),
                    ShowStockAlerts = cbShowStockAlert.Checked,
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

        private bool IsBrandNamesUnique(List<BrandModel> brands)
        {
            
            for(int i=0; i<brands.Count; i++)
            {
                var otherBrands = new List<BrandModel>();
                if (i > 0)
                {
                    // get lower limits
                    otherBrands.AddRange(brands.GetRange(0, i));
                }
                if (i < brands.Count - 1)
                {
                    // get upper limits
                    otherBrands.AddRange(brands.GetRange(i + 1, brands.Count - 1 - i));
                }
                if (otherBrands.Any(x => x.Name.Equals(brands[i].Name)))
                    return false;
            }
            return true;
        }

        private void ShowPopupMessage(string title, string message)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.icons8_Lipstick_48px_3;
            popup.TitleColor = Color.Coral;
            popup.ContentColor = Color.Red;
            popup.Size = new Size(300, 50);
            popup.ShowGrip = false;
            popup.TitleText = title;
            popup.ContentText = message;
            popup.Popup();// show 
            this.Focus(); // return the focus to the current form

        }
        private List<BrandModel> GetBrands()
        {
            var list = new List<BrandModel>();
            foreach (var brandControl in pnlBrandsBody.Controls)
            {
                var inputUc = (TextBoxWithDeleteUC)brandControl;
                if (inputUc != null)
                {
                    if (string.IsNullOrEmpty(inputUc.InputText))
                    {
                        return null;
                    }
                    var brandModel = new BrandModel()
                    {
                        Id = inputUc.Id,
                        CreatedAt = inputUc.Id == 0 ? DateTime.Now : inputUc.CreatedAt,
                        UpdatedAt = DateTime.Now,
                        Name = inputUc.InputText,
                        ProductId = Id,
                    };
                    list.Add(brandModel);
                }
            }
            return list;
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

        //private bool ValidateBrand()
        //{
        //    if (cbBrand.SelectedItem == null)
        //    {
        //        errorProvider1.SetError(cbBrand, "Required");
        //        return false;
        //    }
        //    errorProvider1.SetError(cbBrand, "");
        //    return true;
        //}


        #endregion

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            var brandEachItem = new TextBoxWithDeleteUC();
            brandEachItem.DataSource = _brands.Select(x => x.Name).Distinct().ToList();
            brandEachItem.OnRemoveClicked += BrandEachItem_OnRemoveClicked;
            //brandEachItem.Dock = DockStyle.Top;
            pnlBrandsBody.Controls.Add(brandEachItem);
        }

        private void BrandEachItem_OnRemoveClicked(object sender, EventArgs e)
        {
            pnlBrandsBody.Controls.Remove((TextBoxWithDeleteUC)sender);
        }

        private void btnAttributeAdd_Click(object sender, EventArgs e)
        {
            var attributeEachItem = new TextBoxWithDeleteUC();
            attributeEachItem.OnRemoveClicked += AttributeEachItem_OnRemoveClicked;
            attributeEachItem.Dock = DockStyle.Top;
            pnlAttributesBody.Controls.Add(attributeEachItem);
        }

        private void AttributeEachItem_OnRemoveClicked(object sender, EventArgs e)
        {
            pnlAttributesBody.Controls.Remove((TextBoxWithDeleteUC)sender);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
