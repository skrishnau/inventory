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
    public partial class SubHeadingTemplate : UserControl
    {
        public SubHeadingTemplate()
        {
            InitializeComponent();
        }

        // get instance from this property only
        public static SubHeadingTemplate Instance
        {
            get
            {
                return new SubHeadingTemplate()
                {
                    Dock = DockStyle.Top,
                };
            }
        }
    }
}
