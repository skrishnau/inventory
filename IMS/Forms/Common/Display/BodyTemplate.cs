using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Common.Display
{
    public partial class BodyTemplate : UserControl
    {
        public BodyTemplate()
        {
            InitializeComponent();
        }
        
        private void btnShowHideMenuBar_Click(object sender, EventArgs e)
        {
            ShowHideMenuBar();
        }

        private void ShowHideMenuBar()
        {
            pnlMenuBarBackground.Visible = !pnlMenuBar.Visible;
            var isShownNow = pnlMenuBarBackground.Visible;
            // show the ShowButton if menu bar is hidden; else hide;
            btnShowMenuBar.Visible = !isShownNow;

        }
    }



}
