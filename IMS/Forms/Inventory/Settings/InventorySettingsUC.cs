using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Inventory.UOM;
using IMS.Forms.Inventory.Packages;
using IMS.Forms.Inventory.Settings.Adjustments;
using IMS.Forms.Inventory.Categories;
using IMS.Forms.Common.Display;
using IMS.Forms.Inventory.Settings.Companies;
using IMS.Forms.Inventory.Settings.References;
using IMS.Forms.Inventory.Settings.Appearance;
using IMS.Forms.Inventory.Users;

namespace IMS.Forms.Inventory.Settings
{
    public partial class InventorySettingsUC : UserControl
    {
        private SubBodyTemplate _body;

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

        }

        private void InitializeBody()
        {
            _body = new SubBodyTemplate
            {
                HeadingText = "Settings",
                SubHeadingText = ""
            };
            this.Controls.Add(_body);
            _body.pnlSideBar.Controls.Add(_sidebar);

        }

        private void InitializeEvents()
        {
            _sidebar.lnkAdjustmentCodes.LinkClicked += LnkAdjustmentCodes_LinkClicked;
            _sidebar.lnkPackages.LinkClicked += LnkPackages_LinkClicked;
            _sidebar.lnkProductCategory.LinkClicked += LnkProductCategory_LinkClicked;
            _sidebar.lnkUom.LinkClicked += LnkUom_LinkClicked;
            _sidebar.lnkUsers.LinkClicked += LnkUsers_LinkClicked;
            _sidebar.lnkReferences.LinkClicked += LnkReferences_LinkClicked;
            _sidebar.lnkProfile.LinkClicked += LnkProfile_LinkClicked;
            _sidebar.lnkAppearance.LinkClicked += LnkAppearance_LinkClicked;
        }

        private void LnkAppearance_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<AppearanceSettingsUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(uc);
            // set selection
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Appearance";
        }

        private void LnkProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var userListUC = Program.container.GetInstance<CompanySettingsUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(userListUC);
            // set selection
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Profile";
        }

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
            var userListUC = Program.container.GetInstance<UserListUC>();
            _body.pnlBody.Controls.Clear();
            _body.pnlBody.Controls.Add(userListUC);
            // set selection
            _sidebar.SetVisited(sender);
            _body.SubHeadingText = "Users";
        }

        private void LnkUom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<UomUC>();
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


        #region Event Handlers

        #endregion


    }
}
