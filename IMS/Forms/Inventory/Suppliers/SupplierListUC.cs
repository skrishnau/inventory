using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Suppliers;
using Service.Listeners;
using ViewModel.Core.Suppliers;
using IMS.Forms.Common.Display;
using SimpleInjector.Lifestyles;
using Service.DbEventArgs;

namespace IMS.Forms.Inventory.Suppliers
{
    public partial class SupplierListUC : UserControl
    {
        public event EventHandler<BaseEventArgs<SupplierModel>> RowSelected;

        private readonly ISupplierService _supplierService;
        private readonly IDatabaseChangeListener _listener;

        SupplierModel _selectedSupplierModel;
        //HeaderTemplate _header;

        public SupplierListUC(ISupplierService supplierService, IDatabaseChangeListener listener)
        {
            this._supplierService = supplierService;
            _listener = listener;

            InitializeComponent();

            this.Load += SupplierUC_Load;

            this.Dock = DockStyle.Fill;

        }

        private void SupplierUC_Load(object sender, EventArgs e)
        {
           // InitializeHeader();
            Populate();

            InitializeEvents();
        }


        #region Initialization Functions

        //private void InitializeHeader()
        //{
        //    _header = HeaderTemplate.Instance;
        //    _header.btnNew.Visible = true;
        //    _header.btnNew.Click += BtnNew_Click;
        //    _header.btnEdit.Click += BtnEdit_Click;
        //    _header.btnDelete.Click += BtnDelete_Click;
        //    this.Controls.Add(_header);
        //    _header.SendToBack();

        //    _header.lblHeading.Text = "Suppliers";
        //}

        private void InitializeEvents()
        {
            _listener.SupplierUpdated += _listener_SupplierUpdated;
            dgvSuppliers.SelectionChanged += DgvSuppliers_SelectionChanged;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            dgvSuppliers.CellMouseDoubleClick += DgvSuppliers_CellMouseDoubleClick;
        }

        private void DgvSuppliers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var rowData = dgvSuppliers.Rows[e.RowIndex].DataBoundItem as SupplierModel;
            if (rowData != null)
            {
                var args = new BaseEventArgs<SupplierModel>(rowData, Service.Utility.UpdateMode.NONE);
                RowSelected?.Invoke(sender, args);
            }
        }

        #endregion



        #region EventHandlers

        private void _listener_SupplierUpdated(object sender, Service.DbEventArgs.BaseEventArgs<ViewModel.Core.Suppliers.SupplierModel> e)
        {
            Populate();
        }

        private void DgvSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            _selectedSupplierModel = dgvSuppliers.SelectedRows.Count > 0 ? dgvSuppliers.SelectedRows[0].DataBoundItem as SupplierModel : null;
            ShowEditDeleteButtons();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ShowAddEditDialog(false);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ShowAddEditDialog(true);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedSupplierModel != null)
            {
                var dialogResult = MessageBox.Show(this, "Are you sure to delete?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult.Equals(DialogResult.Yes))
                {
                    _supplierService.DeleteSupplier(_selectedSupplierModel.Id);
                }
            }
        }

        #endregion



        #region Population Functions

        private void Populate()
        {
            dgvSuppliers.AutoGenerateColumns = false;
            var supplier = _supplierService.GetSupplierList();
            dgvSuppliers.DataSource = supplier;
        }

        private void ShowAddEditDialog(bool isEditMode)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var supplierCreate = Program.container.GetInstance<SupplierCreate>();// (supplier);
                supplierCreate.SetDataForEdit(isEditMode ? _selectedSupplierModel == null ? 0 : _selectedSupplierModel.Id : 0);
                supplierCreate.ShowDialog();
            }
        }

        private void ShowEditDeleteButtons()
        {
            var visible = _selectedSupplierModel != null;
            btnEdit.Visible = visible;
            btnDelete.Visible = visible;
        }


        #endregion

    }
}
