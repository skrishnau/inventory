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
            // clear first
            foreach (LinkLabel linkLabel in pnlLinks.Controls)
            {
                linkLabel.LinkVisited = false;
            }
            // set second
            var link = sender as LinkLabel;
            if (link != null)
            {
                link.LinkVisited = true;
            }
        }
    }
}
