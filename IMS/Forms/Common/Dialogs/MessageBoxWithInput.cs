using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Common.Dialogs
{
    public partial class MessageBoxWithInput : Form
    {
        public event EventHandler<StringEventArgs> DoneClicked;

        public MessageBoxWithInput()
        {
            InitializeComponent();
            this.Load += MessageBoxWithInput_Load;
        }

        private void MessageBoxWithInput_Load(object sender, EventArgs e)
        {
            this.ActiveControl = tbInput;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbInput.Text))
                return;
            var args = new StringEventArgs()
            {
                Input = tbInput.Text,
            };
            DoneClicked?.Invoke(this, args);
            this.Close();
        }
    }

    public class StringEventArgs : EventArgs
    {
        public string Input { get; set; }
    }
}
