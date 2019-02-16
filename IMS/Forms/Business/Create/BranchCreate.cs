using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Business;
using ViewModel.Core.Business;

namespace IMS.Forms.Business.Create
{
    public partial class BranchCreate : Form
    {
        private readonly IBusinessService businessService;
        public BranchCreate(IBusinessService businessService)
        {
            this.businessService = businessService;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(tbBranchName.Text == "")
            {
                tbBranchName.BackColor = Color.LightPink;
                return;
            }
            var branchModel = new BranchModel
            {
                Name = tbBranchName.Text
            };
            businessService.AddOrUpdateBranch(branchModel);
            this.Close();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
