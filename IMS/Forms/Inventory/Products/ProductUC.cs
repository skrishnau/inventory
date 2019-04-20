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
using IMS.Forms.Common.Links;

namespace IMS.Forms.Inventory.Products
{
    public partial class ProductUC : UserControl
    {
        private readonly ProductListUC _productListUC;
        private readonly ProductDetailUC _productDetailUC;
        

        private LinkManager _linkManager;

        public ProductUC(ProductListUC productListUC, ProductDetailUC productDetailUC)
        {
            _productListUC = productListUC;
            _productDetailUC = productDetailUC;

            InitializeComponent();

            this.Load += ProductUC_Load;
        }

        private void ProductUC_Load(object sender, EventArgs e)
        {
            headerTemplate1.Text = "Products";
            _linkManager = new LinkManager(pnlLinkList, toolTip1);
            subHeading.Text = "";
            this.Dock = DockStyle.Fill;
            ShowUI();
            _productListUC.RowSelected += _productListUC_RowSelected;
            lnkList.LinkClicked += _linkManager.Link_Click;
            _linkManager.LinkClicked += _linkManager_LinkClicked;
        }

        private void _linkManager_LinkClicked(object sender, Service.DbEventArgs.IdEventArgs e)
        {
            ShowUI(e.Id);
        }

        private void _productListUC_RowSelected(object sender, Service.DbEventArgs.BaseEventArgs<ViewModel.Core.Inventory.ProductModel> e)
        {
            if (e.Model != null)
            {
                _linkManager.AddLink(e.Model.Id, e.Model.SKU, e.Model.Name);
                ShowUI(e.Model.Id);
            }
        }

       

        private void ShowUI(int productId = 0)
        {
            pnlBody.Controls.Clear();
            if (productId == 0)
            {
                subHeading.Text = "Product List";
                // show the list
                pnlBody.Controls.Add(_productListUC);
            }
            else
            {
                subHeading.Text = "Product Detail";
                // show the product detail
                _productDetailUC.SetData(productId);
                pnlBody.Controls.Add(_productDetailUC);
            }
        }
    }
}
