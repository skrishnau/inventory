using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Inventory.Settings
{
    public partial class InventorySettingsSidebarUC : UserControl
    {
        public InventorySettingsSidebarUC()
        {
            InitializeComponent();
        }


        public void SetVisited(object sender)
        {
            var regularFont = new Font(lnkGeneral.Font, FontStyle.Regular);
            var boldFont = new Font(lnkGeneral.Font, FontStyle.Bold);
            // clear first
            foreach (Control control in pnlLinks.Controls)
            {
                var linkLabel = control as LinkLabel;
                if (linkLabel != null)
                {
                    linkLabel.LinkVisited = false;
                    linkLabel.Font = regularFont;
                }
            }
            // set second
            var link = sender as LinkLabel;
            if (link != null)
            {
                link.LinkVisited = true;
                link.Font = boldFont;
            }
        }
    }
}
