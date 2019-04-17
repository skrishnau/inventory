using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Forms.Common.GridView
{
    public class GridViewColumnDecimalValidator
    {
        DataGridView _dataGridView;
        List<DataGridViewColumn> _validatingDecimalColumns;
        List<DataGridViewColumn> _validatingIntegerColumns;

        List<int> _decimalColumnIndexArray;
        List<int> _integerColumnIndexArray;

        public GridViewColumnDecimalValidator(DataGridView dataGridView)//DataGridView dataGridView, DataGridViewColumn[] validatingColumns
        {
            //_validatingCells = validatingColumns;
            _dataGridView = dataGridView;

            _validatingDecimalColumns = new List<DataGridViewColumn>();
            _validatingIntegerColumns = new List<DataGridViewColumn>();

            _decimalColumnIndexArray = new List<int>();
            _integerColumnIndexArray = new List<int>();

        }

        public void AddColumn(DataGridViewColumn column, ColumnDataType dataType)
        {
            switch (dataType)
            {
                case ColumnDataType.Decimal:
                    _validatingDecimalColumns.Add(column);
                    _decimalColumnIndexArray.Add(column.Index);
                    break;
                case ColumnDataType.Integer:
                    _validatingIntegerColumns.Add(column);
                    _integerColumnIndexArray.Add(column.Index);
                    break;
            }
        }

        public void Validate()
        {
            _dataGridView.EditingControlShowing += DataGridView_EditingControlShowing;
        }

        private void DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // decimal only in quantity column
            e.Control.KeyPress -= new KeyPressEventHandler(DecimalColumn_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(IntegerColumn_KeyPress);

            var selectedCellColumnIndex = _dataGridView.SelectedCells[0].ColumnIndex;
            if (_decimalColumnIndexArray.Contains(selectedCellColumnIndex))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(DecimalColumn_KeyPress);
                }
            }
            else if (_integerColumnIndexArray.Contains(selectedCellColumnIndex))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(IntegerColumn_KeyPress);
                }
            }
        }

        private void DecimalColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allowed numeric and one dot  ex. 10.23
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void IntegerColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allowed numeric and one dot  ex. 10.23
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if (e.KeyChar == '.'
            //    && (sender as TextBox).Text.IndexOf('.') > -1)
            //{
            //    e.Handled = true;
            //}
        }

    }


    public enum ColumnDataType
    {
        Decimal, Integer
    }
}
