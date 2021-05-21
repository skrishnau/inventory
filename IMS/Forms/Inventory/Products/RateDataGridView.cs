using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Common.Pagination;

namespace IMS.Forms.Inventory.Products
{
    public partial class RateDataGridView : UserControl
    {
        public RateDataGridView()
        {
            InitializeComponent();

            this.Load += RateDataGridView_Load;
        }

        private void RateDataGridView_Load(object sender, EventArgs e)
        {
            InitializeGridView();

            dgvRates.DataBindingComplete += DgvProductList_DataSourceChanged;
        }

        private void InitializeGridView()
        {
            dgvRates.RowHeadersVisible = true;
        }


        private void DgvProductList_DataSourceChanged(object sender, EventArgs e)
        {
            PaginationHelper.SetRowNumber(dgvRates, 0);
        }
    }
}
