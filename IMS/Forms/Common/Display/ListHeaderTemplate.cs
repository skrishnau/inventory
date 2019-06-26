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
    public partial class ListHeaderTemplate : UserControl
    {
        public ListHeaderTemplate()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
        }

        public override string Text { get { return lblText.Text; } set { lblText.Text = value; } }

        public string HeadingText{ get { return lblText.Text; } set { lblText.Text = value; } }


    }
}
