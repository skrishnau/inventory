using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Inventory;
using Service.Listeners;
using ViewModel.Enums;
using ViewModel.Core.Orders;
using Service.Core.Orders;
using SimpleInjector.Lifestyles;
using Service.Core.Settings;
using Service.Interfaces;
using Microsoft.Reporting.WinForms;

namespace IMS.Forms.Inventory.Dashboard
{
    public partial class DashboardUC : UserControl
    {
        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IDatabaseChangeListener _listener;
        private readonly IAppSettingService _appSettingService;

        public DashboardUC(IInventoryService inventoryService, IProductService productService, IOrderService orderService, IAppSettingService appSettingService, IDatabaseChangeListener listener)
        {
            _inventoryService = inventoryService;
            _productService = productService;
            _orderService = orderService;
            _appSettingService = appSettingService;

            _listener = listener;

            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.Load += DashboardUC_Load;
        }

        private void DashboardUC_Load(object sender, EventArgs e)
        {
            _listener.ProductUpdated += _listener_ProductUpdated;
            _listener.InventoryUnitUpdated += _listener_InventoryUnitUpdated;
            _listener.UserUpdated += _listener_UserUpdated;
            _listener.OrderUpdated += _listener_OrderUpdated;
            _listener.CompanyUpdated += _listener_CompanyUpdated; ;

            PopulateUnderstockProducts();
            PopulateDueReceivables();
            PopulateTransactionSummary();
            PopulateInventorySummary();
            InitializeEvents();
            PopulateCompany();

            PopulateBarDiagram();
            
        }

        private void PopulateBarDiagram()
        {
            List<SalePurchaseAmountModel> amountSummary = _orderService.GetSalePurchaseAmountForBarDiagram();
            ReportDataSource reportDataSource = new ReportDataSource("SalePurchaseAmountDataset", amountSummary);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            this.reportViewer1.RefreshReport();
        }

        private void _listener_CompanyUpdated(object sender, Service.DbEventArgs.BaseEventArgs<ViewModel.Core.Settings.CompanyInfoSettingModel> e)
        {
            PopulateCompany();
        }

        private void PopulateCompany()
        {
            var company = _appSettingService.GetCompanyInfoSetting();
            lblAddress.Text = string.IsNullOrEmpty(company.Address) ? "Address" : company.Address;
            lblCompanyName.Text = string.IsNullOrEmpty(company.CompanyName) ? "My Company" :  company.CompanyName;
            lblPhone.Text = string.IsNullOrEmpty(company.Phone) ? "Phone" : company.Phone;
        }

        private void _listener_OrderUpdated(object sender, Service.DbEventArgs.BaseEventArgs<OrderModel> e)
        {
            PopulateDueReceivables();
            PopulateBarDiagram();
            PopulateTransactionSummary();
        }

        // uncomment to give colors to cells 
        //private void DgvDueReceivables_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    //try
        //    //{
        //    //    var order = dgvDueReceivables.Rows[e.RowIndex].DataBoundItem as OrderModel;
        //    //    if(order != null)
        //    //    {
        //    //        if(order.Pay)
        //    //    }
        //    //    if (_productList[e.RowIndex].IsLessThanMinimumStock)
        //    //    {
        //    //        e.CellStyle.ForeColor = Color.Red;
        //    //        e.CellStyle.SelectionForeColor = Color.Red;
        //    //        // e.CellStyle.BackColor = Color.LightBlue;
        //    //        e.CellStyle.SelectionBackColor = SystemColors.GradientInactiveCaption; //Color.LightBlue;
        //    //    }
        //    //}
        //    //catch (Exception ex) { }
        //}

        private void _listener_UserUpdated(object sender, Service.DbEventArgs.BaseEventArgs<ViewModel.Core.Users.UserModel> e)
        {
            PopulateInventorySummary();
        }

        private void InitializeEvents()
        {
            dtEnd.ValueChanged += Date_ValueChanged;
            dtStart.ValueChanged += Date_ValueChanged;
          //  dgvDueReceivables.CellDoubleClick += DgvDueReceivables_CellDoubleClick;
        }

        private void DgvDueReceivables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                if (e.RowIndex >= 0) {
                    var orderModel = dgvDueReceivables.Rows[e.RowIndex].DataBoundItem as OrderModel;
                    if (orderModel != null)
                    {
                        var form = Program.container.GetInstance<Transaction.TransactionCreateForm>();
                        form.SetDataForEdit(OrderTypeEnum.Sale, orderModel.Id);
                        form.ShowDialog();
                    }
                }
            }
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {
            PopulateTransactionSummary();
        }

        #region Listeners

        private void _listener_ProductUpdated(object sender, Service.Listeners.Inventory.ProductEventArgs e)
        {
            PopulateUnderstockProducts();
            PopulateInventorySummary();

        }

        private void _listener_InventoryUnitUpdated(object sender, Service.DbEventArgs.BaseEventArgs<List<ViewModel.Core.Inventory.InventoryUnitModel>> e)
        {
            PopulateUnderstockProducts();
            PopulateInventorySummary();
        }

        #endregion

        private void PopulateTransactionSummary()
        {
            var start = dtStart.Value.Date;
            var end = dtEnd.Value.Date;
            end = end.AddDays(1);
            var summary = _inventoryService.GetTransactionSummary(start, end);
            foreach (var sum in summary)
            {
                if (sum.Key == TransactionSummaryKeys.Purchase.ToString())
                {
                    lblPurchase.Text = sum.Value.ToString("0");
                }
                else if (sum.Key == TransactionSummaryKeys.Sale.ToString())
                {
                    lblSale.Text = sum.Value.ToString("0");
                }
            }
        }

        void PopulateInventorySummary()
        {
            var summary = _inventoryService.GetInventorySummary();
            foreach (var sum in summary)
            {
                if (sum.Key == TransactionSummaryKeys.Product.ToString())
                {
                    lblProducts.Text = sum.Value.ToString("0");
                }
                else if (sum.Key == TransactionSummaryKeys.Customer.ToString())
                {
                    lblCustomers.Text = sum.Value.ToString("0");
                }
                else if (sum.Key == TransactionSummaryKeys.InventoryQuantity.ToString())
                {
                    lblInventoryQuantity.Text = sum.Value.ToString("0");
                }
            }
        }

        private void PopulateUnderstockProducts()
        {
            var products = _productService.GetUnderStockProducts();
            lbUnderStockProducts.DataSource = products;
            lblTopUnderstockProducts.Text = "Understock Products - " + products.Count;
            lbUnderStockProducts.DisplayMember = "Name";
            lbUnderStockProducts.ValueMember = "Id";
            lbUnderStockProducts.ClearSelected();
            lbUnderStockProducts.SelectionMode = SelectionMode.None;
        }

        private void PopulateDueReceivables()
        {
            var sale = OrderTypeEnum.Sale.ToString();
            var orders = _orderService.GetDuePayments();
            orders = orders.Where(x => x.OrderType == sale).OrderBy(x=>x.PaymentDueDays).ToList();
            dgvDueReceivables.AutoGenerateColumns = false;
            dgvDueReceivables.DataSource = orders;
            dgvDueReceivables.AllowUserToAddRows = false;
            dgvDueReceivables.AllowUserToDeleteRows = false;
            dgvDueReceivables.RowHeadersVisible = false;

        }
    }
}
