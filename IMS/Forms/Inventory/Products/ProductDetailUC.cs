using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Inventory;
using Service.Core.Inventory;
using Service.Interfaces;

namespace IMS.Forms.Inventory.Products
{
    public partial class ProductDetailUC : UserControl
    {
        private readonly IProductService _inventoryService;

        public ProductDetailUC(IProductService inventoryService)
        {
            _inventoryService = inventoryService;

            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public void SetData(int id)
        {
              var model = _inventoryService.GetProductForEdit(id);
            SetData(model);
        }


        private void SetData(ProductModel model)
        {
            // show product detail view
            //if (dgvProductList.SelectedRows.Count > 0)
            //{
            //    // show edit and delete buttons
            //    btnEdit.Visible = true;
            //    btnDelete.Visible = true;

            //    var data = (ProductModel)dgvProductList.SelectedRows[0].DataBoundItem;

            //    var model = _inventoryService.GetProductForEdit(data.Id);
            if (model != null)
            {
                //pnlProductDetail.Visible = true;
               // _selectedProduct = data;
                lblName.Text = model.Name;
                lblCategory.Text = model.Category;
                // brand
                lblBrand.Text = "";
                //foreach (var brand in model.Brands)
                //{
                //    lblBrands.Text += brand.Name + ", ";
                //}
                // attributes
                //lblAttributes.Text = "";
                //foreach (var att in model.ProductAttributes)
                //{
                //    lblAttributes.Text += att.Attribute + ", ";
                //}
                //dgvSKUListing.AutoGenerateColumns = false;
                // dgvSKUListing.DataSource = model.Variants;
            }
            //else
            //{
            //    pnlProductDetail.Visible = false;
            //    // show edit and delete buttons
            //    //btnEdit.Visible = false;
            //    //btnDelete.Visible = false;
            //}
            //}
            //else
            //{
            //    pnlProductDetail.Visible = false;
            //    // show edit and delete buttons
            //    btnEdit.Visible = false;
            //    btnDelete.Visible = false;
            //}
        }
    }
}
