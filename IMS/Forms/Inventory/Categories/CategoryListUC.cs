﻿using System;
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
using Service.Interfaces;

namespace IMS.Forms.Inventory.Categories
{
    public partial class CategoryListUC : UserControl
    {
        private readonly IProductService _productService;
        //private TreeViewCategory treeView;

        public CategoryListUC(IProductService inventoryService)
        {
            this._productService = inventoryService;

            InitializeComponent();
            
            this.Dock = DockStyle.Fill;
            this.Load += CategoryListUC_Load;
        }

        private void CategoryListUC_Load(object sender, EventArgs e)
        {
            InitializeHeader();
            InitializeEvents();
            PopulateCategoryData();
        }

        private void InitializeHeader()
        {
            //var _header = HeaderTemplate.Instance;
            //_header.btnNew.Visible = true;
            btnNew.Click += BtnAddCategory_Click;
            //this.Controls.Add(_header);
            //_header.SendToBack();
            //// header text
            //_header.lblHeading.Text = "Categories";

        }

        private void InitializeEvents()
        {
            treeView.NodeCreateSubClick += TreeView_NodeCreateSubClick;
            treeView.NodeEditClick += TreeView_NodeEditClick;
            treeView.NodeDeleteClick += TreeView_NodeDeleteClick;

            treeView.AfterCollapse += TreeView_AfterCollapse;
        }

       

        private void TreeView_NodeCreateSubClick(CategoryModel categoryModel)
        {
            var categoryCreate = Program.container.GetInstance<CategoryCreate>();
            categoryCreate.SetData(CategoryUpdateType.ADD_SUBCATEGORY, categoryModel); // this node will be parent node
            categoryCreate.ShowDialog();
            PopulateCategoryData();
        }

        private void TreeView_NodeEditClick(CategoryModel categoryModel)
        {
            var categoryCreate = Program.container.GetInstance<CategoryCreate>();
            categoryCreate.SetData(CategoryUpdateType.EDIT_CATEGORY, categoryModel);
            categoryCreate.ShowDialog();
            PopulateCategoryData();
        }

        private void TreeView_NodeDeleteClick(CategoryModel categoryModel)
        {
            var dialogResult = MessageBox.Show(this, "Are you sure to delete '" + categoryModel.Name + "'?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // delete
                _productService.DeleteCategory(categoryModel);
                PopulateCategoryData();
            }
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var categoryCreate = Program.container.GetInstance<CategoryCreate>();
                categoryCreate.ShowInTaskbar = false;
                categoryCreate.ShowDialog();
                PopulateCategoryData();
            }
        }
        private void TreeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            treeView.HideUC();
        }

        private void PopulateCategoryData()
        {
            // hide the edit control panel if visible
            //treeView.HideUC();

            var categories = _productService.GetCategoryList(null);

            treeView.Nodes.Clear();

            treeView.Nodes.AddRange(GetTreeNodes(categories));
            treeView.ExpandAll();
        }

        private TreeNodeCategory[] GetTreeNodes(List<CategoryModel> categories)
        {
            TreeNodeCategory[] nodes = new TreeNodeCategory[categories.Count];
            for (var c = 0; c < categories.Count; c++)// cat in categories)
            {
                var node = new TreeNodeCategory
                {
                    Text = categories[c].Name,
                    //Name = "category-" + cat.Name + "-" + cat.Id,
                    Tag = categories[c],
                };
                if (categories[c].SuCategories.Any())
                    node.Nodes.AddRange(GetTreeNodes(categories[c].SuCategories));
                nodes[c] = node;
            }
            return nodes;
        }

       
    }
}
