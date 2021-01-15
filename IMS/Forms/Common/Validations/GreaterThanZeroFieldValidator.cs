using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Common.Validations
{
    public class GreaterThanZeroFieldValidator
    {
        public static readonly string REQUIRED = "Required";
        private readonly ErrorProvider _errorProvider;

        private readonly List<Control> _requiredControls;

        public GreaterThanZeroFieldValidator(ErrorProvider errorProvider, Control[] controls)
        {
            _errorProvider = errorProvider;
            _requiredControls = controls.ToList();

            // set validating event
            if (controls != null)
            {
                foreach (var control in controls)
                {
                    control.Validating += GreaterThanZeroField_Validating;
                }
            }
        }

        public void Remove(Control control)
        {
            var cnt = this._requiredControls.Contains(control);
            if (cnt)
                _requiredControls.Remove(control);
        }
        public void AddIfNotExists(Control control)
        {
            var cnt = this._requiredControls.Contains(control);
            if (!cnt)
            {
                _requiredControls.Add(control);
                control.Validating += GreaterThanZeroField_Validating;
            }
        }

        public bool Validate()
        {
            var allValid = true;
            if (_requiredControls != null)
            {
                foreach (var control in _requiredControls)
                {
                    if (!Validate(control))
                        allValid = false;
                }
            }
            return allValid;
        }

        public bool IsValid()
        {
            return Validate();
        }

        private void GreaterThanZeroField_Validating(object sender, CancelEventArgs e)
        {
            Validate(sender);
        }

        private bool Validate(object sender)
        {
            var control = sender as Control;
            var text = control.Text;
            decimal value = 0;
            decimal.TryParse(text, out value);
            if(value <= 0)
            {
                _errorProvider.SetError(control, REQUIRED);
                return false;
            }
            _errorProvider.SetError(control, string.Empty);
            return true;
        }
    }
}
