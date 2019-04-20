using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Common.Display
{
    public class LabelSubHeader:Label
    {
        private String text = "";

        public String LabelText
        {
            get { return text; }
            set { text = value; Invalidate(); }
        }

        public LabelSubHeader()
        {
            text = this.Text;
        }
    }
}
