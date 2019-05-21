using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Production
{
    public partial class ProductionMenuBar : UserControl
    {
        public ProductionMenuBar()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public void SetSelection(object sender)
        {
            ClearSelectionInside(this.Controls);

            if (sender.GetType() == typeof(Button))
            {
                var btn = sender as Button;
                btn.FlatStyle = FlatStyle.Flat;
            }
        }

        private void ClearSelectionInside(ControlCollection collection)
        {
            foreach (var control in collection)
            {
                var controlType = control.GetType();
                if (controlType == typeof(Button))
                {
                    (control as Button).FlatStyle = FlatStyle.Standard;
                }
                else if (controlType == typeof(GroupBox))
                {
                    ClearSelectionInside((control as GroupBox).Controls);
                }
            }
        }
    }

}
