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
    public partial class DepartmentSequenceItemUC : UserControl
    {
        public DepartmentSequenceItemUC()
        {
            InitializeComponent();
        }

        internal void SetData(ManufactureDepartmentModel dep)
        {
            lblName.Text = dep.Name;
            //lblManufacturedCount
        }
    }
}
