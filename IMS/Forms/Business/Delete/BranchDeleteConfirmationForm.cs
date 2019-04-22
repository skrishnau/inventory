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

namespace IMS.Forms.Business.Delete
{
    public partial class BranchDeleteConfirmationForm : Form
    {
        public IBusinessService businessService;
        public BranchModel model;
 
        public BranchDeleteConfirmationForm(IBusinessService businessService, BranchModel model)
        {
            this.businessService = businessService;
            this.model = model;
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //businessService.DeleteBranch(model.Id);
            //MessageBox.Show("Branch Deleted!!!");
            //this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void SetData(BranchModel branch)
        {
            tbBranchName.Text = branch.Name;
        }
    }
}
