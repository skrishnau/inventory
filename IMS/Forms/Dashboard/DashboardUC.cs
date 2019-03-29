using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Common.Display;

namespace IMS.Forms.Dashboard
{
    public partial class DashboardUC : UserControl
    {

        BodyTemplate _template;
        DashboardMenuBar _menubar;

        public DashboardUC(DashboardMenuBar menubar)
        {
            _menubar = menubar;

            InitializeComponent();

            InitializeBaseTemplate();
        }

        private void InitializeBaseTemplate()
        {
            // initialize template and add it to the root UC (i.e. "this")
            _template = new BodyTemplate();
            _template.Dock = DockStyle.Fill;
            this.Controls.Add(_template);
            // heading
            _template.lblHeading.Text = "Dashboard";
            // add the menu
            _template.pnlMenuBar.Controls.Add(_menubar);
        }
    }
}
