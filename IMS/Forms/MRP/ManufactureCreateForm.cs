using Service.Core.Settings;
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

namespace IMS.Forms.MRP
{
    public partial class ManufactureCreateForm : Form
    {
        private readonly IManufactureService _manufactureService;
        private readonly IAppSettingService _appSettingService;
        int _id = 0;
        public ManufactureCreateForm(IManufactureService manufactureService, IAppSettingService appSettingService)
        {
            _manufactureService = manufactureService;
            _appSettingService = appSettingService;

            InitializeComponent();

            this.Load += ManufactureCreateForm_Load;
        }

        public void SetDataForEdit(int id)
        {
            var model = _manufactureService.GetManufacture(id);
            if (model != null)
            {
                _id = model.Id;
                txtName.Text = model.Name;
                txtLotNo.Value = model.LotNo;
                txtRemarks.Text = model.Remarks;
            }
            else
            {
                txtLotNo.Value = _manufactureService.GetLastLotNo() + 1;
            }
        }

        private void ManufactureCreateForm_Load(object sender, EventArgs e)
        {
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            var isInvalid = false;
            errorProvider1.SetError(txtName, string.Empty);
            errorProvider1.SetError(txtLotNo, string.Empty);
            if (string.IsNullOrEmpty(txtName.Text))
            {
                isInvalid = true;
                errorProvider1.SetError(txtName, "Required");
            }
            if(txtLotNo.Value <= 0)
            {
                isInvalid = true;
                errorProvider1.SetError(txtLotNo, "Should be greater than zero");
            }

            if (isInvalid)
                return;
            var model = new ManufactureModel()
            {
                Id = _id,
                LotNo = (int) txtLotNo.Value,
                Name = txtName.Text,
                Remarks = txtRemarks.Text,
            };
            bool success = _manufactureService.SaveManufacture(model);
            this.Close();
        }
    }
}
