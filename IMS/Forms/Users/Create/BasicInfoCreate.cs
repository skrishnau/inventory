using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Core.Users;
using ViewModel.Core.Users;

namespace IMS.Forms.Users.Create
{
    public partial class BasicInfoCreate : Form
    {
        private readonly IUserService userService;
        private int basicInfoId;
        public BasicInfoCreate(IUserService userService)
        {
            this.userService = userService;
            InitializeComponent();
            
        }

        public void SetData(BasicInfoModel basicInfoModel)
        {
            basicInfoId = basicInfoModel.Id;
            tbAddress.Text = basicInfoModel.Address;
            tbDOB.Text = basicInfoModel.DOB.ToString();
            tbEmail.Text = basicInfoModel.Email;
            tbName.Text = basicInfoModel.Name;
            tbPhone.Text = basicInfoModel.Phone;
            cbGender.Text = basicInfoModel.Gender;
            cbIsMarried.Text = basicInfoModel.IsMarried.ToString();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = new BasicInfoModel
            {
                //DOB = DateTime.Parse(tbDOB.Text),
                DOB = DateTime.Now,
                Address = tbAddress.Text,
                Email = tbEmail.Text,
                Gender = cbGender.Text,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsCompany = cbIsCompany.Checked,
                IsMarried = false,
                Name = tbName.Text,
                Phone = tbPhone.Text,
                Id = basicInfoId
            };
            userService.AddOrUpdateBasicInfo(model);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
