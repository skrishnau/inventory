using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core;

namespace IMS.Forms.MRP
{
    public partial class ManufactureViewUC : UserControl
    {
        private ManufactureModel _model;
        public ManufactureViewUC()
        {
            InitializeComponent();
            this.Load += ManufactureViewUC_Load;
        }

        private void SetData(ManufactureModel model)
        {
            _model = model;
        }

        private void ManufactureViewUC_Load(object sender, EventArgs e)
        {
            PopulateData();
        }

        private void PopulateData()
        {

        }
    }
}
