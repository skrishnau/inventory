using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Inventory.Dashboard
{
    public partial class DashboardUC : UserControl
    {
        public DashboardUC()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            InitializeBody();
        }

        private void InitializeBody()
        {
            this.headerTemplate1.Text = "Dashboard";
        }
    }
}
