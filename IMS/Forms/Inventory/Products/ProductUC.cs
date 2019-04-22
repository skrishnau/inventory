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
using IMS.Forms.Common.Display;

namespace IMS.Forms.Inventory.Products
{
    public partial class ProductUC : UserControl
    {
        private readonly ProductListUC _productListUC;
        private readonly ProductDetailUC _productDetailUC;

        private SubBodyTemplate _body;
        private LinkManager _linkManager;
        private readonly ProductSidebarUC _sidebar;

        public ProductUC(ProductListUC productListUC, ProductDetailUC productDetailUC, ProductSidebarUC sidebar)
        {
            _productListUC = productListUC;
            _productDetailUC = productDetailUC;
            _sidebar = sidebar;

            InitializeComponent();

            this.Dock = DockStyle.Fill;

            this.Load += ProductUC_Load;
        }

        private void ProductUC_Load(object sender, EventArgs e)
        {
            InitializeBody();
            
        }

        private void InitializeBody()
        {
            _body = new SubBodyTemplate();
            _linkManager = new LinkManager(_sidebar.pnlLinkList, _body.toolTip1);
            _body.HeadingText = "Products";
            _body.SubHeadingText = "";
            _body.pnlSideBar.Controls.Add(_sidebar);
            // product detail links
            _linkManager.LinkClicked += _linkManager_LinkClicked;
            // show list button click
            _sidebar.lnkList.LinkClicked += _linkManager.Link_Click;
            this.Controls.Add(_body);
            // data row
           // _productListUC.RowSelected += _productListUC_RowSelected;
            // show first UI
            ShowProductAndDetailUI(_sidebar.lnkList, 0);
        }

        // show detail on clicking link
        private void _linkManager_LinkClicked(object sender, Service.DbEventArgs.IdEventArgs e)
        {
            ShowProductAndDetailUI(sender, e.Id);
        }
        /*
        // show detail on clicking link
        private void _productListUC_RowSelected(object sender, Service.DbEventArgs.BaseEventArgs<ViewModel.Core.Inventory.ProductModel> e)
        {
            if (e.Model != null)
            {
                var link = _linkManager.AddAndGetLink(e.Model.Id, e.Model.SKU, e.Model.Name);
                ShowProductAndDetailUI(link, e.Model.Id);
            }
        }*/

        private void ShowProductAndDetailUI(object sender, int productId)
        {

            _body.pnlBody.Controls.Clear();
            if (productId == 0)
            {
                _body.SubHeadingText = "Product List";
                // show the list
                _body.pnlBody.Controls.Add(_productListUC);
            }
            else
            {
                _body.SubHeadingText = "Product Detail";
                // show the product detail
                _productDetailUC.SetData(productId);
                _body.pnlBody.Controls.Add(_productDetailUC);
            }
            _sidebar.SetVisited(sender);

        }
    }
}
