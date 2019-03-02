using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Inventory;
using System.Threading;

namespace IMS.Forms.Inventory.Attributes
{
    public partial class OptionViewUC : UserControl
    {
        public event EventHandler<EventArgs> OnRemoveClicked;

        public OptionModel OptionModel{ get; set; }
        

        public OptionViewUC(OptionModel option)
        {
            InitializeComponent();

            this.OptionModel = option;
            this.lblOption.Text = option.Name;
            this.lblValues.Text = ""; // clear the text first
            for (int i = 0; i < option.OptionValues.Count; i++)
            {
                this.lblValues.Text += option.OptionValues[i].Value;
                if (i < option.OptionValues.Count - 2)
                    this.lblValues.Text += ", ";
                if (i == option.OptionValues.Count - 2)
                    this.lblValues.Text += " & ";
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.Height -= (int)(this.Size.Height * .2);
            this.Width -= (int)(this.Size.Width * .2);
            Thread.Sleep(40);
            this.Height -= (int)(this.Size.Height * .2);
            this.Width -= (int)(this.Size.Width * .2);
            Thread.Sleep(40);
            this.Height -= (int)(this.Size.Height * .2);
            this.Width -= (int)(this.Size.Width * .2);
            Thread.Sleep(40);
            this.Height -= (int)(this.Size.Height * .2);
            this.Width -= (int)(this.Size.Width * .2);
            Thread.Sleep(40);

            OnRemoveClicked(this, e);
        }
    }
}
