﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ViewModel.Utility.DateConverter;
using ViewModel.Utility;

namespace IMS.Forms.Common.Date
{
    public partial class NepaliCalendarUC : UserControl
    {
        public event EventHandler<DateSelectedEventArgs> DateSelected;
        public event EventHandler<EventArgs> CalendarLostFocus;
        DateConverter _converter;
        static NepDate _today;

        public NepaliCalendarUC(DateConverter converter)
        {
            this._converter = converter;
            _today = _converter.ToBS(DateTime.Now);


            InitializeComponent();
            this.Load += NepaliCalendar_Load;
        }

        private void NepaliCalendar_Load(object sender, EventArgs e)
        {
            var years = new List<KeyValuePair<int, int>>();
            for (var i = 1970; i <= _today.Year; i++)
            {
                years.Add(new KeyValuePair<int, int> (i, i));
            }
            cbYear.DataSource = years;
            cbYear.ValueMember = "Key";
            cbMonth.DisplayMember = "Value";
            cbYear.SelectedValue = _today.Year;

            var months = DateConverter.nepaliMonth.ToList();
            cbMonth.DataSource = months;
            cbMonth.ValueMember = "Key";
            cbMonth.DisplayMember = "Value";
            cbMonth.SelectedValue = _today.Month;

            InitializeEvents();

            PopulateWeeks();

            Populate(_converter.GetCalendarFromNepaliDate(_today.Year, _today.Month));
        }

        internal void ResetDate(string date)
        {
            if (string.IsNullOrEmpty(date) || string.IsNullOrWhiteSpace(date))
            {
                cbYear.SelectedValue = _today.Year;
                cbMonth.SelectedValue = _today.Month;
            }
            else
            {
                var split = date.Split(new char[] { '/' });
                if (split.Length >= 3)
                {
                    int year, month, day;
                    if(int.TryParse(split[0], out year) && int.TryParse(split[1], out month) && int.TryParse(split[2], out day))
                    {
                        cbYear.SelectedValue = year;
                        cbMonth.SelectedValue = month;
                        _today = new NepDate { Day = day, Month = month, Year = year };
                        Populate();
                    }
                }
            }
        }

        private bool IsToday(int year, int month, int day)
        {
            return year == _today.Year && month == _today.Month && day == _today.Day;
        }

        private void PopulateWeeks()
        {
            var weeksShort = DateConverter.GetNepaliWeeksShortList();
            foreach(var w in weeksShort)
            {
                tableWeeks.Controls.Add(new Label { Text = w , Padding = new Padding(0), AutoSize=true, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter});
            }
        }
        private void InitializeEvents()
        {
            cbYear.SelectedValueChanged += CbYear_SelectedValueChanged;
            cbMonth.SelectedValueChanged += CbMonth_SelectedValueChanged;
            this.cbYear.LostFocus += NepaliCalendarUC_LostFocus;
            this.cbMonth.LostFocus += NepaliCalendarUC_LostFocus;
        }

        private void NepaliCalendarUC_LostFocus(object sender, EventArgs e)
        {
            if (!this.ContainsFocus)
                CalendarLostFocus(this, EventArgs.Empty);
        }
        

        private void CbMonth_SelectedValueChanged(object sender, EventArgs e)
        {
            Populate();
        }

        private void CbYear_SelectedValueChanged(object sender, EventArgs e)
        {
            Populate();
        }
        private void Populate()
        {
            Populate(_converter.GetCalendarFromNepaliDate((int)cbYear.SelectedValue, (int)cbMonth.SelectedValue));
        }

        public void Populate(List<NepDate> list)
        {
            tableDays.Controls.Clear();
            foreach (var item in list)
            {
                var lbl = new Label {  Tag = item, Padding = new Padding(0), AutoSize = true, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter };
                if (item.Year > 0 && item.Month > 0 && item.Day > 0)
                {
                    lbl.Text = item.Day.ToString();
                    lbl.Click += Date_Click;
                    if (IsToday(item.Year, item.Month, item.Day))//(item.Year == today.Year && item.Month == today.Month && item.Day == today.Day)
                        lbl.BackColor = Color.LightGray;
                    lbl.MouseLeave += Lbl_MouseLeave;
                    lbl.MouseEnter += Lbl_MouseEnter;
                }
                tableDays.Controls.Add(lbl);
            }
        }

        private void Lbl_MouseLeave(object sender, EventArgs e)
        {
            var control = sender as Control;
            var item = control.Tag as NepDate;
            if (IsToday(item.Year, item.Month, item.Day))
                control.BackColor = Color.LightGray;
            else
                control.BackColor = tableWeeks.BackColor;
        }

        private void Lbl_MouseEnter(object sender, EventArgs e)
        {
            var control = sender as Control;
            control.BackColor = Color.LightBlue;
        }

        private void Date_Click(object sender, EventArgs e)
        {
            var control = sender as Control;
            var item = control.Tag as NepDate;
            PopupMessage.ShowSuccessMessage(item.ToStringNepali());
            this.Hide();
            DateSelected(this, DateSelectedEventArgs.Instance(item));
        }
    }

    public class DateSelectedEventArgs: EventArgs
    {
        public NepDate NepDate { get; set; }
        public static DateSelectedEventArgs Instance(NepDate nepDate)
        {
            return new DateSelectedEventArgs { NepDate = nepDate};
        }
    }
}
