using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Create.UC
{
    public partial class AddProductUC : UserControl
    {


        public AddProductUC()
        {
            InitializeComponent();

            InitializeListeners();
        }

        private void InitializeListeners()
        {
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
