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
        private SubBodyTemplate _bodyTemplate;

        private readonly SupplierListUC _supplierListUC;
        private readonly SupplierSideBarUC _sidebarUC;
        private readonly SupplierDetailUC _supplierDetailUC;


        public SupplierUC(SupplierListUC supplierListUC, SupplierSideBarUC supplierSideBarUC, SupplierDetailUC supplierDetailUC)
        {
            _supplierListUC = supplierListUC;
            _sidebarUC = supplierSideBarUC;
            _supplierDetailUC = supplierDetailUC;

            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += SupplierUC_Load;
        }

        private void SupplierUC_Load(object sender, EventArgs e)
        {
            InitializeSubBody();

            InitializeEvents();

            ShowUI(_sidebarUC.lnkList, 0);

        }

        private void InitializeSubBody()
        {
            _bodyTemplate = new SubBodyTemplate();
            _bodyTemplate.HeadingText = "Suppliers";
            _bodyTemplate.SubHeadingText = "";
            this.Controls.Add(_bodyTemplate);

            _bodyTemplate.pnlSideBar.Controls.Add(_sidebarUC);
        }

        private void InitializeEvents()
        {
            _sidebarUC.lnkList.LinkClicked += LnkList_LinkClicked;
            //_supplierListUC.RowSelected += _supplierListUC_RowSelected;
        }

        //private void _supplierListUC_RowSelected(object sender, Service.DbEventArgs.BaseEventArgs<SupplierModel> e)
        //{
        //    if (e.Model != null)
        //    {
        //        ShowUI(sender, e.Model.Id);
        //    }
        //}

        private void LnkList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowUI(sender, 0);
        }

        private void ShowUI(object sender, int supplierId)
        {
            _bodyTemplate.pnlBody.Controls.Clear();
            if (supplierId == 0)
            {
                _bodyTemplate.pnlBody.Controls.Add(_supplierListUC);
                _bodyTemplate.SubHeadingText = "Supplier List";
            }
            else
            {
                _supplierDetailUC.SetData(supplierId);
                _bodyTemplate.pnlBody.Controls.Add(_supplierDetailUC);
            }
            _sidebarUC.SetVisited(sender);
        }
    }
}
