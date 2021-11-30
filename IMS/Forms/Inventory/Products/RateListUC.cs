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
using SimpleInjector.Lifestyles;
using IMS.Forms.Inventory.Create;
using IMS.Forms.Inventory.Variants;
using ViewModel.Core.Inventory;
using IMS.Forms.Common.Display;
using Service.Listeners;
using Service.DbEventArgs;
using Service.Interfaces;
using IMS.Forms.Common.Pagination;
using ViewModel.Core.Common;
using IMS.Forms.Common;
using ViewModel.Enums;

namespace IMS.Forms.Inventory.Products
{
    public partial class RateListUC : BaseUserControl
    {
        private readonly IProductService _productService;
        private readonly IInventoryService _inventoryService;
        private readonly IUomService _uomService;
        private readonly IDatabaseChangeListener _listener;

        public RateListUC(IProductService productService, IInventoryService inventoryService, IUomService uomService, IDatabaseChangeListener listener)
        {
            this._productService = productService;
            this._inventoryService = inventoryService;
            this._uomService = uomService;
            this._listener = listener;

            InitializeComponent();

            this.Dock = DockStyle.Fill;

            this.Load += RateListUC_Load;
            this.dtDate.SetValue(DateTime.Now);
        }

        private void RateListUC_Load(object sender, EventArgs e)
        {
            InitializeEvents();
            PopulateOrderType();

            rateDataGridView.dgvRates.InitializeGridViewControls(_inventoryService, _productService, _uomService);
            rateDataGridView.dgvRates.DesignForPriceHistory(false, true);
            PopulatePriceData();
        }

        private void PopulateOrderType()
        {
            var orderTypes = Enum.GetValues(typeof(OrderTypeEnum)).Cast<OrderTypeEnum>();
            var list = new List<IdNamePair>
            {
                new IdNamePair{Id = (int)OrderTypeEnum.Sale, Name = OrderTypeEnum.Sale.ToString() },
                new IdNamePair{Id = (int)OrderTypeEnum.Purchase, Name = OrderTypeEnum.Purchase.ToString() },
            };
            cbType.DisplayMember = "Name";
            cbType.ValueMember = "Id";
            cbType.DataSource = list;
        }


        #region Initialize Functions




        private void InitializeEvents()
        {
            btnUpdateRates.Click += BtnUpdatePrice_Click;

            _listener.ProductUpdated += _listener_ProductUpdated;
            _listener.PriceHistoryUpdated += _listener_PriceHistoryUpdated;
            //btnSearch.Click += BtnSearch_Click;
            cbType.SelectedValueChanged += CbType_SelectedValueChanged;
            dtDate.TextChanged += DtDate_TextChanged;
        }

        





        #endregion

        #region Populate Functions


        private void PopulatePriceData()
        {
            //Enum.TryParse<OrderTypeEnum>(cbType.SelectedValue?.ToString() ?? "", out orderType);
            var orderType = GetOrderType();
            var history = _productService.GetPriceHistory(0, dtDate.GetValue(), orderType);
            this.rateDataGridView.dgvRates.DataSource = history;
        }

        private OrderTypeEnum GetOrderType()
        {
            if (!int.TryParse(cbType.SelectedValue?.ToString(), out int s))
            {
                s = (int)OrderTypeEnum.Sale;
            }
            var orderType = (OrderTypeEnum)s;
            return orderType;
        }


        #endregion

        #region Event Handlers

        private void DtDate_TextChanged(object sender, EventArgs e)
        {
            PopulatePriceData();
        }

        private void CbType_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulatePriceData();
        }
        private void _listener_ProductUpdated(object sender, BaseEventArgs<ProductModel> e)
        {
            PopulatePriceData();
        }

        private void _listener_PriceHistoryUpdated(object sender, BaseEventArgs<PriceHistoryModel> e)
        {
            if (e.Model == null || e.Model?.Date.Date == dtDate.GetValue().Date)
                PopulatePriceData();
        }


        private void BtnUpdatePrice_Click(object sender, EventArgs e)
        {
            var rateUpdate = new RateCreateForm(_productService, _inventoryService, _uomService);
            rateUpdate.SetData(GetOrderType(), dtDate.GetValue());
            rateUpdate.ShowDialog(this);
        }

        //private void BtnSearch_Click(object sender, EventArgs e)
        //{
        //    PopulatePriceData();
        //}


        #endregion

    }
}
