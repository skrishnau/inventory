using IMS.Forms.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Inventory.Settings.General
{
    public partial class PreferenceSettingsForm : BaseDialogForm
    {
        public PreferenceSettingsForm()
        {
            InitializeComponent();
            this.Load += GeneralSettingsForm_Load;
        }

        private void GeneralSettingsForm_Load(object sender, EventArgs e)
        {
            var uc = Program.container.GetInstance<PreferenceSettingsUC>();
            this.Controls.Add(uc);
        }
    }
}
