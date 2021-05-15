using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Enums;

namespace IMS.Forms.Common
{
    public class ComboUpdateOnDatabaseChange
    {
        public void SetDoubleClickAndUpdate(Label label, CreateFormTypeEnum formType)
        {
            label.Font = new System.Drawing.Font(label.Font, System.Drawing.FontStyle.Underline);
            label.Tag = formType.ToString();
            label.DoubleClick += Label_DoubleClick;
            //_listener.PackageUpdated += _listener_PackageUpdated;
        }

        private void Label_DoubleClick(object sender, EventArgs e)
        {
            CreateFormTypeEnum createFormTypeEnum;
            if(Enum.TryParse( (sender as Label).Tag.ToString(), out createFormTypeEnum))
            {
                switch (createFormTypeEnum)
                {
                    case CreateFormTypeEnum.Package:

                        break;
                }
            }

        }
    }
}
