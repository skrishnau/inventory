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
using IMS.Forms.Business.Create;
using SimpleInjector.Lifestyles;
using Service.Core.Business;
using ViewModel.Core.Business;
using Service.Listeners;
using Service.DbEventArgs;
using Service.Core.Inventory;

namespace IMS.Forms.Inventory.Warehouses
{
    public partial class WarehouseListUC : UserControl
    {
        private readonly IBusinessService _businessService;
        private readonly IInventoryService _inventoryService;
        private readonly IDatabaseChangeListener _listener;
       // private HeaderTemplate _header;
        private WarehouseModel _selectedWarehouseModel;

        public WarehouseListUC(IBusinessService businessService, IInventoryService inventoryService, IDatabaseChangeListener listener)
        {
            this._businessService = businessService;
            this._inventoryService = inventoryService;

            _listener = listener;

            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.Load += WarehouseListUC_Load;

           
        }

        private void WarehouseListUC_Load(object sender, EventArgs e)
        {
            //InitializeHeader();
            PopulateWarehouseData();


            InitializeControlEvents();
            InitializeListeners();
        }

        #region Population Funcions

        private void PopulateWarehouseData()
        {
            dgvWarehouse.AutoGenerateColumns = false;
            var warehouses = _inventoryService.GetWarehouseList();
            dgvWarehouse.DataSource = warehouses;
        }

        private void ShowHideEditDeleteButtons()
        {
            var visible = _selectedWarehouseModel != null;
            btnEdit.Visible = visible;
           // btnDelete.Visible = visible;
        }

        private void ShowAddEditDialog(bool isEditMode)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var wareHouseCreate = Program.container.GetInstance<WarehouseCreateForm>();
                wareHouseCreate.SetDataForEdit(isEditMode ? _selectedWarehouseModel == null ? 0 : _selectedWarehouseModel.Id : 0);
                wareHouseCreate.ShowDialog();
            }
        }



        #endregion



        #region Initialization Functions

        //private void InitializeHeader()
        //{
        //    _header = HeaderTemplate.Instance;
        //    _header.btnNew.Visible = true;
        //    _header.btnNew.Click += BtnNew_Click;
        //    _header.btnEdit.Click += BtnEdit_Click;
        //    _header.btnDelete.Click += BtnDelete_Click;
        //    // add
        //    this.Controls.Add(_header);
        //    _header.SendToBack();
        //    // heading
        //    _header.lblHeading.Text = "Warehouses";

        //}

        private void InitializeControlEvents()
        {
            dgvWarehouse.SelectionChanged += DgvWarehouse_SelectionChanged;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
           // btnDelete.Click += BtnDelete_Click;
        }

        private void InitializeListeners()
        {
            // first remove earlier if any then add; to ensure single callback 
            _listener.WarehouseUpdated -= _listener_WarehouseUpdated;
            _listener.WarehouseUpdated += _listener_WarehouseUpdated;
        }

        #endregion


        #region  Events

        private void _listener_WarehouseUpdated(object sender, BaseEventArgs<WarehouseModel> e)
        {
            PopulateWarehouseData();
        }

        private void DgvWarehouse_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvWarehouse.SelectedRows.Count > 0)
            {

                _selectedWarehouseModel = dgvWarehouse.SelectedRows[0].DataBoundItem as WarehouseModel;
            }
            else
            {
                _selectedWarehouseModel = null;
            }
            ShowHideEditDeleteButtons();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ShowAddEditDialog(false);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedWarehouseModel != null)
            {
                ShowAddEditDialog(true);
            }
        }

        //private void BtnDelete_Click(object sender, EventArgs e)
        //{
        //    if (_selectedWarehouseModel != null)
        //    {
        //        var dialogResult = MessageBox.Show(this, "Are you sure to delete?", "Delete", MessageBoxButtons.YesNo);
        //        if (dialogResult.Equals(DialogResult.Yes))
        //        {
        //            _inventoryService.DeleteWarehouse(_selectedWarehouseModel.Id);
        //        }
        //    }
        //}

        #endregion





    }
}
