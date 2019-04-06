using System;
using System.Windows.Forms;
using Service.Core.Suppliers;
using SimpleInjector.Lifestyles;
using IMS.Forms.Common.Display;
using Service.Listeners;
using ViewModel.Core.Suppliers;

namespace IMS.Forms.Inventory.Suppliers
{
    public partial class SupplierUC : UserControl
    {
        private readonly ISupplierService _supplierService;
        private readonly IDatabaseChangeListener _listener;

        SupplierModel _selectedSupplierModel;
        SubHeadingTemplate _header;

        public SupplierUC(ISupplierService supplierService, IDatabaseChangeListener listener)
        {
            this._supplierService = supplierService;
            _listener = listener;

            InitializeComponent();
            InitializeHeader();
            Populate();

            InitializeEvents();
        }


        #region Initialization Functions

        private void InitializeHeader()
        {
            _header = SubHeadingTemplate.Instance;
            _header.btnNew.Visible = true;
            _header.btnNew.Click += BtnNew_Click;
            _header.btnEdit.Click += BtnEdit_Click;
            _header.btnDelete.Click += BtnDelete_Click;
            this.Controls.Add(_header);
            _header.SendToBack();

            _header.lblHeading.Text = "Suppliers";
        }
        
        private void InitializeEvents()
        {
            _listener.SupplierUpdated += _listener_SupplierUpdated;
            dgvSuppliers.SelectionChanged += DgvSuppliers_SelectionChanged;
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
            _header.btnEdit.Visible = visible;
            _header.btnDelete.Visible = visible;
        }


        #endregion




    }
}
