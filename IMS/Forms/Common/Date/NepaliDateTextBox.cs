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
        DateConverter _dateConverter;

        public NepaliDateTextBox()
        {
            _dateConverter = new DateConverter();
            if (_calendar == null)
                _calendar = new NepaliCalendarUC(_dateConverter);

            // this.GotFocus += NepaliDateTextBox_GotFocus;
            this.Enter += NepaliDateTextBox_GotFocus;
            this.LostFocus += NepaliDateTextBox_LostFocus;
            //this.Leave += NepaliDateTextBox_LostFocus;
            this.Click += NepaliDateTextBox_GotFocus;
            _calendar.CalendarLostFocus += Calendar_CalendarLostFocus;
            _calendar.DateSelected += Calendar_DateSelected;
            AddIcon();
            this.Text = _calendar.Value.ToString();
        }

        private void AddIcon()
        {
            var icon = new PictureBox
            {
                Image = Properties.Resources.icons8_calendar_16px,
                Size = new Size(18, 18),
                Top = this.Top,
                Left = this.Width - 18
            };
            icon.Click += NepaliDateTextBox_GotFocus;
            this.Controls.Add(icon);
            icon.BringToFront();
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
            ShowDatePicker();
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

        public DateTime Value
        {
            get { return string.IsNullOrEmpty(this.Text) ? DateTime.Now : _dateConverter.ToAD(this.Text); }
            set { this.Text = _dateConverter.ToBS(value)?.ToString(); }
        }

    }
}
