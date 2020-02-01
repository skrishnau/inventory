using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Inventory.Units
{
    public partial class InventoryUnitsMenu : UserControl
    {
        public InventoryUnitsMenu()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public void SetVisited(object sender)
        {
            foreach (Control lnk in pnlBody.Controls)
            {
                var linkLabel = lnk as LinkLabel;
                if (linkLabel != null)
                {
                    // clear selection
                    linkLabel.LinkVisited = false;
                    lnk.BackColor = Color.Gainsboro;
                }
            }
            foreach (LinkLabel lnk in pnlLinkList.Controls)
            {
                // clear selection
                lnk.LinkVisited = false;
                lnk.BackColor = Color.Gainsboro;
            }
            var link = sender as LinkLabel;
            if (link != null)
            {
                // set selection
                link.LinkVisited = true;
                link.BackColor = System.Drawing.SystemColors.Control;
            }
        }
    }
}
