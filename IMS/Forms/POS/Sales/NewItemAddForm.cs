using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Sales
{
    public partial class NewItemAddForm : Form
    {
        public NewItemAddForm()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Load += NewItemAddForm_Load;

        }

        private void NewItemAddForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            var point = new Point(MousePosition.X + 15, MousePosition.Y);
            this.Location = point;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
