using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Common
{
    public partial class ComboWithLabelUC : UserControl
    {
        // Id in case of edit
        public int Id { get; set; }


        public ComboWithLabelUC()
        {
            InitializeComponent();
        }
    }
}
