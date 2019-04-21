using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Inventory.Products
{
    public partial class ProductSidebarUC : UserControl
    {
        public ProductSidebarUC()
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
                    linkLabel.LinkVisited = false;
                }
            }
            foreach (LinkLabel lnk in pnlLinkList.Controls)
            {
                lnk.LinkVisited = false;
            }
            var link = sender as LinkLabel;
            if (link != null)
            {
                link.LinkVisited = true;
            }
        }
    }
}
