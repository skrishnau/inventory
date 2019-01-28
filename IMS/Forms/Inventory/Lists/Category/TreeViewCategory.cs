using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Inventory;

namespace IMS.Forms.Inventory.Lists.Category
{
    public class TreeViewCategory : TreeView
    {
        public delegate void CategoryEventHandler(CategoryModel categoryModel);

        public event CategoryEventHandler NodeDeleteClick;
        public event CategoryEventHandler NodeEditClick;
        public event CategoryEventHandler NodeCreateSubClick;

        public TreeViewCategory()
            : base()
        {

        }



        private TreeNodeCategory m_CurrentNode = null;

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            ShowUC(e.Node);
            this.SelectedNode = e.Node;
            base.OnNodeMouseClick(e);
        }

        //protected override void OnNodeMouseHover(TreeNodeMouseHoverEventArgs e)
        //{
        //    ShowUC(e.Node);
        //    base.OnNodeMouseHover(e);
        //}

        //protected override void OnAfterSelect(TreeViewEventArgs e)
        //{
        //    ShowUC(e.Node);
        //    base.OnAfterSelect(e);
        //}

        protected override void OnAfterExpand(TreeViewEventArgs e)
        {
            HideUC();
            base.OnAfterExpand(e);
        }

        


        private void ShowUC(TreeNode node)
        {
            // remove previous control
            HideUC();

            if (node is TreeNodeCategory)
            {
                this.m_CurrentNode = (TreeNodeCategory)node;

                // Need to add the node's control to the
                // TreeView's list of controls for it to work
                this.Controls.Add(this.m_CurrentNode.CategoryEditUC);

                // Set the bounds of the ComboBox, with
                // a little adjustment to make it look right
                this.m_CurrentNode.CategoryEditUC.SetBounds(
                    this.m_CurrentNode.Bounds.X + this.m_CurrentNode.Bounds.Width + 10,
                    this.m_CurrentNode.Bounds.Y - 2,
                    this.m_CurrentNode.CategoryEditUC.Bounds.Width,
                    this.m_CurrentNode.CategoryEditUC.Bounds.Height);

                // Listen to the SelectedValueChanged
                // event of the node's Controls
                this.m_CurrentNode.CategoryEditUC.AddSubCategoryClick += CategoryEditUC_AddSubCategoryClick;
                this.m_CurrentNode.CategoryEditUC.EditCategoryClick += CategoryEditUC_EditCategoryClick;
                this.m_CurrentNode.CategoryEditUC.DeleteCategoryClick += CategoryEditUC_DeleteCategoryClick;
                //this.m_CurrentNode.ComboBox.SelectedValueChanged +=
                //   new EventHandler(ComboBox_SelectedValueChanged);
                //this.m_CurrentNode.ComboBox.DropDownClosed +=
                //   new EventHandler(ComboBox_DropDownClosed);

                // Now show the UC
                this.m_CurrentNode.CategoryEditUC.Show();
                //this.m_CurrentNode.CategoryEditUC.DroppedDown = true;
            }
        }
        private void CategoryEditUC_AddSubCategoryClick(object sender, EventArgs e)
        {
            if (this.m_CurrentNode != null)
            {
                var model = (CategoryModel)this.m_CurrentNode.Tag;
                NodeCreateSubClick(model);
            }
        }
        private void CategoryEditUC_EditCategoryClick(object sender, EventArgs e)
        {
            if (this.m_CurrentNode != null)
            {
                var model = (CategoryModel)this.m_CurrentNode.Tag;
                NodeEditClick(model);
            }
        }
        private void CategoryEditUC_DeleteCategoryClick(object sender, EventArgs e)
        {
            if (this.m_CurrentNode != null)
            {
                var model = (CategoryModel)this.m_CurrentNode.Tag;
                NodeDeleteClick(model);
            }
        }

        public void HideUC()
        {
            if (this.m_CurrentNode != null)
            {
                // Unregister the event listener
                this.m_CurrentNode.CategoryEditUC.AddSubCategoryClick -= CategoryEditUC_AddSubCategoryClick;
                this.m_CurrentNode.CategoryEditUC.EditCategoryClick -= CategoryEditUC_EditCategoryClick;
                this.m_CurrentNode.CategoryEditUC.DeleteCategoryClick -= CategoryEditUC_DeleteCategoryClick;
                //this.m_CurrentNode.ComboBox.SelectedValueChanged -=
                //                     ComboBox_SelectedValueChanged;
                //this.m_CurrentNode.ComboBox.DropDownClosed -=
                //                     ComboBox_DropDownClosed;

                // Copy the selected text from the ComboBox to the TreeNode
                // this.m_CurrentNode.Text = this.m_CurrentNode.ComboBox.Text;

                // Hide the ComboBox
                this.m_CurrentNode.CategoryEditUC.Hide();
                //this.m_CurrentNode.ComboBox.DroppedDown = false;

                // Remove the control from the TreeView's
                // list of currently-displayed controls
                this.Controls.Remove(this.m_CurrentNode.CategoryEditUC);

                // And return to the default state (no ComboBox displayed)
                this.m_CurrentNode = null;
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            HideUC();
            base.OnMouseWheel(e);
        }
    }
}
