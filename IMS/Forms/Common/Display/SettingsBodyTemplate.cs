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
    public partial class SettingsBodyTemplate : UserControl
    {
        public SettingsBodyTemplate()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public string HeadingText { get { return heading.Text; } set { heading.Text = value; } }
        public string SubHeadingText { get { return subHeading.Text; } set { subHeading.Text = value; } }

        public bool HeadingVisible { get { return heading.Visible; } set { heading.Visible = value; } }
        public bool SubHeadingVisible { get { return subHeading.Visible; } set { subHeading.Visible = value; } }
        //public void SetVisited(object sender)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
