using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace IMS.Forms.Common
{
    public partial class TextBoxWithDeleteUC : UserControl
    {
        public event EventHandler<EventArgs> OnRemoveClicked;

        private int _id;
        private List<string> _datasource;

        // custom property to get and set the text of this control
        public string InputText
        {
            get
            {
                return cbInput.Text;
            }
            set
            {
                cbInput.Text = value;
            }
        }

        public int Id { get { return _id; } set { _id = value; } }

        public DateTime CreatedAt { get; set; }


        public List<string> DataSource
        {
            get { return _datasource; }
            set
            {
                cbInput.DataSource = value;
                cbInput.Text = "";
                cbInput.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this._datasource = value;
            }
        }

        public void SetDropDownStyle(ComboBoxStyle style)
        {
            this.cbInput.DropDownStyle = style;
        }

        public TextBoxWithDeleteUC()
        {
            InitializeComponent();
            CreatedAt = DateTime.Now;
        }


        public void SetData(int id, string text, DateTime createdAt, List<string> autocompleteSource)
        {
            this._id = id;
            this.InputText = text;
            this.CreatedAt = createdAt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Height -= (int)(this.Size.Height * .2);
            this.Width -= (int)(this.Size.Width * .2);
            Thread.Sleep(40);
            this.Height -= (int)(this.Size.Height * .2);
            this.Width -= (int)(this.Size.Width * .2);
            Thread.Sleep(40);
            this.Height -= (int)(this.Size.Height * .2);
            this.Width -= (int)(this.Size.Width * .2);
            Thread.Sleep(40);
            this.Height -= (int)(this.Size.Height * .2);
            this.Width -= (int)(this.Size.Width * .2);
            Thread.Sleep(40);

            OnRemoveClicked(this, e);
        }


    }
}
