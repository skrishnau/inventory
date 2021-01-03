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
    public partial class HeaderTemplate : UserControl
    {

        public HeaderTemplate()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
        }

       public override string Text { get { return lblHeading.Text; } set { lblHeading.Text = value; } }

        // get instance from this property only
        public static HeaderTemplate Instance
        {
            get
            {
                return new HeaderTemplate();
            }
        }
        public string Text1 { set { lblHeading.Text = value; } }
    }
}
