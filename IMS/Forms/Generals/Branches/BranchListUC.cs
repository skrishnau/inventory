﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Common.Display;
using IMS.Forms.Business.Create;
using SimpleInjector.Lifestyles;
using Service.Core.Business;

namespace IMS.Forms.Generals.Branches
{
    public partial class BranchListUC : UserControl
    {
        private readonly IBusinessService _businessService;
        public BranchListUC(IBusinessService businessService)
        {
            _businessService = businessService;
            InitializeComponent();

            InitializeHeader();
        }

        private void InitializeHeader()
        {
            var _header = SubHeadingTemplate.Instance;
            _header.btnNew.Visible = true;
            _header.btnNew.Click += BtnNew_Click;
            _header.btnEdit.Visible = true;
            _header.btnEdit.Click += BtnEdit_Click;
            _header.btnDelete.Visible = true;
            _header.btnDelete.Click += BtnDelete_Click;
            // add
            this.Controls.Add(_header);
            _header.SendToBack();
            // heading
            _header.lblHeading.Text = "Branches";

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var branchCreate = Program.container.GetInstance<BranchCreate>();
                branchCreate.ShowDialog();
                PopulateBranchData();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void PopulateBranchData()
        {
            gvBranch.AutoGenerateColumns = false;
            var branchs = _businessService.GetBranchList();
            gvBranch.DataSource = branchs;
        }

    }
}
