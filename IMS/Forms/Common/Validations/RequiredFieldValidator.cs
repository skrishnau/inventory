using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Common;

namespace IMS.Forms.Common.Validations
{
    public class RequiredFieldValidator
    {
        public static readonly string REQUIRED = "Required";
        private readonly ErrorProvider _errorProvider;

        private Control[] _requiredControls;

        public RequiredFieldValidator(ErrorProvider errorProvider, Control[] requiredControls)
        {
            _errorProvider = errorProvider;
            _requiredControls = requiredControls;

            // set validating event
            if (requiredControls != null)
                foreach (var control in _requiredControls)
                {
                    control.Validating += RequiredField_Validating;
                }

        }


        #region Validate Actions

        public bool Validate()
        {
            var allValid = true;
            if (_requiredControls != null)
                foreach (var control in _requiredControls)
                {
                    if (!Validate(control))
                        allValid = false;

                }
            return allValid;
        }


        #endregion

        #region Getters

        public bool IsValid()
        {
            return Validate();
            //foreach (var control in _requiredControls)
            //{
            //    if (!string.IsNullOrEmpty(_errorProvider.GetError(control)))
            //    {
            //        return false;
            //    }
            //}
            //// check other form of validation also...
            //return true;
        }

        #endregion


        #region Events

        private void RequiredField_Validating(object sender, CancelEventArgs e)
        {
            Validate(sender);

        }

        #endregion

        #region Required Field Validtions

        private bool Validate(object sender)
        {
            var type = sender.GetType();
            if (type == typeof(TextBox))
            {
                return ValidateTextBoxRequired((TextBox)sender);
            }
            else if (type == typeof(ComboBox))
            {
                return ValidateComboBoxRequired((ComboBox)sender);
            }
            else if (type == typeof(MaskedTextBox))
            {
                return ValidateMaskedTextBoxRequired((MaskedTextBox)sender);
            }
            return false;
        }

        private bool ValidateTextBoxRequired(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                _errorProvider.SetError(textBox, REQUIRED);
                return false;
            }
            _errorProvider.SetError(textBox, string.Empty);
            return true;
        }

        private bool ValidateMaskedTextBoxRequired(MaskedTextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                _errorProvider.SetError(textBox, REQUIRED);
                return false;
            }
            _errorProvider.SetError(textBox, string.Empty);
            return true;
        }

        private bool ValidateComboBoxRequired(ComboBox comboBox)
        {
            //if(string.IsNullOrEmpty(comboBox.SelectedText))
            var item = comboBox.SelectedItem;
            if (item == null)
            {
                _errorProvider.SetError(comboBox, REQUIRED);
                return false;
            }
            else
            {
                var idName = item as IdNamePair;
                if (idName != null && idName.Id == 0)
                {
                    _errorProvider.SetError(comboBox, REQUIRED);
                    return false;
                }
            }
            _errorProvider.SetError(comboBox, string.Empty);
            return true;
        }

        #endregion





    }
}
