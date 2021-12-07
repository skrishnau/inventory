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
using ViewModel.Core;
using ViewModel.Enums;

namespace IMS.Forms.MRP
{
    public partial class ManufactureListUC : BaseUserControl
    {
        public event EventHandler<BaseEventArgs<ManufactureModel>> RowSelected;

        private readonly IManufactureService _manufactureService;
        private readonly IDatabaseChangeListener _listener;

        private ManufactureModel _selectedManufacture;

        BindingSource _bindingSource = new BindingSource();
        private ManufactureListPaginationHelper helper;
        int _previousSelectedIndex = -1;

        private List<ManufactureModel> _manufactureList;
        private ManufactureDetailSmallUC _manufactureDetailSmallUC;

        public ManufactureListUC(IManufactureService inventoryService, IDatabaseChangeListener listener)
        {
            this._manufactureService = inventoryService;
            this._listener = listener;

            InitializeComponent();
            // use Header template to display header.
            // InitializeHeader();

            this.dgvProductList.AutoGenerateColumns = false;
            this.Load += ListUC_Load;
        }

        private void ListUC_Load(object sender, EventArgs e)
        {
            //dgvPriceHistory.AutoGenerateColumns = false;
            this.Dock = DockStyle.Fill;
            InitializeGridView();
            InitializeEvents();
            InitializeListeners();
            //PopulateCategoryCombo();
            PopulateManufactureData();

        }
        

        #region Initialize Functions


        private void InitializeGridView()
        {
            dgvProductList.AutoGenerateColumns = false;
            helper = new ManufactureListPaginationHelper(_bindingSource, dgvProductList, bindingNavigator1, _manufactureService);

        }


        private void InitializeEvents()
        {
            dgvProductList.SelectionChanged += DgvProductList_SelectionChanged;
            //dgvProductList.CellDoubleClick += DgvProductList_CellDoubleClick;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            //cbCategory.SelectedIndexChanged += CbCategory_SelectedIndexChanged;
            txtName.TextChanged += TxtName_TextChanged;
            dgvProductList.DataSourceChanged += DgvProductList_DataSourceChanged;
        }

        private void DgvProductList_DataSourceChanged(object sender, EventArgs e)
        {
            PaginationHelper.SetRowNumber(dgvProductList, helper.offset);
        }

        private void InitializeListeners()
        {
            _listener.ManufactureUpdated += _listener_ManufactureUpdated;
            //_listener.InventoryUnitUpdated += _listener_InventoryUnitUpdated;
            //_listener.CategoryUpdated += _listener_CategoryUpdated;
            //_listener.PriceHistoryUpdated += _listener_PriceHistoryUpdated;
        }

        #endregion

        #region Populate Functions


        private void PopulateManufactureData()
        {
            //var category = cbCategory.SelectedItem as IdNamePair;

            if (helper != null)
                helper.Reset( 0, txtName.Text);

        }

        private void ShowManufactureAddEditDialog(int productId)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var productCreate = Program.container.GetInstance<ManufactureCreateForm>();
                productCreate.SetDataForEdit(productId);
                productCreate.ShowDialog();
            }
        }

        private void ShowDeleteDialog(ManufactureModel model)
        {
            var dialogResult = MessageBox.Show(this, "Are you sure to permanently delete this manufacture plan?",
               "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                var deleted = _manufactureService.DeleteManufacture(model.Id);
                PopupMessage.ShowMessage(deleted);
            }
            this.Focus();
        }


        #endregion

        #region Event Handlers

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            PopulateManufactureData();
        }

        /*private void CbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateManufactureData();
        }*/

        /*private void _listener_CategoryUpdated(object sender, Service.Listeners.Inventory.CategoryEventArgs e)
        {
            AddListenerAction(PopulateCategoryCombo, e);
        }*/

        private void _listener_ManufactureUpdated(object sender, BaseEventArgs<ManufactureModel> e)
        {
            AddListenerAction(PopulateManufactureData, e);
        }

        private void _listener_InventoryUnitUpdated(object sender, BaseEventArgs<List<InventoryUnitModel>> e)
        {
            PopulateManufactureData();
        }
        /*
        private void DgvProductList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // if (e.ColumnIndex == this.colSKU.Index || e.ColumnIndex == this.colName.Index)
            {
                try
                {
                    if (_manufactureList[e.RowIndex].IsLessThanMinimumStock)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                        // e.CellStyle.BackColor = Color.LightBlue;
                        e.CellStyle.SelectionBackColor = SystemColors.GradientInactiveCaption; //Color.LightBlue;
                    }
                }
                catch (Exception ex) { }
            }
        }
        private void DgvProductList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var model = dgvProductList.Rows[e.RowIndex].DataBoundItem as ProductModel;
                if (model != null)
                {
                    var args = new BaseEventArgs<ProductModel>(model, Service.Utility.UpdateMode.NONE);
                    RowSelected?.Invoke(sender, args);
                }
            }
        }
       */
        
        private void DgvProductList_SelectionChanged(object sender, EventArgs e)
        {
            // populate detail 
            //PopulateProductDetail();
            if (dgvProductList.SelectedRows.Count > 0)
            {
                // show edit and delete buttons
                
                // btnDelete.Visible = true;
                var data = dgvProductList.SelectedRows[0].DataBoundItem as ManufactureModel;
                if (data != null)
                {

                    var manufactureModel = _manufactureService.GetManufacture(data.Id);
                    if (manufactureModel != null)
                    {
                        if(manufactureModel.Status == ManufactureStatusEnum.New.ToString())
                        {
                            btnEdit.Visible = true;
                            btnDelete.Visible = true;
                        }
                        else
                        {
                            btnEdit.Visible = false;
                            btnDelete.Visible = false;
                        }
                        if (_manufactureDetailSmallUC == null)
                        {
                            _manufactureDetailSmallUC = Program.container.GetInstance<ManufactureDetailSmallUC>();
                            _manufactureDetailSmallUC.Dock = DockStyle.Right;
                            pnlGridView.Controls.Add(_manufactureDetailSmallUC);
                            _manufactureDetailSmallUC.SendToBack();
                        }
                        _manufactureDetailSmallUC.PopulateData(manufactureModel);
                        _manufactureDetailSmallUC.Visible = true;
                    }
                }
                else
                {
                    if (_manufactureDetailSmallUC != null)
                    {
                        _manufactureDetailSmallUC.Visible = false;
                    }
                }
            }
        }
        /*
        private void PopulatePriceHistory(ProductModel data)
        {
            List<PriceHistoryModel> history = _productService.GetPriceHistory(data.Id);
            dgvPriceHistory.DataSource = history;
        }*/

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ShowManufactureAddEditDialog(0);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // get the id from selected row
            var selectedManufacture = GetSelectedManufacture();
            if (selectedManufacture!=null)
            {
                ShowManufactureAddEditDialog(selectedManufacture.Id);
            }
        }
        private ManufactureModel GetSelectedManufacture()
        {
            return dgvProductList.SelectedRows.Count > 0 ? dgvProductList.SelectedRows[0].DataBoundItem as ManufactureModel : null;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedManufacture != null)
            {
                ShowDeleteDialog(_selectedManufacture);
            }
        }






        #endregion
    }
}

