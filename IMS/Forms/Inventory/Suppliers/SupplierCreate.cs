using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Suppliers;
using ViewModel.Core.Suppliers;

namespace IMS.Forms.Inventory.Suppliers
{
    public partial class SupplierCreate : Form
    {
        private readonly ISupplierService supplierService;
        public SupplierCreate(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = new SupplierModel
            {
                Address = tbAddress.Text,
                Name = tbName.Text,
                Email = tbEmail.Text,
                Phone = tbPhone.Text,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now

            };

            supplierService.AddOrUpdateSupplier(model);
            this.Close();


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
