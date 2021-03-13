using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Utility;

namespace IMS.Forms.Common.Date
{
    public class NepaliDateTextBox : TextBox
    {
        NepaliCalendarUC _calendar;
        static DateConverter _dateConverter = new DateConverter();
        // used for handling focus and click at same time
        DateTime _focusedAt;

       // private DateTimePicker picker = new DateTimePicker() { MinDate = DateTime.MinValue };


        public NepaliDateTextBox()
        {
            this.Text = string.Empty;
            //this.Value = DateTime.Now;

            if (_calendar == null)
                _calendar = new NepaliCalendarUC(_dateConverter);

            // this.GotFocus += NepaliDateTextBox_GotFocus;
            this.Enter += NepaliDateTextBox_GotFocus;
            this.LostFocus += NepaliDateTextBox_LostFocus;
            this.Leave += NepaliDateTextBox_LostFocus;
            this.Click += NepaliDateTextBox_Click;
            this.DoubleClick += NepaliDateTextBox_DoubleClick;
            _calendar.CalendarLostFocus += Calendar_CalendarLostFocus;
            _calendar.DateSelected += Calendar_DateSelected;
            //this.Text = _calendar.Value.ToString();

            AddIcon();
            this.KeyPress += NepaliDateTextBox_KeyPress;
            
            //picker.ValueChanged += Picker_ValueChanged;
            //this.Layout += NepaliDateTextBox_Layout;

        }

        private void NepaliDateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '/' || (e.KeyChar >= '0' && e.KeyChar <= '9'))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void NepaliDateTextBox_DoubleClick(object sender, EventArgs e)
        {
            ShowHideDatePicker();
            ShowHideDatePicker();
        }

        //private void NepaliDateTextBox_Layout(object sender, LayoutEventArgs e)
        //{
        //    //if (picker.Value.Date != DateTime.Now.Date)
        //    //this.Text = _dateConverter.ToBS(picker.Value.Date).ToString();
        //}

        private void AddIcon()
        {
            var icon = new PictureBox
            {
                Image = Properties.Resources.icons8_calendar_16px,
                Size = new Size(18, 18),
                Top = this.Top,
                Left = this.Width - 18
            };
            icon.Click += Icon_Click;
            icon.DoubleClick += NepaliDateTextBox_DoubleClick;
            this.Controls.Add(icon);
            icon.BringToFront();
        }

        private void Icon_Click(object sender, EventArgs e)
        {
            this.Focus();
            ShowHideDatePicker();
        }

        private void Calendar_DateSelected(object sender, DateSelectedEventArgs e)
        {
            this.Text = e.NepDate.ToString();
        }

        private void Calendar_CalendarLostFocus(object sender, EventArgs e)
        {
            if (!this.Focused && !_calendar.ContainsFocus)
                _calendar.Hide();
        }

        private void NepaliDateTextBox_LostFocus(object sender, EventArgs e)
        {
            if (!_calendar.ContainsFocus)
                _calendar.Hide();
        }

        private void NepaliDateTextBox_GotFocus(object sender, EventArgs e)
        {
            _focusedAt = DateTime.Now;
            ShowDatePicker();
        }

        private void NepaliDateTextBox_Click(object sender, EventArgs e)
        {
            ShowHideDatePicker();
        }
        private void ShowHideDatePicker()
        {
            var time = DateTime.Now;
            if (_calendar.Visible && (time - _focusedAt).TotalMilliseconds > 500)
                _calendar.Hide();
            else
            {
                ShowDatePicker();
            }
        }

        private void ShowDatePicker()
        {
            var calendar = _dateConverter.GetCalendarFromEnglishDate(DateTime.Now.Year, DateTime.Now.Month);
            _calendar.ResetDate(this.Text);

            _calendar.Show();

            Point locationOnForm = this.FindForm().PointToClient(this.Parent.PointToScreen(this.Location));
            var top = locationOnForm.Y + this.Height + 2;
            var left = locationOnForm.X;
            if (_calendar.Height > (this.FindForm().Height - top))
                _calendar.Top = top - this.Height - 4 - _calendar.Height;
            else
                _calendar.Top = top;
            if (_calendar.Width > (this.FindForm().Width - left))
                _calendar.Left = locationOnForm.X - _calendar.Width + this.Width - 2;
            else
                _calendar.Left = left;//this.Left;
            _calendar.Anchor = this.Anchor;
            this.FindForm().Controls.Add(_calendar);
            _calendar.BringToFront();
        }
        
        public void SetValue(DateTime value)
        {
            this.Text = _dateConverter.ToBS(value).ToString();
        }

        public DateTime GetValue()
        {
            return string.IsNullOrEmpty(this.Text) ? DateTime.Now : _dateConverter.ToAD(this.Text);
        }
    }
}
