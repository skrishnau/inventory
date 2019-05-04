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
using SimpleInjector.Lifestyles;
using IMS.Forms.Sales;
using Service.DbEventArgs;
using ViewModel.Core.Orders;

namespace IMS.Forms.Inventory.Sales
{
    public partial class SaleOrderListUC : UserControl
    {
        public event EventHandler<BaseEventArgs<OrderModel>> RowSelected;

        //private readonly ISaleService saleService;
        public SaleOrderListUC()//ISaleService saleService
        {
            //this.saleService = saleService;
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.Load += SaleUC_Load;

           
        }

        private void SaleUC_Load(object sender, EventArgs e)
        {
            InitializeHeader();

            InitializeEvents();
            PopulateSaleList();
        }

        private void InitializeHeader()
        {
            var _header = HeaderTemplate.Instance;
            _header.lblHeading.Text = "Sales";
            _header.btnNew.Visible = true;
            _header.btnNew.Click += BtnNew_Click;
            // set icon
            //_header.btn
            this.Controls.Add(_header);
            _header.SendToBack();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var directSaleForm = Program.container.GetInstance<SaleOrderCreateForm>();//DirectSaleForm
                directSaleForm.ShowDialog();
            }
        }

        public void InitializeEvents()
        {
            dgvSalesList.SelectionChanged += DgvSalesList_SelectionChanged;
            dgvSalesList.CellMouseDoubleClick += DgvSales_CellMouseDoubleClick;
        }

        private void DgvSalesList_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgvSalesList.SelectedRows.Count > 0)
            //{
            //    var sale = (OrderModel)dgvSalesList.SelectedRows[0].DataBoundItem;
            //    lblDate.Text = sale.Date;
            //    lblInvoice.Text = sale.BillNo;
            //    lblCustomerName.Text = sale.CustomerName;
            //    lblTotal.Text = sale.TotalAmount.ToString();
            //    lblAddress.Text = sale.Address;
            //    lblTotal.Text = sale.TotalAmount.ToString();
            //    lblMobile.Text = sale.MobileNo;

            //    var saleItems = saleService.GetSaleItemList(sale.Id);
            //    //var saleItems = sale.SaleItem;
            //    dgvSaleItemsList.AutoGenerateColumns = false;
            //    dgvSaleItemsList.DataSource = saleItems;

            //}
        }

        public void PopulateSaleList()
        {
            dgvSalesList.AutoGenerateColumns = false;
            //var sales = saleService.GetSaleList();
            //dgvSalesList.DataSource = sales;
        }

        private void DgvSales_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var model = dgvSalesList.Rows[e.RowIndex].DataBoundItem as OrderModel;
            if (model != null)
            {
                var eventArgs = new BaseEventArgs<OrderModel>(model, Service.Utility.UpdateMode.NONE);
                RowSelected?.Invoke(sender, eventArgs);
            }
        }


    }
}
