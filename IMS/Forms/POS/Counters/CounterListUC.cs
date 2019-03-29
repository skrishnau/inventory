using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Common.Display;
using SimpleInjector.Lifestyles;
using IMS.Forms.Business.Create;
using Service.Core.Business;

namespace IMS.Forms.POS.Counters
{
    public partial class CounterListUC : UserControl
    {

        private readonly IBusinessService _businessService;

        public CounterListUC(IBusinessService businessService)
        {
            this._businessService = businessService;

            InitializeComponent();

            InitializeHeader();

            PopulateCounterData();
        }

        private void InitializeHeader()
        {
            var _header = SubHeadingTemplate.Instance;
            _header.lblHeading.Text = "Counters";
            _header.btnNew.Visible = true;
            _header.btnNew.Click += BtnNew_Click;
            _header.btnEdit.Visible = true;
            _header.btnEdit.Click += BtnEdit_Click;
            _header.btnDelete.Visible = true;
            _header.btnDelete.Click += BtnDelete_Click;

            this.Controls.Add(_header);
            _header.SendToBack();

        }


        private void BtnNew_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var counterCreate = Program.container.GetInstance<CounterCreate>();
                counterCreate.ShowInTaskbar = false;
                counterCreate.ShowDialog();
                PopulateCounterData();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void PopulateCounterData()
        {
            gvCounter.AutoGenerateColumns = false;
            var counters = _businessService.GetCounterList();
            gvCounter.DataSource = counters;
        }
    }
}
