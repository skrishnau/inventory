using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.POS
{
    public partial class PosMenuBar : UserControl
    {
        public PosMenuBar()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
        }

        internal void ClearSelection()
        {
            btnOrderList.FlatStyle = FlatStyle.Standard;
            btnCustomerList.FlatStyle = FlatStyle.Standard;
        }
    }
}
