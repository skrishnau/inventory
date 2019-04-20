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

namespace IMS.Forms.Inventory.Settings
{
    public partial class InventorySettingsUC : UserControl
    {
        public InventorySettingsUC()
        {
            InitializeComponent();

            heading.Text = "Settings";
            subHeading.Text = "";

            InitializeEvents();
        }

        private void InitializeEvents()
        {
            lnkAdjustmentCodes.LinkClicked += LnkAdjustmentCodes_LinkClicked;
            lnkPackages.LinkClicked += LnkPackages_LinkClicked;
            lnkProductCategory.LinkClicked += LnkProductCategory_LinkClicked;
            lnkUom.LinkClicked += LnkUom_LinkClicked;
        }

        private void LnkUom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<UomUC>();
            pnlBody.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(uc);
            SetSelection(sender);
            subHeading.Text = "Units of Measure (UOM)";
        }


        private void LnkProductCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<CategoryListUC>();
            pnlBody.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(uc);
            SetSelection(sender);
            subHeading.Text = "Product Categories";
        }

        private void LnkPackages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<PackageUC>();
            pnlBody.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(uc);
            SetSelection(sender);
            subHeading.Text = "Package Types";
        }

        private void LnkAdjustmentCodes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var uc = Program.container.GetInstance<AdjustmentCodeUC>();
            pnlBody.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(uc);
            SetSelection(sender);
            subHeading.Text = "Adjustment Codes";
        }

        private void SetSelection(object sender)
        {
            // clear first
            foreach(LinkLabel linkLabel in pnlLinks.Controls)
            {
                linkLabel.LinkVisited = false;
            }
            // set second
            var link = sender as LinkLabel;
            if (link != null)
            {
                link.LinkVisited = true;
            }
        }

        #region Event Handlers

        #endregion


    }
}
