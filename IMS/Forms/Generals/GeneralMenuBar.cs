using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Generals
{
    public partial class GeneralMenuBar : UserControl
    {
        public GeneralMenuBar()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public void ClearSelection()
        {
          
           // btnAttributeList.FlatStyle = FlatStyle.Standard;
            btnBranchList.FlatStyle = FlatStyle.Standard;
        }
    }
}
