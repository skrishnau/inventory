using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Common.Base
{
    public class BaseDialogForm : Form
    {
        public BaseDialogForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
        }
        
    }
}
