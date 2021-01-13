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
            this.Dock = DockStyle.Fill;
            //InitializeHeader();
            InitializeEvents();
            PopulatePackageData();
        }

        private void PopulatePackageData()
        {
            var packages = _inventoryService.GetPackageList();
            foreach (var pkg in packages)
            {
                AddRow(pkg);
            }
        }

        private void AddRow(PackageModel pkg)
        {
            var row = (DataGridViewRow)dgvPackage.Rows[dgvPackage.RowCount - 1].Clone();
            row.Cells[colId.Index].Value = pkg.Id;
            row.Cells[colName.Index].Value = pkg.Name;
            row.Cells[colUse.Index].Value = pkg.Use;
            dgvPackage.Rows.Add(row);
        }

        private void InitializeEvents()
        {
            dgvPackage.RowValidated += DgvPackage_RowValidated;
            dgvPackage.CurrentCellDirtyStateChanged += DgvPackage_CurrentCellDirtyStateChanged;
            _listener.PackageUpdated += _listener_PackageUpdated;
        }

        private void _listener_PackageUpdated(object sender, Service.DbEventArgs.BaseEventArgs<PackageModel> e)
        {
            PopulatePackageData();
        }

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
                if (string.IsNullOrEmpty(msg))
                {
                    // save success
                    PopupMessage.ShowSaveSuccessMessage();
                }
                else
                {
                    PopupMessage.ShowErrorMessage(msg);
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

        //private void InitializeHeader()
        //{
        //    //var _header = HeaderTemplate.Instance;
        //    //_header.lblHeading.Text = "Packaging Types";
        //    //this.Controls.Add(_header);
        //    //_header.SendToBack();
        //}
    }
}
