using System;
using System.Windows.Forms;
using IMS.Forms.Inventory.UOM;
using IMS.Forms.Inventory.Packages;
using IMS.Forms.Inventory.Settings.Adjustments;
using IMS.Forms.Inventory.Categories;
using IMS.Forms.Common.Display;
using IMS.Forms.Inventory.Settings.References;
using IMS.Forms.Inventory.Settings.General;
using IMS.Forms.Inventory.Warehouses;
using IMS.Forms.Inventory.Suppliers;

namespace IMS.Forms.Inventory.Settings
{
    public partial class InventorySettingsUC : UserControl
    {
        private SettingsBodyTemplate _body;

        private readonly InventorySettingsSidebarUC _sidebar;
        public InventorySettingsUC(InventorySettingsSidebarUC sidebar)
        {
            _sidebar = sidebar;

            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += InventorySettingsUC_Load;

        }

        private void InventorySettingsUC_Load(object sender, EventArgs e)
        {
            
            InitializeBody();

            InitializeEvents();

            SelectGeneralLink();
        }

        private void InitializeBody()
        {
            _body = new SettingsBodyTemplate
            {
                HeadingText = "Settings",
                SubHeadingText = ""
            };
            _body.pnlBody.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(_body);
            _body.pnlSideBar.Controls.Add(_sidebar);
        }

        private void InitializeEvents()
        {
            _sidebar.lnkGeneral.LinkClicked += LnkGeneral_LinkClicked;
            _sidebar.lnkAdjustmentCodes.LinkClicked += LnkAdjustmentCodes_LinkClicked;
            _sidebar.lnkPackages.LinkClicked += LnkPackages_LinkClicked;
            _sidebar.lnkProductCategory.LinkClicked += LnkProductCategory_LinkClicked;
            _sidebar.lnkUom.LinkClicked += LnkUom_LinkClicked;
            _sidebar.lnkUsers.LinkClicked += LnkUsers_LinkClicked;
            _sidebar.lnkReferences.LinkClicked += LnkReferences_LinkClicked;
           // _sidebar.lnkProfile.LinkClicked += LnkProfile_LinkClicked;

            _sidebar.lnkWarehouses.LinkClicked += LnkWarehouses_LinkClicked;
            _sidebar.lnkSuppliers.LinkClicked += LnkSuppliers_LinkClicked;
        }

        private void SelectGeneralLink()
        {
            LnkGeneral_LinkClicked(_sidebar.lnkGeneral, null);
        }

        private void LnkGeneral_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<ProfileUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(uc);
            // set selection
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Profile";
        }

        //private void LnkProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    var userListUC = Program.container.GetInstance<CompanySettingsUC>();
        //    _body.pnlBody.Controls.Clear();
        //    _body.pnlBody.Controls.Add(userListUC);
        //    // set selection
        //    _sidebar.SetVisited(sender);
        //    _body.SubHeadingText = "Profile";
        //}

        private void LnkReferences_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<ReferenceSettingsUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(uc);
            // set selection
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Reference Settings";
        }

        private void LnkUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var userListUC = Program.container.GetInstance<SupplierListUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(userListUC);
            // set selection
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Users";
        }

        private void LnkUom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<UomListUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(uc);
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Units of Measure (UOM)";
        }


        private void LnkProductCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<CategoryListUC>();
           _body. pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(uc);
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Product Categories";
        }

        private void LnkPackages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<PackageUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(uc);
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Package Types";
        }

        private void LnkAdjustmentCodes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<AdjustmentCodeUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(uc);
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Adjustment Codes";
        }



        private void LnkWarehouses_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<WarehouseUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(uc);
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Warehouses";
        }

        private void LnkSuppliers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<SupplierUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(uc);
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Suppliers";
        }

        #region Event Handlers

        #endregion


    }
}
