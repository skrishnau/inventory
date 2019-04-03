using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.UserManagement
{
    public partial class UserManagementMenuBar : UserControl
    {
        public UserManagementMenuBar()
        {
            InitializeComponent();
        }

        public void ClearSelection()
        {
            btnUserList.FlatStyle = FlatStyle.Standard;
            btnRoleList.FlatStyle = FlatStyle.Standard;
        }
    }
}
