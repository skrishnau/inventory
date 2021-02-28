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
        }

        private void AddIcon()
        {
            var icon = new PictureBox
            {
                Image = Properties.Resources.icons8_Energy_Meter_16px,
                Size = new Size(18, 18),
                Top = this.Top,
                Left = this.Width + 9
            };
            icon.Click += NepaliDateTextBox_GotFocus;
            this.Controls.Add(icon);
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
            _calendar.Left = locationOnForm.X;//this.Left;
            _calendar.Top = locationOnForm.Y + this.Height + 2;//this.Top
            this.FindForm().Controls.Add(_calendar);
            _calendar.BringToFront();
        }

    }
}
