using IMS.Forms.Inventory;
using IMS.Forms.Inventory.Accounts.All;
using IMS.Forms.Inventory.Dashboard;
using IMS.Forms.Inventory.Orders;
using IMS.Forms.Inventory.Products;
using IMS.Forms.Inventory.Reports;
using IMS.Forms.Inventory.Reports.All;
using IMS.Forms.Inventory.Settings;
using IMS.Forms.Inventory.Suppliers;
using IMS.Forms.Inventory.Units;
using IMS.Forms.Inventory.Units.Details;
using IMS.Forms.MRP;
using IMS.Forms.MRP.Departments;
using IMS.Forms.POS;
using Service.Core.Business;
using Service.Core.Inventory;
using Service.Core.Inventory.Units;
using Service.Core.Orders;
using Service.Core.Payment;
using Service.Core.Reports;
using Service.Core.Settings;
using Service.Core.Users;
using Service.Interfaces;
using Service.Listeners;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Enums;

namespace IMS
{
   
    public class DIServiceInstance:IDIServiceInstance
    {
        IInventoryService _inventoryService;
        IProductService _productService;
        IOrderService _orderService;
        IAppSettingService _appSettingService;
        IDatabaseChangeListener _databaseChangeListener;
        IUserService _userService;
        IManufactureService _manufactureService;
        IProductOwnerService _productOwnerService;
        IInventoryUnitService _inventoryUnitService;
        IBusinessService _businessService;
        IUomService _uomService;
        IReportService _reportService;
        IPaymentService _paymentService;

        public DIServiceInstance(IInventoryService inventoryService,
            IProductService productService,
            IOrderService orderService,
            IAppSettingService appSettingService,
            IDatabaseChangeListener databaseChangeListener,
            IUserService userService,
            IManufactureService manufactureService,
            IProductOwnerService productOwnerService,
            IInventoryUnitService inventoryUnitService,
            IBusinessService businessService,
            IUomService uomService,
            IReportService reportService,
            IPaymentService paymentService
            )
        {
            _inventoryService = inventoryService;
            _productService = productService;
            _orderService = orderService;
            _appSettingService = appSettingService;
            _databaseChangeListener = databaseChangeListener;
            _userService = userService;
            _manufactureService = manufactureService;
            _productOwnerService = productOwnerService;
            _inventoryUnitService = inventoryUnitService;
            _businessService = businessService;
            _uomService = uomService;
            _reportService = reportService;
            _paymentService = paymentService;
        }
        public DashboardUC GetDashboardUC()
        {
            return new DashboardUC(_inventoryService, _productService,_orderService, _appSettingService, _databaseChangeListener);
        }
        public ClientListUC GetClientListUc()
        {
            return new ClientListUC(_userService, _databaseChangeListener, _appSettingService);
        }
        public OrderUC GetOrderUC(OrderTypeEnum orderType)
        {
            return new OrderUC(_orderService, _inventoryService, _databaseChangeListener, orderType);
        }
        public DepartmentListUC GetDepartmentListUC()
        {
            return new DepartmentListUC(_manufactureService, _databaseChangeListener, _productOwnerService);
        }
        public InventoryUnitListUC GetInventoryUnitListUC()
        {
            InventoryManageUC inventoryManageUC = GetInventoryManageUC();
            RateListUC rateListUC = GetRateListUC();
            InventoryMovementUC inventoryMovementUC = GetInventoryMovementUC();
            return new InventoryUnitListUC(inventoryManageUC, rateListUC, inventoryMovementUC);
        }
        public InventoryManageUC GetInventoryManageUC()
        {
            return new InventoryManageUC(_databaseChangeListener, _inventoryService, _productService, _inventoryUnitService, _businessService, _uomService, _productOwnerService);
        }
        public RateListUC GetRateListUC()
        {
            return new RateListUC(_productService, _inventoryService, _uomService, _databaseChangeListener, _productOwnerService);
        }
        public InventoryMovementUC GetInventoryMovementUC()
        {
            return new InventoryMovementUC(_inventoryUnitService, _databaseChangeListener, _productService);
        }
        public PosUC GetPosUC()
        {
            PosMenuBar posMenuBar = new PosMenuBar();
            return new PosUC(posMenuBar);
        }
        public ProductUC GetProductUC()
        {
            ProductListUC productListUC = new ProductListUC(_productService, _databaseChangeListener);
            ProductDetailUC productDetailUC = new ProductDetailUC(_productService);
            return new ProductUC(productListUC, productDetailUC);
        }
        public ManufactureListUC GetManufactureListUC()
        {
            return new ManufactureListUC(_manufactureService, _databaseChangeListener);
        }
        public InventorySettingsUC GetInventorySettingsUC()
        {
            InventorySettingsSidebarUC inventorySettingsSidebarUC = new InventorySettingsSidebarUC();
            return new InventorySettingsUC(inventorySettingsSidebarUC);
        }
        public ReportsUC GetReportsUC()
        {
            return new ReportsUC(_reportService, _userService, _databaseChangeListener);
        }
        public AccountsUC GetAccountsUC()
        {
            ProfitAndLossUC profitAndLossUC = new ProfitAndLossUC(_reportService, _userService, _appSettingService, _databaseChangeListener);
            PaymentListUC paymentListUC = new PaymentListUC(_paymentService, _userService, _databaseChangeListener);
            LedgerUC ledgerUC = new LedgerUC(_reportService, _userService, _appSettingService, _databaseChangeListener);
            AccountsSidebarUC sidebarUC = new AccountsSidebarUC();
            ProductLedgerUC productLedgerUC = new ProductLedgerUC(_reportService, _productService, _appSettingService, _databaseChangeListener);
            return new AccountsUC(profitAndLossUC, paymentListUC, ledgerUC, sidebarUC, productLedgerUC);
        }
        public InventoryUC GetInventoryUC()
        {
            return new InventoryUC(new InventoryMenuBar(), _orderService, _productService, _databaseChangeListener, _inventoryService, _userService, _appSettingService, _uomService, _productOwnerService, _manufactureService, (IDIServiceInstance) this);
        }
    }

    public interface IDIServiceInstance
    {
        DashboardUC GetDashboardUC();
        ClientListUC GetClientListUc();
        OrderUC GetOrderUC(OrderTypeEnum orderType);
        DepartmentListUC GetDepartmentListUC();
        InventoryUnitListUC GetInventoryUnitListUC();
        InventoryManageUC GetInventoryManageUC();
        RateListUC GetRateListUC();
        InventoryMovementUC GetInventoryMovementUC();
        PosUC GetPosUC();
        ProductUC GetProductUC();
        ManufactureListUC GetManufactureListUC();
        InventorySettingsUC GetInventorySettingsUC();
        ReportsUC GetReportsUC();
        AccountsUC GetAccountsUC();
        InventoryUC GetInventoryUC();
    }
}
