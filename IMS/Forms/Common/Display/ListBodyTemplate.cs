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
    public partial class ListBodyTemplate : UserControl
    {
        public ListBodyTemplate()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public string HeadingText { get { return headingControl.Text; } set { headingControl.Text = value; } }
        public bool HeadingVisible { get { return headingControl.Visible; } set { headingControl.Visible = value; } }
        

        

        //  public string SubHeadingText { get { return subHeading.Text; } set { subHeading.Text = value; } }
        // public bool SubHeadingVisible { get { return subHeading.Visible; } set { subHeading.Visible = value; } }

        //public void SetVisited(object sender)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
