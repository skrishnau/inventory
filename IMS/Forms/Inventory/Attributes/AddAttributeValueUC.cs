using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace IMS.Forms.Inventory.Attributes
{
    public partial class AddAttributeValueUC : UserControl
    {
        public event EventHandler<EventArgs> OnDeleteButtonClicked;
        public AddAttributeValueUC()
        {
            InitializeComponent();
            
        }

        public string InputValue
        {
            get { return cbAttributeValue.Text; }
        }
        // public Panel ParentPanel { get; set; }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Height -= (int)(this.Size.Height * .2);
            this.Width -= (int)(this.Size.Width * .2);
            Thread.Sleep(50);
            this.Height -= (int)(this.Size.Height * .2);
            this.Width -= (int)(this.Size.Width * .2);
            Thread.Sleep(50);
            this.Height -= (int)(this.Size.Height * .2);
            this.Width -= (int)(this.Size.Width * .2);
            Thread.Sleep(50);
            this.Height -= (int)(this.Size.Height * .2);
            this.Width -= (int)(this.Size.Width * .2);
            Thread.Sleep(50);
            //var butn = (Button)sender;
            //fire the event
            if (OnDeleteButtonClicked != null)
                OnDeleteButtonClicked(this, e);
            // ParentPanel.Controls.Remove(this);
        }
    }
}
