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
using SimpleInjector.Lifestyles;
using IMS.Forms.Inventory.Create;
using IMS.Forms.Common.Display;

namespace IMS.Forms.Inventory.Attributes
{
    public partial class AttributeListUC : UserControl
    {
        private readonly IInventoryService inventoryService;

        private SubHeadingTemplate _header;
        public AttributeListUC(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;

            InitializeComponent();

            InitializeHeader();

            dgvAttributeList.CellDoubleClick += DgvAttributeList_CellDoubleClick;
            dgvAttributeList.CellMouseDown += dgvAttributeList_MouseClick;
            //dgvAttributeList.
            PopulateAttributetData();
        }

        private void InitializeHeader()
        {
            _header = SubHeadingTemplate.Instance;
            _header.btnNew.Visible = true;
            _header.btnNew.Click += BtnAdd_Click;
            _header.btnEdit.Visible = true;
            _header.btnEdit.Click += btnEdit_Click;
            _header.btnDelete.Visible = true;
            _header.btnDelete.Click += BtnDelete_Click;
            this.Controls.Add(_header);
            _header.SendToBack();
            // header text
            _header.lblHeading.Text = "Attributes";
        }




        void PopulateAttributetData()
        {
            dgvAttributeList.AutoGenerateColumns = false;
            var attributes = inventoryService.GetAttributeList();
            dgvAttributeList.DataSource = attributes;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ShowAddEditDialog(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowAddEditDialog(true);
        }

        private void ShowAddEditDialog(bool isEditMode)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var attributeCreate = Program.container.GetInstance<AttributeCreate>();
                attributeCreate.ShowInTaskbar = false;
                // if isEditMode then get the data from gridview
                if (isEditMode && (dgvAttributeList.SelectedRows != null && dgvAttributeList.SelectedRows.Count > 0))
                {
                    var attribute = (AttributeModel)dgvAttributeList.SelectedRows[0].DataBoundItem;
                    attributeCreate.SetData(attribute);
                }
                attributeCreate.ShowDialog();
                PopulateAttributetData();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAttributeList.SelectedRows != null && dgvAttributeList.SelectedRows.Count > 0)
            {
                var attribute = (ViewModel.Core.Inventory.AttributeModel)dgvAttributeList.SelectedRows[0].DataBoundItem;
                inventoryService.DeleteAttribute(attribute);
                PopulateAttributetData();
            }
        }

        // Mouse right click event handler for datagridview
        private void dgvAttributeList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu menu = new ContextMenu();
                menu.MenuItems.Add(new MenuItem("Edit"));
                menu.MenuItems.Add(new MenuItem("Delete"));

                int currentMouseOverRow = dgvAttributeList.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {

                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: set the selection first, cause the row on which right-click was done isn't selected yet..
            ShowAddEditDialog(true);
        }

        private void DgvAttributeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowAddEditDialog(true);
        }

    }
}
