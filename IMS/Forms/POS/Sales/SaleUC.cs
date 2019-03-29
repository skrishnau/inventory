using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Sales;
using ViewModel.Core.Sales;
using IMS.Forms.Common.Display;
using SimpleInjector.Lifestyles;

namespace IMS.Forms.Sales
{
    public partial class SaleUC : UserControl
    {
        private readonly ISaleService saleService;
        public SaleUC(ISaleService saleService)
        {
            this.saleService = saleService;
            InitializeComponent();

            InitializeHeader();

            InitializeEvents();
            PopulateSaleListDGV();
        }

        private void InitializeHeader()
        {
            var _header = SubHeadingTemplate.Instance;
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
                var directSaleForm = Program.container.GetInstance<DirectSaleForm>();
                directSaleForm.ShowDialog();
            }
        }

        public void InitializeEvents()
        {
            dgvSalesList.SelectionChanged += DgvSalesList_SelectionChanged;
        }

        private void DgvSalesList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSalesList.SelectedRows.Count > 0)
            {
                var sale = (SaleModel)dgvSalesList.SelectedRows[0].DataBoundItem;
                lblDate.Text = sale.Date;
                lblInvoice.Text = sale.BillNo;
                lblCustomerName.Text = sale.CustomerName;
                lblTotal.Text = sale.TotalAmount.ToString();
                lblAddress.Text = sale.Address;
                lblTotal.Text = sale.TotalAmount.ToString();
                lblMobile.Text = sale.MobileNo;

                var saleItems = saleService.GetSaleItemList(sale.Id);
                //var saleItems = sale.SaleItem;
                dgvSaleItemsList.AutoGenerateColumns = false;
                dgvSaleItemsList.DataSource = saleItems;

            }
        }

        public void PopulateSaleListDGV()
        {
            dgvSalesList.AutoGenerateColumns = false;
            var sales = saleService.GetSaleList();
            dgvSalesList.DataSource = sales;
        }

        
    }
}
