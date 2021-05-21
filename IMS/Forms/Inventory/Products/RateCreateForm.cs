using IMS.Forms.Common;
using Service.Core.Inventory;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core;
using ViewModel.Core.Inventory;
using ViewModel.Enums;

namespace IMS.Forms.Inventory.Products
{
    public partial class RateCreateForm : Form
    {
        private readonly IProductService _productService;
        private readonly IInventoryService _inventoryService;
        private readonly IUomService _uomService;
        private OrderTypeEnum _orderType;
        private DateTime _date;


        public RateCreateForm(IProductService productService, IInventoryService inventoryService, IUomService uomService)
        {
            _productService = productService;
            _inventoryService = inventoryService;
            _uomService = uomService;
            InitializeComponent();

            this.Load += RateCreateForm_Load;
            rateDataGridView.dgvRates.InitializeGridViewControls(_inventoryService, _productService, _uomService);
            rateDataGridView.dgvRates.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }
        
        public void SetData(OrderTypeEnum orderType, DateTime date)
        {
            _orderType = orderType;
            _date = date;
        }

        private void RateCreateForm_Load(object sender, EventArgs e)
        {
            dtDate.SetValue(_date);
            txtType.Text = _orderType.ToString() ;

            rateDataGridView.dgvRates.DesignForPriceHistoryCreate(false, true);

            PopulateData();
            rateDataGridView.dgvRates.Focus();

            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            List<DataGridViewColumn> ignoreList = new List<DataGridViewColumn>
            {
                rateDataGridView.dgvRates.colRate,
                rateDataGridView.dgvRates.colUnitQuantity
            };
            var data = rateDataGridView.dgvRates.GetItems(ignoreList, false);
            if (data != null)
            {
                var response = _productService.SavePriceHistory(data, dtDate.GetValue(), _orderType);
                if (response.Success)
                {
                    PopupMessage.ShowSaveSuccessMessage();
                    this.Close();
                }
                else
                {
                    PopupMessage.ShowInfoMessage(response.Message);
                    this.Focus();
                }
            }
        }
        
        private void PopulateData()
        {
            var prices = _productService.GetPriceHistory(0, _date, _orderType);
            
            if(rateDataGridView.dgvRates.Rows.Count == 0)
                rateDataGridView.dgvRates.Rows.Add();
            foreach(var p in prices)
            {
                DataGridViewRow row = (DataGridViewRow)rateDataGridView.dgvRates.Rows[0].Clone();
                row.Cells[rateDataGridView.dgvRates.colProduct.Index].Value = p.Product;
                row.Cells[rateDataGridView.dgvRates.colProductId.Index].Value = p.ProductId;
                row.Cells[rateDataGridView.dgvRates.colRate.Index].Value = p.Rate == 0 ? (null) : (decimal?)p.Rate;//p.SellingPrice;
                //row.Cells[rateDataGridView.dgvRates.colCostPrice.Index].Value = p.CostPrice;
                //row.Cells[colSellingPricePackage.Index].Value = p.SellingPricePackage;
                //row.Cells[colCostPricePackage.Index].Value = p.CostPricePackage;
                row.Cells[rateDataGridView.dgvRates.colDate.Index].Value = p.DateString;
                row.Cells[rateDataGridView.dgvRates.colPackage.Index].Value = p.Package;
                row.Cells[rateDataGridView.dgvRates.colPackageId.Index].Value = p.PackageId;
                row.Tag = p;
                rateDataGridView.dgvRates.Rows.Add(row);

            }
            if (rateDataGridView.dgvRates.Rows.Count > prices.Count)
                rateDataGridView.dgvRates.Rows.RemoveAt(0);
        }
    }
}
