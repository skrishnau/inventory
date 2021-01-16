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
using ViewModel.Core.Inventory;
using Service.Core.Inventory;
using IMS.Forms.Common;
using Service.Listeners;
using SimpleInjector.Lifestyles;

namespace IMS.Forms.Inventory.Packages
{
    public partial class PackageUC : UserControl
    {
        private readonly IDatabaseChangeListener _listener;
        private readonly IInventoryService _inventoryService;
        private bool _isRowDirty;

        public PackageUC(IInventoryService inventoryService, IDatabaseChangeListener listener)
        {
            _inventoryService = inventoryService;
            _listener = listener;

            InitializeComponent();


            this.Load += PackageUC_Load;
        }

        private void PackageUC_Load(object sender, EventArgs e)
        {
            dgvPackage.AutoGenerateColumns = false;
            this.Dock = DockStyle.Fill;
            //InitializeHeader();
            InitializeEvents();
            PopulatePackageData();
        }

        private void InitializeEvents()
        {
            _listener.PackageUpdated += _listener_PackageUpdated;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            dgvPackage.SelectionChanged += DgvPackage_SelectionChanged;
        }

        private void DgvPackage_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Visible = dgvPackage.SelectedRows.Count > 0;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            PackageModel package = dgvPackage.SelectedRows.Count > 0 ? dgvPackage.SelectedRows[0].DataBoundItem as PackageModel : null;
            ShowAddEditDialog(package?.Id ?? 0);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ShowAddEditDialog(0);
        }

        private void ShowAddEditDialog(int packageId)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var productCreate = Program.container.GetInstance<PackageCreateForm>();
                productCreate.SetDataForEdit(packageId);
                productCreate.ShowDialog();
            }
        }

        private void PopulatePackageData()
        {
            var packages = _inventoryService.GetPackageList();
            dgvPackage.DataSource = packages;
        }

        private void _listener_PackageUpdated(object sender, Service.DbEventArgs.BaseEventArgs<PackageModel> e)
        {
            PopulatePackageData();
        }
        
        //private void InitializeHeader()
        //{
        //    //var _header = HeaderTemplate.Instance;
        //    //_header.lblHeading.Text = "Packaging Types";
        //    //this.Controls.Add(_header);
        //    //_header.SendToBack();
        //}
    }
}

/*
 // code that saves directly from editing DataGridView
   private void AddRow(PackageModel pkg)
        {
            var row = (DataGridViewRow)dgvPackage.Rows[dgvPackage.RowCount - 1].Clone();
            row.Cells[colId.Index].Value = pkg.Id;
            row.Cells[colName.Index].Value = pkg.Name;
            row.Cells[colUse.Index].Value = pkg.Use;
            dgvPackage.Rows.Add(row);
        }



  private void PopulatePackageData()
        {
            dgvPackage.Rows.Clear();
            var packages = _inventoryService.GetPackageList();

            foreach (var pkg in packages)
            {
                AddRow(pkg);
            }
        }
    // initializeEvents
     dgvPackage.RowValidated += DgvPackage_RowValidated;
            dgvPackage.CurrentCellDirtyStateChanged += DgvPackage_CurrentCellDirtyStateChanged;


  private void DgvPackage_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            _isRowDirty = true;
        }
     private void DgvPackage_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            // save the row if not empty
            if (_isRowDirty && e.RowIndex < dgvPackage.RowCount - 1)
            {
                _isRowDirty = false;
                var package = GetPackageData(e.RowIndex);
                if (package == null)
                {
                    return;
                }
                // save
                var msg = _inventoryService.SavePackage(package);
                if (string.IsNullOrEmpty(msg.Message))
                {
                    // save success
                    PopupMessage.ShowSaveSuccessMessage();
                }
                else
                {
                    PopupMessage.ShowErrorMessage(msg.Message);
                }
                dgvPackage.Focus();
            }
        }
  private PackageModel GetPackageData(int rowIndex)
        {
            var row = dgvPackage.Rows[rowIndex];
            var name = row.Cells[colName.Name].Value;
            var id = row.Cells[colId.Name].Value;
            var use = row.Cells[colUse.Name].Value;
            if (name == null || string.IsNullOrEmpty(name.ToString()))
            {
                row.Cells[colName.Name].ErrorText = "Required";
                return null;
            }
            row.Cells[colName.Name].ErrorText = string.Empty;

            return new PackageModel()
            {
                Id = int.Parse(id == null ? "0" : string.IsNullOrEmpty(id.ToString()) ? "0" : id.ToString()),
                Name = name == null ? "" : name.ToString(),
                Use = use == null ? false : bool.Parse(use.ToString()),
            };
        }

 */
