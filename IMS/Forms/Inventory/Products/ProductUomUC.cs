using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Inventory;
using Service.Core.Inventory;
using ViewModel.Core.Common;

namespace IMS.Forms.Inventory.Products
{
    public partial class ProductUomUC : UserControl
    {

        public event EventHandler<EventArgs> OnDelete;
        public event EventHandler<EventArgs> OnPackageComboChanged;
        private UomModel _model;

        private IInventoryService _inventoryService;

        public ProductUomUC(IInventoryService inventoryService, UomModel model)
        {
            _model = model;
            _inventoryService = inventoryService;

            InitializeComponent();
            this.Load += ProductUomUC_Load;
        }



        private void ProductUomUC_Load(object sender, EventArgs e)
        {
            txtQuantity.Maximum = Int32.MaxValue;
            txtQuantity.Minimum = 0;
            PopulatePackage();
            PopulateUomData();

            this.btnDelete.Click += BtnDelete_Click;
            cbRelatedPackage.SelectedValueChanged += CbRelatedPackage_SelectedValueChanged;
            cbPackage.SelectedValueChanged += CbPackage_SelectedValueChanged;
            
        }

        private void CbPackage_SelectedValueChanged(object sender, EventArgs e)
        {
            CheckPackagesAndChangeQuantity();
            OnPackageComboChanged?.Invoke(sender, e);
        }

        private void CbRelatedPackage_SelectedValueChanged(object sender, EventArgs e)
        {
            CheckPackagesAndChangeQuantity();
            OnPackageComboChanged?.Invoke(sender, e);
        }

        private void CheckPackagesAndChangeQuantity()
        {
            var packageId = GetPackageId();
            var relatedPackageId = GetRelatedPackageId();
            if (packageId == relatedPackageId)
            {
                txtQuantity.Value = 1;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            OnDelete?.Invoke(this, e);
        }

        private void PopulatePackage()
        {
            var packages = _inventoryService.GetPackageList();
            cbPackage.DataSource = packages;
            cbPackage.ValueMember = "Id";
            cbPackage.DisplayMember = "Name";

            var relatedPackages = _inventoryService.GetPackageList();
            cbRelatedPackage.DataSource = relatedPackages;
            cbRelatedPackage.ValueMember = "Id";
            cbRelatedPackage.DisplayMember = "Name";
        }


        private void PopulateUomData()
        {
            if (_model != null)
            {
                txtQuantity.Value = _model.Quantity;
                cbPackage.SelectedValue = _model.PackageId;
                cbRelatedPackage.SelectedValue = _model.RelatedPackageId;
            }
        }

        private string GetPackage(ComboBox cb)
        {
            var val = cb.SelectedItem as PackageModel;
            if (val != null)
                return val.Name;
            return null;
        }

        private int GetPackageId()
        {
            int packageId = 0;
            int.TryParse(cbPackage.SelectedValue?.ToString() ?? string.Empty, out packageId);
            return packageId;
        }

        private int GetRelatedPackageId()
        {
            int relatedPackageId = 0;
            int.TryParse(cbRelatedPackage.SelectedValue?.ToString() ?? string.Empty, out relatedPackageId);
            return relatedPackageId;
        }

        public UomModel GetData(ErrorProvider errorProvider, ref string message, bool doValidation = true)
        {
            errorProvider.SetError(cbPackage, string.Empty);
            errorProvider.SetError(cbRelatedPackage, string.Empty);
            errorProvider.SetError(txtQuantity, string.Empty);
            var packageId = GetPackageId();
            var relatedPackageId = GetRelatedPackageId();
           
            if (packageId == 0)
            {
                errorProvider.SetError(cbPackage, "Required");
                message += "Package is required.\n";
                return null;
            }
            if ( doValidation && relatedPackageId > 0 && txtQuantity.Value == 0)
            {
                errorProvider.SetError(txtQuantity, "Quantity should be greater than zero.");
                message += "Quantity should be greater than zero.\n";
                return null;
            }
            if(doValidation && txtQuantity.Value > 0 && relatedPackageId == 0)
            {
                errorProvider.SetError(cbRelatedPackage, "Required");
                message += "Related package is required.\n";
                return null;
            }
            return new UomModel()
            {
                Id = _model?.Id ?? 0,
                RelatedPackageId = relatedPackageId == 0 ? packageId : relatedPackageId,
                Quantity = relatedPackageId == 0 || relatedPackageId == packageId ? 1 : txtQuantity.Value,
                Use = true,
                ProductId = _model?.ProductId ?? 0,
                PackageId = packageId,
                Package = GetPackage(cbPackage),
                RelatedPackage = GetPackage(cbRelatedPackage),
            };
        }
    }
}
