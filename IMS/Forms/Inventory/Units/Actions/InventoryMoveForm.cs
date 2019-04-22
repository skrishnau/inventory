﻿using Service.Core.Business;
using Service.Core.Inventory;
using Service.Core.Inventory.Units;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Inventory;

namespace IMS.Forms.Inventory.Units.Actions
{
    public partial class InventoryMoveForm : Form
    {

        private readonly IBusinessService _businessService;
        private readonly IInventoryService _inventoryService;
        private readonly IInventoryUnitService _inventoryUnitService;

        private List<InventoryUnitModel> _dataList;

        public InventoryMoveForm(IBusinessService businessService, IInventoryService inventoryService, IInventoryUnitService inventoryUnitService)
        {
            _businessService = businessService;
            _inventoryService = inventoryService;
            _inventoryUnitService = inventoryUnitService;

            InitializeComponent();

            this.Load += InventoryMoveForm_Load;
        }

        private void InventoryMoveForm_Load(object sender, EventArgs e)
        {
            PopulateWarehouseCombo();
        }

        private void PopulateWarehouseCombo()
        {
            var warehouses = _inventoryService.GetWarehouseListForCombo();
            warehouses.Insert(0, new ViewModel.Core.Common.IdNamePair(0, "--- Select ---"));
            cbWarehouse.DataSource = warehouses;
            cbWarehouse.ValueMember = "Id";
            cbWarehouse.DisplayMember = "Name";
        }

        public void SetData(List<InventoryUnitModel> list)
        {
            _dataList = list;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var warehouseId = int.Parse(cbWarehouse.SelectedValue.ToString());
            _inventoryUnitService.MoveInventoryUnits(warehouseId, _dataList);
            this.Close();
        }
    }
}
