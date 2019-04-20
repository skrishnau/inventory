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
    public partial class SubBodyTemplate : UserControl
    {
        public SubBodyTemplate()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public string HeadingText { get { return heading.Text; } set { heading.Text = value; } }
        public string SubHeadingText { get { return subHeading.Text; } set { subHeading.Text = value; } }

        //public void SetVisited(object sender)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
