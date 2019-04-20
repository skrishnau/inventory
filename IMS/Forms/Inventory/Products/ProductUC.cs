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

namespace IMS.Forms.Inventory.Products
{
    public partial class ProductUC : UserControl
    {
        private readonly ProductListUC _productListUC;
        private readonly ProductDetailUC _productDetailUC;

        private List<int> _visitedProductIds = new List<int>();

        public ProductUC(ProductListUC productListUC, ProductDetailUC productDetailUC)
        {
            _productListUC = productListUC;
            _productDetailUC = productDetailUC;

            InitializeComponent();

            this.Load += ProductUC_Load;
            subHeading.Text = "";
        }

        private void ProductUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            ShowUI();
            _productListUC.RowSelected += _productListUC_RowSelected;
        }

        private void _productListUC_RowSelected(object sender, Service.DbEventArgs.BaseEventArgs<ViewModel.Core.Inventory.ProductModel> e)
        {
            if (e.Model != null)
            {
                AddLink(e.Model);
                ShowUI(e.Model.Id);
            }
        }

        private void AddLink(ProductModel model)
        {
            //LinkLabel link = null;
            //var index = _visitedProductIds.IndexOf(model.Id);
            //if (index >= 0)
            //{
            //    // exists
            //    link = pnlLinkList.Controls[index] as LinkLabel;
            //}
            //else
            //{
            //    // doesn't exist
            //    link = new LinkLabel();
            //    link.AutoEllipsis = true;
            //    link.Text = "● " + model.SKU;
            //    pnlLinkList.Controls.Add(link);
            //    link.Tag = model.Id;
            //    _visitedProductIds.Add(model.Id);
            //    link.Click += Link_Click;
            //    link.LinkBehavior = LinkBehavior.HoverUnderline;
            //    link.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            //    link.VisitedLinkColor = Color.Black;// System.Drawing.SystemColors.ControlText;
            //    toolTip1.SetToolTip(link, model.Name);
            //}
           
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
            }
        }
    }
}
