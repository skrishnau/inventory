﻿using System;
using System.Collections.Generic;
using System.Linq;
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
using IMS.Forms.Common;
using ViewModel.Core;
using ViewModel.Core.Inventory;
using Service.DbEventArgs;
using Service;

namespace IMS.Forms.Inventory.Dashboard
{
    public partial class DashboardUC : BaseUserControl
    {
        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IDatabaseChangeListener _listener;
        private readonly IAppSettingService _appSettingService;
        //public TabPage TabPage { get; set; }
        //public TabControl TabControl { get; set; }
        // public string MyTabTitle { get; set; }
        //private bool _listenerFired = false;

        //List<Action> _listenerActions = new List<Action>();

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
            this.dtEnd.SetValue(DateTime.Now);
            this.dtStart.SetValue(DateTime.Now);
            _listener.ProductUpdated += _listener_ProductUpdated;
            _listener.InventoryUnitUpdated += _listener_InventoryUnitUpdated;
            _listener.UserUpdated += _listener_UserUpdated;
            _listener.OrderUpdated += _listener_OrderUpdated;
            _listener.CompanyUpdated += _listener_CompanyUpdated;
            _listener.PaymentUpdated += _listener_PaymentUpdated;

            PopulateUnderstockProducts();
            PopulateDueReceivables();
            PopulateTransactionSummary();
            PopulateInventorySummary();
            InitializeEvents();
            PopulateCompany();

            PopulateBarDiagram();

            PopulateUserName();
        }

        private void PopulateUserName()
        {
            lblUserName.Text = UserSession.User?.Username;
        }

        private void PopulateBarDiagram()
        {
            var start = dtStart.GetValue().Date;
            var end = dtEnd.GetValue().Date;
            end = end.AddDays(1);
            List<SalePurchaseAmountModel> amountSummary = _orderService.GetSalePurchaseAmountForBarDiagram(start, end);
            ReportDataSource reportDataSource = new ReportDataSource("SalePurchaseAmountDataset", amountSummary);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            this.reportViewer1.RefreshReport();
        }



        private void PopulateCompany()
        {
            var company = _appSettingService.GetCompanyInfoSetting();
            lblAddress.Text = string.IsNullOrEmpty(company.Address) ? "Address" : company.Address;
            lblCompanyName.Text = string.IsNullOrEmpty(company.CompanyName) ? "My Company" : company.CompanyName;
            lblPhone.Text = string.IsNullOrEmpty(company.Phone) ? "Phone" : company.Phone;
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

        private void InitializeEvents()
        {
            dtEnd.TextChanged += Date_ValueChanged;
            dtStart.TextChanged += Date_ValueChanged;
            //  dgvDueReceivables.CellDoubleClick += DgvDueReceivables_CellDoubleClick;
            //TabControl.TabIndexChanged += TabControl_TabIndexChanged;
        }

        //public void ExecuteActions()
        //{
        //    foreach (var action in _listenerActions)
        //    {
        //        action?.Invoke();
        //    }
        //    _listenerActions.Clear();

        //}
        //private void TabControl_TabIndexChanged(object sender, EventArgs e)
        //{
        //    if(TabControl.SelectedTab == TabPage)
        //    {
        //        foreach(var action in _listenerActions)
        //        {
        //            action?.Invoke();
        //        }
        //        _listenerActions.Clear();
        //    }
        //}

        private void DgvDueReceivables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                if (e.RowIndex >= 0)
                {
                    var orderModel = dgvDueReceivables.Rows[e.RowIndex].DataBoundItem as OrderModel;
                    if (orderModel != null)
                    {
                        var form = Program.container.GetInstance<Transaction.TransactionCreateForm>();
                        var orderEditModel = new OrderEditModel
                        {
                            OrderType = OrderTypeEnum.Sale,
                            OrderId = orderModel.Id
                        };
                        form.SetDataForEdit(orderEditModel);// (OrderTypeEnum.Sale, orderModel.Id);
                        form.ShowDialog();
                    }
                }
            }
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {
            PopulateTransactionSummary();
            PopulateBarDiagram();
        }

        #region Listeners

        //private void AddListenerAction(Action action)
        //{
        //    if (InventoryUC.CurrentTabTitle == MyTabTitle)//(TabControl.SelectedTab == TabPage)
        //    {
        //        action?.Invoke();
        //        return;
        //    }
        //    if (!_listenerActions.Contains(action))
        //        _listenerActions.Add(action);
        //}

        private void _listener_ProductUpdated(object sender, BaseEventArgs<ProductModel> e)
        {
            AddListenerAction(PopulateUnderstockProducts, e);
            AddListenerAction(PopulateInventorySummary, e);
        }

        private void _listener_InventoryUnitUpdated(object sender, Service.DbEventArgs.BaseEventArgs<List<ViewModel.Core.Inventory.InventoryUnitModel>> e)
        {
            AddListenerAction(PopulateUnderstockProducts, e);
            AddListenerAction(PopulateInventorySummary, e);
        }


        private void _listener_UserUpdated(object sender, Service.DbEventArgs.BaseEventArgs<UserModel> e)
        {
            AddListenerAction(PopulateInventorySummary, e);
        }

        private void _listener_OrderUpdated(object sender, Service.DbEventArgs.BaseEventArgs<OrderModel> e)
        {
            AddListenerAction(PopulateDueReceivables, e);
            AddListenerAction(PopulateBarDiagram, e);
            AddListenerAction(PopulateTransactionSummary, e);
        }
        private void _listener_CompanyUpdated(object sender, Service.DbEventArgs.BaseEventArgs<ViewModel.Core.Settings.CompanyInfoSettingModel> e)
        {
            AddListenerAction(PopulateCompany, e);
        }

        private void _listener_PaymentUpdated(object sender, Service.DbEventArgs.BaseEventArgs<PaymentModel> e)
        {
            AddListenerAction(PopulateDueReceivables, e);
        }

        #endregion

        private void PopulateTransactionSummary()
        {
            var start = dtStart.GetValue().Date;
            var end = dtEnd.GetValue().Date;
            end = end.AddDays(1);
            var summary = _inventoryService.GetTransactionSummary(start, end);
            var purchase = TransactionSummaryKeys.Purchase.ToString();
            var sale = TransactionSummaryKeys.Sale.ToString();
            var purchaseValue = summary.FirstOrDefault(x => x.Key == purchase)?.Value ?? 0;
            var saleValue = summary.FirstOrDefault(x => x.Key == sale)?.Value ?? 0;
            lblPurchase.Text = purchaseValue.ToString("0");
            lblSale.Text = saleValue.ToString("0");
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
                //else if (sum.Key == TransactionSummaryKeys.InventoryQuantity.ToString())
                //{
                //    lblInventoryQuantity.Text = sum.Value.ToString("0");
                //}
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
            var orders = _orderService.GetDueReceivables();
            dgvDueReceivables.AutoGenerateColumns = false;
            dgvDueReceivables.DataSource = orders;
            dgvDueReceivables.AllowUserToAddRows = false;
            dgvDueReceivables.AllowUserToDeleteRows = false;
            dgvDueReceivables.RowHeadersVisible = false;

        }
    }
}
