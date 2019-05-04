using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IMS.Forms.Common;
using IMS.Forms.Common.Validations;
using IMS.Forms.Purchases.Order;
using Service.Core.Business;
using Service.Core.Customers;
using Service.Core.Inventory;
using Service.Core.Orders;
using Service.Core.Suppliers;
using Service.Listeners;
using ViewModel.Core.Common;
using ViewModel.Core.Orders;
using ViewModel.Enums;

namespace IMS.Forms.Inventory.Orders
{
    public partial class OrderCreateForm : Form
    {
        private readonly ISupplierService _supplierService;
        private readonly ICustomerService _customerService;
        private readonly IDatabaseChangeListener _listener;
        private readonly IBusinessService _businessService;
        private readonly IOrderService _orderService;
        private readonly IInventoryService _inventoryService;

        private RequiredFieldValidator _requiredFieldValidator;

        private OrderModel _purchaseOrderModel;
        private int _orderId;
        private OrderTypeEnum _orderType;

        public OrderCreateForm(
            ISupplierService supplierService,
            ICustomerService customerService,
            IBusinessService businessService,
            IInventoryService inventoryService,
            IOrderService purchaseService, 
            IDatabaseChangeListener listener) /* It's a only way I know :D */
        {
            _listener = listener;
            this._businessService = businessService;
            this._supplierService = supplierService;
            this._customerService = customerService;
            this._orderService = purchaseService;
            this._inventoryService = inventoryService;

            InitializeComponent();

            this.Load += PurchaseOrderForm_Load;
        }

        private void PurchaseOrderForm_Load(object sender, EventArgs e)
        {
            var po = _orderService.GetOrder(_orderType, _orderId);
            SetDataForEdit(po);
            // initial data
            tbName.Text = "Order - " + DateTime.Now.ToString("ddd, dd MMM yyyy");
            numLotNumber.Value = _orderService.GetNextLotNumber();

            switch (_orderType)
            {
                case OrderTypeEnum.Purchase:
                    lblClient.Text = "Supplier";
                    lblClientInfo.Text = "Supplier Invoice";
                    this.Text = "Create Purchase Order";
                    break;
                case OrderTypeEnum.Sale:
                    lblClient.Text = "Customer";
                    lblPhone.Visible = true;
                    tbPhone.Visible = true;
                    lblExpectedDate.Text = "Delivery Date *";
                    lblClientInfo.Text = "Address/Phone";
                    this.Text = "Create Sale Order";
                    break;
            }

            PopulateClientCombo();
            PopulateWarehouseCombo();

            InitializeValidation();

            _listener.CustomerUpdated += _listener_CustomerUpdated;
            _listener.SupplierUpdated += _listener_SupplierUpdated;

        }


        private void InitializeValidation()
        {
            var controls = new Control[]
            {
                tbName, tbOrderNumber, cbClient, cbWarehouse
            };
            _requiredFieldValidator = new RequiredFieldValidator(errorProvider, controls);

        }

        private void _listener_CustomerUpdated(object sender, Service.DbEventArgs.BaseEventArgs<ViewModel.Core.Customers.CustomerModel> e)
        {
            if(_orderType == OrderTypeEnum.Sale)
            {
                PopulateClientCombo();
                cbClient.SelectedValue = e.Model == null ? 0 : e.Model.Id;
            }
        }

        private void _listener_SupplierUpdated(object sender, Service.DbEventArgs.BaseEventArgs<ViewModel.Core.Suppliers.SupplierModel> e)
        {
            if (_orderType == OrderTypeEnum.Purchase)
            {
                PopulateClientCombo();
                cbClient.SelectedValue = e.Model == null ? 0 : e.Model.Id;
            }
        }

        #region Populate Functions

        private void PopulateClientCombo()
        {
            List<IdNamePair> list = null;
            switch (_orderType)
            {
                case OrderTypeEnum.Purchase:
                   list = _supplierService.GetSupplierListForCombo();
                    break;
                case OrderTypeEnum.Sale:
                    list = _customerService.GetCustomerListForCombo();
                    break;
            }
            if (list != null)
            {
                list.Insert(0, new IdNamePair
                {
                    Id = 0,
                    Name = "----- Select -----"
                });
                cbClient.DataSource = list;
                cbClient.DisplayMember = "Name";
                cbClient.ValueMember = "Id";
            }
        }

        private void PopulateWarehouseCombo()
        {
            var warehouses = _inventoryService.GetWarehouseList();
            cbWarehouse.DataSource = warehouses;
            cbWarehouse.DisplayMember = "Name";
            cbWarehouse.ValueMember = "Id";
        }

        public void SetDataForEdit(OrderTypeEnum orderType, int purchaseOrderId)
        {
            _orderType = orderType;
            _orderId = purchaseOrderId;
            
        }

        private void SetDataForEdit(OrderModel model)
        {
            _purchaseOrderModel = model;
            if (model != null)
            {
                // change button
                btnSave.Text = "Save";
                btnSave.Width = btnCancel.Width;
                this.Text = "Edit Purchase Order";

                _orderId = model.Id;
                tbName.Text = model.Name;
                tbNotes.Text = model.Note;
                tbOrderNumber.Text = model.ReferenceNumber;
                tbClientInfo.Text = model.SupplierInvoice;
                cbClient.SelectedValue = model.SupplierId;
                cbWarehouse.SelectedValue = model.WarehouseId;
                dtExpectedDate.Value = model.ExpectedDate;
                numLotNumber.Value = model.LotNumber;
            }
        }

        #endregion


        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var addItemForm = new PurchaseOrderAddItemForm();
            addItemForm.ShowDialog();
        }

        private void btnSavePurchaseOrder_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (!_requiredFieldValidator.IsValid())
            {
                PopupMessage.ShowMissingInputsMessage();
                this.Focus();
                return;
            }
            var model = new OrderModel()
            {
                Id = _orderId, //_purchaseOrderModel == null ? 0 : _purchaseOrderModel.Id,
                OrderType = _orderType.ToString(),
                LotNumber = (int)numLotNumber.Value,
                Name = tbName.Text,
                Note = tbNotes.Text,
                ReferenceNumber = tbOrderNumber.Text,
                ExpectedDate = dtExpectedDate.Value,
                // don't add other properties which are set individually, e.g. receivedAt, etc.
            };

            switch (_orderType)
            {
                case OrderTypeEnum.Purchase:
                    model.SupplierId = int.Parse(cbClient.SelectedValue.ToString());
                    model.WarehouseId = int.Parse(cbWarehouse.SelectedValue.ToString());
                    model.SupplierInvoice = tbClientInfo.Text;
                    break;
                case OrderTypeEnum.Sale:
                    model.CustomerId = int.Parse(cbClient.SelectedValue.ToString());
                    model.SupplierId = null;
                    model.WarehouseId = null;
                    model.Address = tbClientInfo.Text;
                    break;
            }

            _orderService.SavePurchaseOrder(model);
            // redirect to PO detail page
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
