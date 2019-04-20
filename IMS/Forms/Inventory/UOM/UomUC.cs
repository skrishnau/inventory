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
using IMS.Forms.Common;
using ViewModel.Core.Inventory;
using Service.Core.Inventory;
using ViewModel.Core.Common;
using IMS.Forms.Common.GridView;
using Service.Listeners;

namespace IMS.Forms.Inventory.UOM
{
    public partial class UomUC : UserControl
    {

        private readonly IInventoryService _inventoryService;
        private readonly IDatabaseChangeListener _listener;

        HeaderTemplate _header;
        private bool _isCurrentRowDirty;
        
        public UomUC(IInventoryService inventoryService, IDatabaseChangeListener listener)
        {
            _inventoryService = inventoryService;
            _listener = listener;

            InitializeComponent();

            this.Load += UomUC_Load;
        }
        GridViewColumnDecimalValidator _decimalValidator;

        private void UomUC_Load(object sender, EventArgs e)
        {
            InitializeHeader();
            InitializeEvents();
            PopulateUomData();

            // decimal column validations
            _decimalValidator = new GridViewColumnDecimalValidator(dgvUom);
            _decimalValidator.AddColumn(colQuantity, ColumnDataType.Decimal);
            _decimalValidator.Validate();

            _listener.UomUpdated += _listener_UomUpdated;
        }

        private void _listener_UomUpdated(object sender, Service.DbEventArgs.BaseEventArgs<UomModel> e)
        {
            PopulateUomData();
        }


        #region Initialization Functions

        private void InitializeHeader()
        {
            _header = HeaderTemplate.Instance;
            //_header.btnNew.Visible = true;
            //_header.btnNew.Click += BtnNew_Click;
            // add
            this.Controls.Add(_header);
            _header.SendToBack();
            // heading
            _header.lblHeading.Text = "UOM (Unit of Measure)";

        }

        private void InitializeEvents()
        {
            dgvUom.EditingControlShowing += DgvUom_EditingControlShowing;
            dgvUom.CellValidating += DgvUom_CellValidating;
            dgvUom.RowValidated += DgvUom_RowValidated;
            dgvUom.CurrentCellDirtyStateChanged += DgvUom_CurrentCellDirtyStateChanged;
        }


        #endregion


        #region Populating Functions

        private void PopulateUomData()
        {
            var uoms = _inventoryService.GetUomList();
            foreach (var uom in uoms)
            {
                AddRow(uom);
            }
            //dgvUom.AutoGenerateColumns = false;
            //dgvUom.DataSource = uoms;

        }

        private void AddRow(UomModel model)
        {
            var row = (DataGridViewRow)dgvUom.Rows[dgvUom.RowCount - 1].Clone();//new DataGridViewRow();
            row.Cells[colId.Index].Value = model.Id;
            row.Cells[colUnit.Index].Value = model.Name;
            row.Cells[colQuantity.Index].Value = model.Quantity;
            row.Cells[colBaseUnitId.Index].Value = model.BaseUomId;
            row.Cells[colBaseUnit.Index].Value = model.BaseUom;
            row.Cells[colUse.Index].Value = model.Use;
            dgvUom.Rows.Add(row);
        }

        #endregion


        #region Event Handlers


        private void DgvUom_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            //// decimal only in quantity column
            //e.Control.KeyPress -= new KeyPressEventHandler(UnitsColumn_KeyPress);
            //if (dgvUom.Columns[dgvUom.SelectedCells[0].ColumnIndex].Name == colQuantity.Name) // (dgvUom.CurrentCell.ColumnIndex == 2) //Desired Column
            //{
            //    TextBox tb = e.Control as TextBox;
            //    if (tb != null)
            //    {
            //        tb.KeyPress += new KeyPressEventHandler(UnitsColumn_KeyPress);
            //    }
            //}

            // base unit autocomplete textbox
           // else 
            if (dgvUom.Columns[dgvUom.SelectedCells[0].ColumnIndex].Name == colBaseUnit.Name)
            {
                TextBox autoText = e.Control as TextBox;
                if (autoText != null)
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    var dataCollection = GetAutoCompleteForBase();
                    autoText.AutoCompleteCustomSource = dataCollection;
                }
            }
        }

        private void DgvUom_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            _isCurrentRowDirty = true;
        }

        // row change 
        private void DgvUom_RowValidated(object sender, DataGridViewCellEventArgs e)
        {

            if (_isCurrentRowDirty)
            {
                _isCurrentRowDirty = false;

                // save the data
                var isRowValid = IsRowValid(e.RowIndex);
                if (isRowValid == null)
                    return;
                if (isRowValid ?? false)
                {
                    if (!IsUnitUnique(e.RowIndex))
                    {
                        return;
                    }

                    RemoveRowError(e.RowIndex);
                    var data = GetRowData(e.RowIndex);//dgvUom.Rows[e.RowIndex].DataBoundItem as UomModel;
                    _inventoryService.SaveUom(data);
                    PopupMessage.ShowSaveSuccessMessage();
                    this.dgvUom.Focus();
                    _isCurrentRowDirty = false;

                }
                else
                {
                    SetRowError(e.RowIndex);
                    //dgvUom.Rows[e.RowIndex].Selected = true;
                    PopupMessage.ShowMissingInputsMessage();
                    this.dgvUom.Focus();
                }
                dgvUom.Focus();
            }
        }

        // immediately after the control looses focus
        private void DgvUom_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var uomValue = dgvUom.Rows[e.RowIndex].Cells[colUnit.Name].Value;
            var baseUomValue = dgvUom.Rows[e.RowIndex].Cells[colBaseUnit.Name].Value;
            var useValue = dgvUom.Rows[e.RowIndex].Cells[colUse.Name].Value;
            var unitValue = dgvUom.Rows[e.RowIndex].Cells[colQuantity.Name].Value;
            // after UOM is updated, update base UOM, Units & use
            if (dgvUom.Columns[e.ColumnIndex].Name == colUnit.Name) // (dgvUom.CurrentCell.ColumnIndex == 2) //Desired Column
            {
                if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    // update baseUOM
                    if (baseUomValue == null || string.IsNullOrEmpty(baseUomValue.ToString()))
                    {
                        dgvUom.Rows[e.RowIndex].Cells[colBaseUnit.Name].Value = e.FormattedValue.ToString();
                        if (useValue == null || !bool.Parse(useValue.ToString()))
                        {
                            dgvUom.Rows[e.RowIndex].Cells[colUse.Name].Value = true;
                        }
                        if (unitValue == null || string.IsNullOrEmpty(unitValue.ToString()))
                        {
                            dgvUom.Rows[e.RowIndex].Cells[colQuantity.Name].Value = 1;
                        }
                    }
                }
            }
            // when base UOM is updated
            // check if parent base UOM is as per earlier UOM
            else if (dgvUom.Columns[e.ColumnIndex].Name == colBaseUnit.Name)
            {
                var list = GetAllUomNameList();
                if (!list.Any(x => x.ToLower() == e.FormattedValue.ToString().ToLower()))
                {
                    if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        PopupMessage.ShowPopupMessage("Invalid Base UOM", "Base Unit must be one of listed UOMs", PopupMessageType.INFO);
                        dgvUom.Focus();
                        // reset the text
                        if (dgvUom.EditingControl != null)
                        {
                            dgvUom.EditingControl.Text = "";
                        }
                        else
                        {
                            dgvUom.Rows[e.RowIndex].Cells[colBaseUnit.Name].Value = "";
                        }
                        // set the selection
                        // dgvUom.Rows[e.RowIndex].Cells[colBaseUnit.Name].Selected = true;
                    }
                }
                else
                {
                    // unit found for this base unit value; hence assign the id

                }
            }
        }



        #endregion



        #region Get Data

        private UomModel GetRowData(int rowIndex)
        {
            var model = new UomModel();
            var row = dgvUom.Rows[rowIndex];
            model.Id = int.Parse(GetIntegerCellValue(row, colId.Name));
            model.Name = GetStringCellValue(row, colUnit.Name);
            model.BaseUom = GetStringCellValue(row, colBaseUnit.Name);
            model.BaseUomId = int.Parse(GetIntegerCellValue(row, colBaseUnitId.Name));
            model.Quantity = decimal.Parse(GetIntegerCellValue(row, colQuantity.Name));
            model.Use = bool.Parse(GetStringCellValue(row, colUse.Name));
            return model;
        }

        private string GetIntegerCellValue(DataGridViewRow row, string cellName)
        {
            var value = row.Cells[cellName].Value == null ? "0"
                : string.IsNullOrEmpty(row.Cells[cellName].Value.ToString())
                ? "0"
                : row.Cells[cellName].Value.ToString();
            return value;
        }

        private string GetStringCellValue(DataGridViewRow row, string cellName)
        {
            var value = row.Cells[cellName].Value == null ? ""
                : string.IsNullOrEmpty(row.Cells[cellName].Value.ToString())
                ? ""
                : row.Cells[cellName].Value.ToString();
            return value;
        }


        private AutoCompleteStringCollection GetAutoCompleteForBase()
        {
            AutoCompleteStringCollection dataCollection = new AutoCompleteStringCollection();
            // addItems(DataCollection);
            foreach (var row in GetAllUomNameList())
            {
                dataCollection.Add(row);
            }
            return dataCollection;
        }

        private List<string> GetAllUomNameList()
        {
            var dataCollection = new List<string>();
            foreach (DataGridViewRow row in dgvUom.Rows)
            {
                var value = row.Cells[colUnit.Name].Value;
                if (value != null
                    && !string.IsNullOrEmpty(value.ToString()))// && string.IsNullOrEmpty(row.ErrorText)
                {
                    dataCollection.Add(value.ToString());
                }
            }
            return dataCollection;
        }


        #endregion



        #region  Helper Functions (GET)

        // removes error text
        private void RemoveRowError(int rowIndex)
        {
            foreach (DataGridViewCell cell in dgvUom.Rows[rowIndex].Cells)
            {
                cell.ErrorText = String.Empty;
            }
            dgvUom.Rows[rowIndex].ErrorText = string.Empty;

            //foreach (DataGridViewRow row in dgvUom.Rows)
            //{
            //    row.ErrorText = String.Empty;
            //}
        }

        private void SetRowError(int rowIndex)
        {
            dgvUom.Rows[rowIndex].ErrorText = "Error!";
        }

        private bool IsUnitUnique(int rowIndex)
        {
            var dataCollection = new List<string>();
            // unit value in the given row
            var unitValue = dgvUom.Rows[rowIndex].Cells[colUnit.Name].Value;
            if (unitValue != null)
            {
                foreach (DataGridViewRow row in dgvUom.Rows)
                {
                    var value = row.Cells[colUnit.Name].Value;
                    if (row.Index != rowIndex && value != null)
                    {
                        var valueString = value.ToString();
                        if (!string.IsNullOrEmpty(valueString) && valueString == unitValue.ToString())
                        {
                            SetRowError(rowIndex);
                            PopupMessage.ShowPopupMessage("Error!", "Duplicate Units", PopupMessageType.ERROR);
                            dgvUom.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }


        private bool? IsRowValid(int rowIndex)
        {
            if (rowIndex == dgvUom.RowCount - 1)
            {
                return null;
            }
            var isValid = true;
            var row = dgvUom.Rows[rowIndex];
            // unit
            var unitCell = row.Cells[colUnit.Name];
            var unitCellValue = unitCell.Value;
            if (unitCellValue == null || string.IsNullOrEmpty(unitCellValue.ToString()))
            {
                unitCell.ErrorText = "Required";
                isValid = false;
            }
            else
            {
                unitCell.ErrorText = string.Empty;
            }

            // quantity
            var quantityCell = row.Cells[colQuantity.Name];
            var quantityValue = quantityCell.Value;
            if (quantityValue == null || string.IsNullOrEmpty(quantityValue.ToString()))
            {
                quantityCell.ErrorText = "Required";
                isValid = false;
            }
            else
            {
                quantityCell.ErrorText = string.Empty;
            }

            // base unit
            var baseUnitCell = row.Cells[colBaseUnit.Name];
            var baseUnitValue = baseUnitCell.Value;
            var baseUnitValueString = baseUnitCell.Value == null ? "" : baseUnitValue.ToString();
            var uomList = GetAllUomNameList();
            // the currently editing unit is not added in the list; so add it
            //if (dgvUom.EditingControl != null)
            //{
            //    if(!uomList.Any(x=>x == dgvUom.EditingControl.Text))
            //    {
            //        // add
            //        if (unitCellValue != null)
            //            uomList.Add(unitCellValue.ToString());
            //    }
            //}
            if (string.IsNullOrEmpty(baseUnitValueString))
            {
                baseUnitCell.ErrorText = "Required";
                isValid = false;
            }
            else if (!uomList.Any(x => x.ToLower() == baseUnitValueString.ToLower()))
            {
                baseUnitCell.ErrorText = "Invalid Base UOM";
                isValid = false;
            }
            else
            {
                baseUnitCell.ErrorText = string.Empty;
            }


            return isValid;
        }

        #endregion


    }
}

//private void UnitsColumn_KeyPress(object sender, KeyPressEventArgs e)
//{
//    // allowed numeric and one dot  ex. 10.23
//    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
//         && e.KeyChar != '.')
//    {
//        e.Handled = true;
//    }

//    // only allow one decimal point
//    if (e.KeyChar == '.'
//        && (sender as TextBox).Text.IndexOf('.') > -1)
//    {
//        e.Handled = true;
//    }
//}



//private bool IsModelValid(UomModel data)
//{
//    var list = GetAllUomNames();
//    if (data != null)
//    {
//        return list.Any(x => x == data.BaseUnit)
//            && data.Quantity > 0
//            && !string.IsNullOrEmpty(data.Unit);
//    }
//    return false;
//}

//private List<IdValuePair> GetAllUomIdNameList()
//{
//    var dataCollection = new List<IdValuePair>();
//    foreach (DataGridViewRow row in dgvUom.Rows)
//    {
//        var value = row.Cells[colUnit.Name].Value;
//        if (value != null && !string.IsNullOrEmpty(value.ToString()))
//        {
//            var idValue = row.Cells[colId.Name].Value;
//            int id = 0;
//            if (idValue != null)
//                int.TryParse(idValue.ToString(), out id);
//            dataCollection.Add(new IdValuePair(id, value.ToString()));
//        }
//    }
//    return dataCollection;
//}

//private void BtnNew_Click(object sender, EventArgs e)
//{
//    var row = new DataGridViewRow();
//    dgvUom.Rows.Add(row);
//}
