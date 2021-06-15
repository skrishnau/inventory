using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Reports;
using Service.Core.Users;
using ViewModel.Core.Reports;
using Service.Listeners;
using ViewModel.Core.Common;
using IMS.Forms.Inventory.Accounts.All;
using Service.Core.Settings;
using IMS.Forms.Common;
using ViewModel.Enums;
using ViewModel.Utility;
using Service.Interfaces;

namespace IMS.Forms.Inventory.Reports.All
{
    public partial class ProductLedgerUC : BaseUserControl
    {
        private readonly IReportService _reportService;
        private readonly IProductService _productService;
        private readonly IAppSettingService _appSettingService;
        private readonly IDatabaseChangeListener _listener;

        private ProductLedgerMasterModel _ledgerMaster = new ProductLedgerMasterModel();
        private ProductLedgerMasterModel _ledgerMasterForPrint = new ProductLedgerMasterModel();

        BindingSource _bindingSource;
        public ProductLedgerUC(IReportService reportService, IProductService productService, IAppSettingService appSettingService, IDatabaseChangeListener listener)
        {
            _reportService = reportService;
            _productService = productService;
            _appSettingService = appSettingService;
            _listener = listener;

            InitializeComponent();

            this.Load += LedgerUC_Load;
            this.Dock = DockStyle.Fill;
        }

        private void LedgerUC_Load(object sender, EventArgs e)
        {
            _bindingSource = new BindingSource();
            dgvLedger.DataSource = _bindingSource;
            dgvLedger.AutoGenerateColumns = false;
            dtFrom.SetValue(DateTime.Now.AddDays(-7));
            dtTo.SetValue(DateTime.Now);

            InitializeEvents();
            PopulateCategory();
            PopulateProducts();
            //PopulateLedger();

        }

        private void InitializeEvents()
        {
            btnSearch.Click += BtnSearch_Click;
            dgvLedger.DataBindingComplete += DgvLedger_DataBindingComplete;
            _listener.ProductUpdated += _listener_ProductUpdated;
            _listener.CategoryUpdated += _listener_CategoryUpdated;
            btnPrint.Click += BtnPrint_Click;

            cbCategory.SelectedValueChanged += CbCategory_SelectedValueChanged;
            chkDateFilter.CheckedChanged += ChkDateFilter_CheckedChanged;

        }

        private void _listener_CategoryUpdated(object sender, Service.Listeners.Inventory.CategoryEventArgs e)
        {
            AddListenerAction(PopulateCategory, e);
        }

        private void _listener_ProductUpdated(object sender, Service.Listeners.Inventory.ProductEventArgs e)
        {
            AddListenerAction(PopulateProducts, e);
        }

        private void ChkDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            dtFrom.Enabled = chkDateFilter.Checked;
            dtTo.Enabled = chkDateFilter.Checked;

        }

        private void CbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            //InitializeSearchTextBox();
            PopulateProducts();
        }
        

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //var ledgerMaster = GetLedger();
            if (_ledgerMasterForPrint != null)
            {
                var form = new ProductLedgerPrintForm(_appSettingService, _ledgerMasterForPrint);
                form.ShowDialog();
            }
            else
            {
                PopupMessage.ShowInfoMessage("Empty ledger!");
            }
        }
        
        
        private void DgvLedger_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvLedger.DataBindingComplete -= DgvLedger_DataBindingComplete;
            int rowIndex = dgvLedger.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (rowIndex > 0)
            {
                dgvLedger.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                dgvLedger.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                //dgvLedger.Rows[rowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);//

                // make bold if Dr
            }
            dgvLedger.DataBindingComplete += DgvLedger_DataBindingComplete;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PopulateLedger();
        }
        private void PopulateCategory()
        {
            var categories = _productService.GetAllCategoriesForCombo();
            categories.Insert(0, new IdNamePair { Id = 0, Name = "-- ALL --" });
            cbCategory.ValueMember = "Id";
            cbCategory.DisplayMember = "Name";
            cbCategory.DataSource = categories;
        }
        private void PopulateProducts()
        {
            var item = cbCategory.SelectedItem as IdNamePair;
            if (item != null)
            {
                var categoryId = item.Id;
                var products = _productService.GetProductListForCombo(categoryId);
                products.Insert(0, new IdNamePair(0, "-- Select Product --"));
                cbProduct.DataSource = products;

                cbProduct.ValueMember = "Id";
                cbProduct.DisplayMember = "Name";
            }
        }
        private ProductLedgerMasterModel GetLedger()
        {
            var from = dtFrom.GetValue();
            var to = dtTo.GetValue();
            //int productId = 0;
            int.TryParse(cbProduct.SelectedValue?.ToString(), out int productId);
            var categoryIdStr = cbCategory.SelectedValue?.ToString() ?? "";
            int.TryParse(categoryIdStr, out int categoryId);
            if (productId == 0 && categoryId == 0)
            {
                PopupMessage.ShowInfoMessage("Please select either category or product or both");
                this.Focus();
                return null;
            }
            var model = new ProductLedgerRequestModel
            {
                CategoryId = categoryId,
                ProductId = productId,
                From = from,
                To = to,
                ApplyDateFilter = chkDateFilter.Checked,
            };
            return _reportService.GetProductLedger(model);
        }

        private void PopulateLedger()
        {
            _ledgerMaster = GetLedger();

            if (_ledgerMaster != null)
            {
                _ledgerMasterForPrint = GetLedger();

                _ledgerMaster.ProductLedgerData.Add(new ProductLedgerModel()
                {
                    IsManualNewRow = true,
                    //Balance = _ledgerMaster.BalanceSum,
                    //Credit = _ledgerMaster.CreditSum,
                    //Debit = _ledgerMaster.DebitSum,
                    //DrCr = _ledgerMaster.DrCr,
                    //DrCrString = _ledgerMaster.DrCrString,
                    //Particulars = "Total"
                    ReferenceNo = "Total",
                });
                _bindingSource.DataSource = _ledgerMaster.ProductLedgerData;
                _bindingSource.ResetBindings(false);
                //dgvLedger.DataSource = ledgerList;
                //dgvLedger.DataBindings.
            }
            else
            {
                _bindingSource.DataSource = null;
                _bindingSource.ResetBindings(false);
            }
        }
    }
}
