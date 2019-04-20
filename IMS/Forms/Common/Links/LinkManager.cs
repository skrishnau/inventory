using Service.DbEventArgs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Common.Links
{
    public class LinkManager
    {
        public event EventHandler<IdEventArgs> LinkClicked;

        private FlowLayoutPanel _panel;
        private ToolTip _toolTip;

        private List<int> _visitedLinkIds = new List<int>();

        public LinkManager(FlowLayoutPanel panel, ToolTip toolTip)
        {
            _panel = panel;
            _toolTip = toolTip;
        }

        public void AddLink(int modelId, string displayText, string toolTipText)//PurchaseOrderModel model)
        {
            LinkLabel link = null;
            var index = _visitedLinkIds.IndexOf(modelId);
            if (index >= 0)
            {
                // exists
                link = _panel.Controls[index] as LinkLabel;
            }
            else
            {
                // doesn't exist
                link = new LinkLabel();
                link.AutoEllipsis = true;
                link.Text = "● " + displayText;//model.OrderNumber;
                link.Tag = modelId;
                link.LinkBehavior = LinkBehavior.HoverUnderline;
                link.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
                link.VisitedLinkColor = Color.Black;// System.Drawing.SystemColors.ControlText;
                _visitedLinkIds.Add(modelId);
                _toolTip.SetToolTip(link, toolTipText);// model.Name);
                _panel.Controls.Add(link);
                link.Click += Link_Click;
            }
            //if (link != null)
            //{
            //    link.BringToFront();
            //}
        }


        public void Link_Click(object sender, EventArgs e)
        {
            var linkLabel = sender as LinkLabel;
            if (linkLabel != null)
            {
                // link's Tag has purchase Order Id 
                var id = int.Parse(linkLabel.Tag == null ? "0" : linkLabel.Tag.ToString());
                var args = new IdEventArgs(id);
                LinkClicked?.Invoke(sender, args);
                //ShowData(id);
            }
        }
    }
}
