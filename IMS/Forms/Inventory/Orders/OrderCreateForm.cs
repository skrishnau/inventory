using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IMS.Forms.Common;
using IMS.Forms.Common.Validations;
using IMS.Forms.Inventory.Suppliers;
using IMS.Forms.Inventory.Warehouses;
using Service.Core.Business;
using Service.Core.Inventory;
using Service.Core.Orders;
using Service.Core.Users;
using Service.Listeners;
using SimpleInjector.Lifestyles;
using ViewModel.Core.Common;
using ViewModel.Core.Orders;
using ViewModel.Core.Users;
using ViewModel.Enums;

namespace IMS.Forms.Inventory.Orders
{
    public partial class OrderCreateForm : Form
    {
        private readonly IUserService _userService;
        private readonly IDatabaseChangeListener _listener;
        private readonly IBusinessService _businessService;
        private readonly IOrderService _orderService;
        private readonly IInventoryService _inventoryService;

        private RequiredFieldValidator _requiredFieldValidator;

        private OrderModel _purchaseOrderModel;
        private int _orderId;
        private OrderTypeEnum _orderType;

        private Label warehouseClickLabel;

        public OrderCreateForm(
            IUserService supplierService,
            IBusinessService businessService,
            IInventoryService inventoryService,
            IOrderService purchaseService,
            IDatabaseChangeListener listener) /* It's a only way I know :D */
        {
            _listener = listener;
            this._businessService = businessService;
            this._userService = supplierService;
            this._orderService = purchaseService;
            this._inventoryService = inventoryService;

            InitializeComponent();

            this.Load += PurchaseOrderForm_Load;
        }

        private void PurchaseOrderForm_Load(object sender, EventArgs e)
        {
            var po = _orderService.GetOrder(_orderType, _orderId);

            PopulateClientCombo();
            PopulateWarehouseCombo();

            SetDataForEdit(po);


            InitializeValidation();

            _listener.UserUpdated += _listener_UserUpdated;
            _listener.WarehouseUpdated += _listener_WarehouseUpdated;

            lblWarehouse.DoubleClick += lblWarehouse_DoubleClick;
            lblToWarehouse.DoubleClick += lblWarehouse_DoubleClick;

        }

        private void InitializeValidation()
        {
            List<Control> controls = new List<Control>()
            {
                 tbName, tbOrderNumber,
            };
            switch (_orderType)
            {
                case OrderTypeEnum.Purchase:
                    controls.Add(cbWarehouse);
                    controls.Add(cbClient);
                    break;
                case OrderTypeEnum.Sale:
                    controls.Add(cbClient);
                    break;
                case OrderTypeEnum.Move:
                    controls.Add(cbWarehouse);
                    controls.Add(cbToWarehouse);
                    break;
            }
            _requiredFieldValidator = new RequiredFieldValidator(errorProvider, controls.ToArray());

        }



        #region Listener Events


        private void _listener_UserUpdated(object sender, Service.DbEventArgs.BaseEventArgs<UserModel> e)
        {
            PopulateClientCombo();
            cbClient.SelectedValue = e.Model == null ? 0 : e.Model.Id;
        }

        private void _listener_WarehouseUpdated(object sender, Service.DbEventArgs.BaseEventArgs<ViewModel.Core.Business.WarehouseModel> e)
        {
            PopulateWarehouseCombo();
            if (warehouseClickLabel != null)
            {
                if (warehouseClickLabel.Name == lblWarehouse.Name)
                {
                    cbWarehouse.SelectedValue = e.Model == null ? 0 : e.Model.Id;
                }
                else if (warehouseClickLabel.Name == lblToWarehouse.Name)
                {
                    cbToWarehouse.SelectedValue = e.Model == null ? 0 : e.Model.Id;
                }
            }
        }

        #endregion



        #region Populate Functions

        private void PopulateClientCombo()
        {
            List<IdNamePair> list = null;
            switch (_orderType)
            {
                case OrderTypeEnum.Purchase:
                case OrderTypeEnum.Sale:
                    list = _userService.GetSupplierListForCombo();
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
            var warehouses = _inventoryService.GetWarehouseListForCombo();
            warehouses.Insert(0, new IdNamePair
            {
                Id = 0,
                Name = "----- Select -----"
            });
            cbWarehouse.DataSource = warehouses;
            cbWarehouse.DisplayMember = "Name";
            cbWarehouse.ValueMember = "Id";
            // To Warehouse
            cbToWarehouse.DataSource = warehouses.ToArray();
            cbToWarehouse.DisplayMember = "Name";
            cbToWarehouse.ValueMember = "Id";
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
                _orderId = model.Id;
                tbName.Text = model.Name;
                tbNotes.Text = model.Note;
                tbOrderNumber.Text = model.ReferenceNumber;
                cbWarehouse.SelectedValue = model.WarehouseId ?? 0;
                dtExpectedDate.Value = model.DeliveryDate;
                numLotNumber.Value = model.LotNumber;
                cbClient.SelectedValue = model.UserId;

                switch (_orderType)
                {
                    case OrderTypeEnum.Purchase:
                        tbClientInfo.Text = model.SupplierInvoice;
                        break;
                    case OrderTypeEnum.Sale:
                        tbClientInfo.Text = model.Address;
                        tbPhone.Text = model.Phone;
                        break;
                }
            }
            else
            {
                // initial data
                var initials =
                    _orderType == OrderTypeEnum.Purchase ? "PO-"
                    : _orderType == OrderTypeEnum.Sale ? "SO-"
                    : _orderType == OrderTypeEnum.Move ? "MO-"
                    : "";
                // tbName.Text = initials + DateTime.Now.ToString("ddd, dd MMM yyyy");
                tbName.Text = initials + DateTime.Now.Ticks.ToString();
                numLotNumber.Value = _orderService.GetNextLotNumber();
            }

            switch (_orderType)
            {
                case OrderTypeEnum.Purchase:
                    lblClient.Text = "Supplier";
                    lblClientInfo.Text = "Supplier Invoice";
                    this.Text = (model == null ? "Create" : "Edit") + " Purchase Order";
                    tblToWarehouse.Visible = false;
                    if (model?.PaymentDueDate.HasValue ?? false)
                        dtPaymentDueDate.Value = model.PaymentDueDate.Value;
                    break;
                case OrderTypeEnum.Sale:
                    //cbWarehouse.Visible = false;
                    //lblWarehouse.Visible = false;
                    //lblWarehouse.Text = "From Warehouse";
                    lblClient.Text = "Customer";
                    lblPhone.Visible = true;
                    tbPhone.Visible = true;
                    lblExpectedDate.Text = "Delivery Date *";
                    lblClientInfo.Text = "Address";
                    this.Text = (model == null ? "Create" : "Edit") + " Sale Order";
                    tblToWarehouse.Visible = false;
                    if (model?.PaymentDueDate.HasValue ?? false)
                        dtPaymentDueDate.Value = model.PaymentDueDate.Value;
                    break;
                case OrderTypeEnum.Move:
                    cbWarehouse.Visible = true;
                    lblWarehouse.Visible = true;
                    lblClient.Visible = false;
                    cbClient.Visible = false;
                    lblPhone.Visible = false;
                    tbPhone.Visible = false;
                    lblExpectedDate.Text = "Transfer Date *";
                    lblClientInfo.Visible = false;
                    tbClientInfo.Visible = false;
                    this.Text = (model == null ? "Create" : "Edit") + " Transfer Order";
                    tblToWarehouse.Visible = true;
                    lblPaymentMethod.Visible = false;
                    break;
            }



        }

        #endregion



        #region Button and Label Events

        private void btnSavePurchaseOrder_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void lblClient_Click(object sender, EventArgs e)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                switch (_orderType)
                {
                    case OrderTypeEnum.Purchase:
                    case OrderTypeEnum.Sale:
                        var supplierCreate = Program.container.GetInstance<SupplierCreate>();
                        supplierCreate.ShowDialog();
                        break;
                }
            }
        }

        private void lblWarehouse_DoubleClick(object sender, EventArgs e)
        {
            warehouseClickLabel = (Label)sender;
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var warehouseCreate = Program.container.GetInstance<WarehouseCreateForm>();
                warehouseCreate.ShowDialog();
            }
            warehouseClickLabel = null;
        }

        #endregion

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
                DeliveryDate = dtExpectedDate.Value,
                Phone = tbPhone.Text,
                // don't add other properties which are set individually, e.g. receivedAt, etc.
            };

            var warehouseId = int.Parse(cbWarehouse.SelectedValue.ToString());
            model.UserId = int.Parse(cbClient.SelectedValue.ToString());
            switch (_orderType)
            {
                case OrderTypeEnum.Purchase:
                    model.WarehouseId = warehouseId;
                    model.SupplierInvoice = tbClientInfo.Text;
                    model.ToWarehouseId = null;
                    //model.PaymentDueDate = cbPaymentMethod.SelectedValue?.ToString();
                    break;
                case OrderTypeEnum.Sale:
                    model.WarehouseId = warehouseId == 0 ? (int?)null : warehouseId;
                    model.Address = tbClientInfo.Text;
                    model.ToWarehouseId = null;
                    //model.PaymentMethod = cbPaymentMethod.SelectedValue?.ToString();
                    break;
                case OrderTypeEnum.Move:
                    model.WarehouseId = int.Parse(cbWarehouse.SelectedValue.ToString());
                    model.ToWarehouseId = int.Parse(cbToWarehouse.SelectedValue.ToString());
                    //model.PaymentMethod = null;
                    break;
            }

            _orderService.SaveOrder(model, false);
            // redirect to PO detail page
            this.Close();
        }

    }
}
