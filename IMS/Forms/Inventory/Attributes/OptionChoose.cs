using IMS.Forms.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Inventory;

namespace IMS.Forms.Inventory.Attributes
{
    public partial class OptionChoose : Form
    {
        public event EventHandler<OptionChooseEventArgs> OptionSelected;

        private List<OptionModel> _optionsList;
        public List<OptionModel> DataSource
        {
            get { return _optionsList; }
            internal set
            {
                _optionsList = value;
                cbOptions.ValueMember = "Id";
                cbOptions.DisplayMember = "Name";
                cbOptions.DataSource = value;
            }
        }

        public OptionChoose()
        {
            InitializeComponent();
        }

        private void cbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the selected Option
            var selected = (OptionModel)cbOptions.SelectedItem;
            if (selected != null)
            {
                chkListBoxOptionValues.Items.Clear();
                chkListBoxOptionValues.Items.AddRange(selected.OptionValues.Select(x => x.Value).ToArray());
            }
            //var items = new ListBox.ObjectCollection(chkListBoxOptionValues);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            var selectedOption = (OptionModel)cbOptions.SelectedItem;
            var selectedOptionValues = new List<OptionValueModel>();
            foreach (var chkItem in chkListBoxOptionValues.CheckedItems)
            {
                var chkValueModel = selectedOption.OptionValues.FirstOrDefault(x => x.Value == chkItem.ToString());
                if (chkValueModel != null)
                {
                    selectedOptionValues.Add(chkValueModel);
                }
            }
            if (!selectedOptionValues.Any())
            {
                // show error message here
                PopupMessage.ShowPopupMessage("Not any Values", "You haven't selected any value for " + selectedOption.Name, PopupMessageType.INFO);
                this.Focus();
                return;
            }
            var eventArgs = new OptionChooseEventArgs()
            {
                // here create new OptionModel such that the original object is not affected on assigned only the checked values
                Option = new OptionModel()
                {
                    Name = selectedOption.Name,
                    OptionValues = selectedOptionValues
                },
            };
            OptionSelected(this, eventArgs);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    /// <summary>
    /// Selected Option in Option Choose form ; 
    /// OptionValues has all the checked Options only.
    /// </summary>
    public class OptionChooseEventArgs : EventArgs
    {
        public OptionModel Option { get; set; }
    }
}
