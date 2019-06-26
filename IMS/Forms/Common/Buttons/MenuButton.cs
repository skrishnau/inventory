using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Common.Buttons
{
    public class MenuButton:Button
    {
        public MenuButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderColor = SystemColors.ControlLight;
            this.FlatAppearance.BorderSize = 1;
            this.ImageAlign = ContentAlignment.MiddleCenter;
            this.Image = Properties.Resources.icons8_Product_16px;
            this.TextImageRelation = TextImageRelation.ImageAboveText;
            this.Width = 60;
            this.Height = 55;
            this.Text = "Button";
        }

    }
}
