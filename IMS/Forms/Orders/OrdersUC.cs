using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Common.Display;
using IMS.Forms.Purchases;
using SimpleInjector.Lifestyles;
using IMS.Forms.Sales;

namespace IMS.Forms.Orders
{
    public partial class OrdersUC : UserControl
    {
        private static readonly string MODULE_NAME = "Orders";
        private BodyTemplate _bodyTemplate;
        private OrdersMenuBar _menubar;

        public OrdersUC(OrdersMenuBar menubar)
        {
            _menubar = menubar;

            InitializeComponent();

            InitializeRootTemplate();

            InitializeMenubarButtonEvents();
        }

        private void InitializeRootTemplate()
        {
            // body
            _bodyTemplate = new BodyTemplate();
            _bodyTemplate.Dock = DockStyle.Fill;
            this.Controls.Add(_bodyTemplate);
            // heading
            _bodyTemplate.lblHeading.Text = MODULE_NAME;
            // menubar template
            _bodyTemplate.pnlMenuBar.Controls.Add(_menubar);
        }

        private void InitializeMenubarButtonEvents()
        {
            // Purchase order
            _menubar.btnPurchaseOrderList.Click += BtnPurchaseOrderList_Click;
            _menubar.btnNewPurchaseOrder.Click += BtnNewPurchaseOrder_Click;

            // Sales order
            _menubar.btnSalesOrderList.Click += BtnSalesOrderList_Click;
            _menubar.btnNewSalesOrder.Click += BtnNewSalesOrder_Click;

        }

        private void BtnPurchaseOrderList_Click(object sender, EventArgs e)
        {
            var purchaseListUC = Program.container.GetInstance<PurchaseListUC>();
            _bodyTemplate.pnlBody.Controls.Clear();
            purchaseListUC.Dock = DockStyle.Fill;
            _bodyTemplate.pnlBody.Controls.Add(purchaseListUC);
            // set selection
            _menubar.ClearSelection();
            _menubar.btnPurchaseOrderList.FlatStyle = FlatStyle.Flat;
        }

        private void BtnNewPurchaseOrder_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var orderCreate = Program.container.GetInstance<PurchaseOrderCreateForm>();
                orderCreate.ShowInTaskbar = false;
                orderCreate.ShowDialog();
            }
        }


        #region Sales Orders


        private void BtnSalesOrderList_Click(object sender, EventArgs e)
        {
            _bodyTemplate.pnlBody.Controls.Clear();
            var saleUc = Program.container.GetInstance<SaleUC>();
            saleUc.Dock = DockStyle.Fill;
            _bodyTemplate.pnlBody.Controls.Add(saleUc);
            // set selection
            _menubar.ClearSelection();
            _menubar.btnSalesOrderList.FlatStyle = FlatStyle.Flat;

        }

        private void BtnNewSalesOrder_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
