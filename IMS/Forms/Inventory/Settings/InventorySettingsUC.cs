﻿using System;
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
using IMS.Forms.Common;

namespace IMS.Forms.Inventory.Settings
{
    public partial class InventorySettingsUC : BaseUserControl
    {
        //private SettingsBodyTemplate _body;

        private readonly InventorySettingsSidebarUC _sidebar;

        BaseUserControl _currentTab;

        public InventorySettingsUC(InventorySettingsSidebarUC sidebar)
        {
            _sidebar = sidebar;

            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += InventorySettingsUC_Load;

        }
        public override void ExecuteActions()
        {
            if (_currentTab != null)
            {
                _currentTab.ExecuteActions();
            }
        }

        private void InventorySettingsUC_Load(object sender, EventArgs e)
        {

            InitializeBody();

            SelectGeneralLink();

            InitializeEvents();
        }

        private void InitializeBody()
        {
            _body.HeadingText = "Settings";
            _body.SubHeadingText = "";
            _body.pnlBody.BackColor = System.Drawing.SystemColors.ControlLightLight;
            _body.pnlSideBar.Controls.Add(_sidebar);
        }

        private void InitializeEvents()
        {
            _sidebar.lnkProfile.LinkClicked += LnkProfile_LinkClicked;
            _sidebar.lnkAdjustmentCodes.LinkClicked += LnkAdjustmentCodes_LinkClicked;
            _sidebar.lnkPackages.LinkClicked += LnkPackages_LinkClicked;
            _sidebar.lnkProductCategory.LinkClicked += LnkProductCategory_LinkClicked;
            _sidebar.lnkUom.LinkClicked += LnkUom_LinkClicked;
            _sidebar.lnkUsers.LinkClicked += LnkUsers_LinkClicked;
            _sidebar.lnkReferences.LinkClicked += LnkReferences_LinkClicked;
            // _sidebar.lnkProfile.LinkClicked += LnkProfile_LinkClicked;

            _sidebar.lnkWarehouses.LinkClicked += LnkWarehouses_LinkClicked;
            _sidebar.lnkPreferences.LinkClicked += LnkPreferences_LinkClicked;
        }

        private void LnkPreferences_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<PreferenceSettingsUC>();
            uc.SetViewMode(false);
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(uc);
            // set selection
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "General";
            uc.MyTabTitle = MyTabTitle;
            uc.MySubTabTitle = _body.SubHeadingText;
            InventoryUC.CurrentSubTabTitle = _body.SubHeadingText;
            _currentTab = uc;
            _currentTab.ExecuteActions();
        }

        private void SelectGeneralLink()
        {
            LnkProfile_LinkClicked(_sidebar.lnkProfile, null);
        }

        private void LnkProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<ProfileUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(uc);
            // set selection
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Profile";

            uc.MyTabTitle = MyTabTitle;
            uc.MySubTabTitle = _body.SubHeadingText;
            InventoryUC.CurrentSubTabTitle = _body.SubHeadingText;
            _currentTab = uc;
            _currentTab.ExecuteActions();
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
            var uc = Program.container.GetInstance<ReferenceListUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(uc);
            // set selection
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Reference Settings";
            uc.MyTabTitle = MyTabTitle;
            uc.MySubTabTitle = _body.SubHeadingText;
            InventoryUC.CurrentSubTabTitle = _body.SubHeadingText;
            _currentTab = uc;
            _currentTab.ExecuteActions();
        }

        private void LnkUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var userListUC = Program.container.GetInstance<ClientListUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(userListUC);
            // set selection
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Users";
            userListUC.MyTabTitle = MyTabTitle;
            userListUC.MySubTabTitle = _body.SubHeadingText;
            InventoryUC.CurrentSubTabTitle = _body.SubHeadingText;
            _currentTab = userListUC;
            _currentTab.ExecuteActions();
        }

        private void LnkUom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<UomListUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(uc);
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Units of Measure (UOM)";
            uc.MyTabTitle = MyTabTitle;
            uc.MySubTabTitle = _body.SubHeadingText;
            InventoryUC.CurrentSubTabTitle = _body.SubHeadingText;
            _currentTab = uc;
            _currentTab.ExecuteActions();
        }


        private void LnkProductCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<CategoryListUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(uc);
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Product Categories";
            uc.MyTabTitle = MyTabTitle;
            uc.MySubTabTitle = _body.SubHeadingText;
            InventoryUC.CurrentSubTabTitle = _body.SubHeadingText;
            _currentTab = uc;
            _currentTab.ExecuteActions();
        }

        private void LnkPackages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<PackageListUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(uc);
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Package Types";
            uc.MyTabTitle = MyTabTitle;
            uc.MySubTabTitle = _body.SubHeadingText;
            InventoryUC.CurrentSubTabTitle = _body.SubHeadingText;
            _currentTab = uc;
            _currentTab.ExecuteActions();
        }

        private void LnkAdjustmentCodes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<AdjustmentCodeUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(uc);
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Adjustment Codes";
            uc.MyTabTitle = MyTabTitle;
            uc.MySubTabTitle = _body.SubHeadingText;
            InventoryUC.CurrentSubTabTitle = _body.SubHeadingText;
            _currentTab = uc;
            _currentTab.ExecuteActions();
        }



        private void LnkWarehouses_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<WarehouseUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(uc);
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Warehouses";
            uc.MyTabTitle = MyTabTitle;
            uc.MySubTabTitle = _body.SubHeadingText;
            InventoryUC.CurrentSubTabTitle = _body.SubHeadingText;
            _currentTab = uc;
            _currentTab.ExecuteActions();
        }


    }
}
