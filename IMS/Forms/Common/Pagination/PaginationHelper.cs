using Service.Core.Inventory.Units;
using Service.Core.Orders;
using Service.Core.Payment;
using Service.Core.Users;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Core.Orders;
using ViewModel.Enums;

namespace IMS.Forms.Common.Pagination
{
    class Record
    {
        public int Index { get; set; }
    }

    public class PaginationHelper
    {
        public static void SetRowNumber(DataGridView dgv, int offset)
        {
            dgv.RowHeadersWidth = 55;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                //row.HeaderCell.Value = (row.Index + 1).ToString();
                if(!row.IsNewRow)
                    row.HeaderCell.Value = ((offset) + (row.Index + 1)).ToString();
            }
        }
    }
    public class ClientListPaginationHelper
    {
        private List<UserTypeEnum> _userType;
        private string _searchName;

        private int totalRecords = 0;
        private int pageSize = 20;
        public int offset = 0;

        BindingSource bindingSource1;
        DataGridView dataGridView1;
        BindingNavigator bindingNavigator1;
        private readonly IUserService _userService;


        public ClientListPaginationHelper(BindingSource bindingSource, DataGridView dataGridView, BindingNavigator bindingNavigator, IUserService userService, List<UserTypeEnum> userType, string searchName)
        {
            this.bindingSource1 = bindingSource;
            this.dataGridView1 = dataGridView;
            this.bindingNavigator1 = bindingNavigator;
            this._userService = userService;
            _userType = userType;
            _searchName = searchName;

            bindingNavigator1.BindingSource = bindingSource1;
            bindingSource1.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            var totalRecords = _userService.GetAllUsersCount(_userType, searchName);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            // The desired page has changed, so fetch the page of records using the "Current" offset 

            offset = ((int?)bindingSource1.Current)??0;
            //var records = new List<OrderModel>();
            //for (int i = offset; i < offset + pageSize && i < totalRecords; i++)
            //    records.Add(new OrderModel { ReferenceNumber = "This is rtest " + i });
            bindingSource1.CurrentChanged -= bindingSource1_CurrentChanged;
            var records = _userService.GetAllUsers(_userType, pageSize, offset, _searchName);
            dataGridView1.DataSource = records.DataList;
            bindingSource1.CurrentChanged += bindingSource1_CurrentChanged;
            this.totalRecords = records.TotalCount;
        }

        class Record
        {
            public int Index { get; set; }
        }

        public class PageOffsetList : System.ComponentModel.IListSource
        {
            private int totalRecords;
            private int pageSize;
            public bool ContainsListCollection { get; protected set; }

            private PageOffsetList()
            {

            }

            public PageOffsetList(int totalRecords, int pageSize)
            {
                this.totalRecords = totalRecords;
                this.pageSize = pageSize;
            }


            public System.Collections.IList GetList()
            {
                // Return a list of page offsets based on "totalRecords" and "pageSize"
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }

        public void Reset(List<UserTypeEnum> userType, string searchName)
        {
            _userType = userType;
            _searchName = searchName;

            totalRecords = _userService.GetAllUsersCount(_userType, searchName);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }
    }



    public class ProductListPaginationHelper
    {
        private int totalRecords = 0;
        private int pageSize = 20;
        public int offset = 0;

        BindingSource bindingSource1;
        DataGridView dataGridView1;
        BindingNavigator bindingNavigator1;
        private readonly IProductService _productService;

        private int _categoryId;
        private string _searchText;

        public ProductListPaginationHelper(BindingSource bindingSource, DataGridView dataGridView, BindingNavigator bindingNavigator, IProductService productService)
        {
            this.bindingSource1 = bindingSource;
            this.dataGridView1 = dataGridView;
            this.bindingNavigator1 = bindingNavigator;
            this._productService = productService;

            bindingNavigator1.BindingSource = bindingSource1;
            bindingSource1.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            var totalRecords = _productService.GetAllProductsCount(_categoryId, _searchText);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }

        private async void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            // The desired page has changed, so fetch the page of records using the "Current" offset 
            offset = ((int?)bindingSource1.Current)??0;
            //var records = new List<OrderModel>();
            //for (int i = offset; i < offset + pageSize && i < totalRecords; i++)
            //    records.Add(new OrderModel { ReferenceNumber = "This is rtest " + i });
            var records = await _productService.GetAllProducts(_categoryId, _searchText, pageSize, offset);
            dataGridView1.DataSource = records.DataList;
            this.totalRecords = records.TotalCount;
        }

        

        public class PageOffsetList : System.ComponentModel.IListSource
        {
            private int totalRecords;
            private int pageSize;
            public bool ContainsListCollection { get; protected set; }

            private PageOffsetList()
            {

            }

            public PageOffsetList(int totalRecords, int pageSize)
            {
                this.totalRecords = totalRecords;
                this.pageSize = pageSize;
            }


            public System.Collections.IList GetList()
            {
                // Return a list of page offsets based on "totalRecords" and "pageSize"
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }

        public void Reset(int categoryId, string searchText)
        {
            _categoryId = categoryId;
            _searchText = searchText;
            var totalRecords = _productService.GetAllProductsCount(_categoryId, _searchText);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }
    }

    public class TransactionListPaginationHelper
    {
        private int totalRecords = 0;
        public int pageSize = 20;
        public int offset = 0;
        BindingSource bindingSource1;
        DataGridView dataGridView1;
        BindingNavigator bindingNavigator1;
        private readonly IOrderService _orderService;
        private OrderTypeEnum _orderType;
        private OrderListTypeEnum _orderListType;
        private string _searchClient;
        private string _searchReceiptNo;

        private OrderSearchModel _orderSearchModel = new OrderSearchModel();

        public TransactionListPaginationHelper(BindingSource bindingSource, DataGridView dataGridView, BindingNavigator bindingNavigator, IOrderService orderService, OrderTypeEnum orderType, OrderListTypeEnum orderListType )
        {
            this.bindingSource1 = bindingSource;
            this.dataGridView1 = dataGridView;
            this.bindingNavigator1 = bindingNavigator;
            this._orderService = orderService;
            _orderType = orderType;
            _orderListType = orderListType;

            bindingNavigator1.BindingSource = bindingSource1;
            bindingSource1.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            var totalRecords = _orderService.GetAllOrdersCount(_orderSearchModel);// _orderType, _orderListType, _searchClient, _searchReceiptNo);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            // The desired page has changed, so fetch the page of records using the "Current" offset 
            offset = ((int?)bindingSource1.Current)??0;
            //var records = new List<OrderModel>();
            //for (int i = offset; i < offset + pageSize && i < totalRecords; i++)
            //    records.Add(new OrderModel { ReferenceNumber = "This is rtest " + i });
            var records = _orderService.GetAllOrders(_orderSearchModel, pageSize, offset);// _orderType, _orderListType, _searchClient, _searchReceiptNo, pageSize, offset);
            dataGridView1.DataSource = records.OrderList;
            this.totalRecords = records.TotalCount;
        }
        
        public class PageOffsetList : System.ComponentModel.IListSource
        {
            private int totalRecords;
            private int pageSize;
            public bool ContainsListCollection { get; protected set; }

            private PageOffsetList()
            {

            }

            public PageOffsetList(int totalRecords, int pageSize)
            {
                this.totalRecords = totalRecords;
                this.pageSize = pageSize;
            }

            public System.Collections.IList GetList()
            {
                // Return a list of page offsets based on "totalRecords" and "pageSize"
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }

        public void Reset(OrderSearchModel searchModel)//OrderTypeEnum orderType, OrderListTypeEnum orderListType, string serachClient, string searchReceiptNo)
        {
            //_orderType = searchModel.OrderType;
            //_searchClient = searchModel.Client;
            //_searchReceiptNo = searchModel.ReceiptNo;
            //_orderListType = searchModel.OrderListType;
            _orderSearchModel = searchModel;
            var totalRecords = _orderService.GetAllOrdersCount(searchModel);// _orderType,  _orderListType, _searchClient, _searchReceiptNo);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }
    }

    public class PaymentListPaginationHelper
    {
        private List<UserTypeEnum> _clientType;
        private string _searchName;

        private int totalRecords = 0;
        private int pageSize = 20;
        public int offset = 0;

        BindingSource bindingSource1;
        DataGridView dataGridView1;
        BindingNavigator bindingNavigator1;
        private readonly IPaymentService _paymentService;


        public PaymentListPaginationHelper(BindingSource bindingSource, DataGridView dataGridView, BindingNavigator bindingNavigator, IPaymentService paymentService, List<UserTypeEnum> clientType, string searchName)
        {
            this.bindingSource1 = bindingSource;
            this.dataGridView1 = dataGridView;
            this.bindingNavigator1 = bindingNavigator;
            this._paymentService = paymentService;
            _clientType = clientType;
            _searchName = searchName;

            bindingNavigator1.BindingSource = bindingSource1;
            bindingSource1.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            var totalRecords = _paymentService.GetAllPaymentsCount(_clientType, searchName);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            // The desired page has changed, so fetch the page of records using the "Current" offset 

            offset = ((int?)bindingSource1.Current) ?? 0;
            //var records = new List<OrderModel>();
            //for (int i = offset; i < offset + pageSize && i < totalRecords; i++)
            //    records.Add(new OrderModel { ReferenceNumber = "This is rtest " + i });
            var records = _paymentService.GetAllPayments(_clientType, pageSize, offset, _searchName);
            dataGridView1.DataSource = records.DataList;
            this.totalRecords = records.TotalCount;
        }
        

        public class PageOffsetList : System.ComponentModel.IListSource
        {
            private int totalRecords;
            private int pageSize;
            public bool ContainsListCollection { get; protected set; }

            private PageOffsetList()
            {

            }

            public PageOffsetList(int totalRecords, int pageSize)
            {
                this.totalRecords = totalRecords;
                this.pageSize = pageSize;
            }


            public System.Collections.IList GetList()
            {
                // Return a list of page offsets based on "totalRecords" and "pageSize"
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }

        public void Reset(List<UserTypeEnum> userType, string searchName)
        {
            _clientType = userType;
            _searchName = searchName;

            totalRecords = _paymentService.GetAllPaymentsCount(_clientType, searchName);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }
    }

    public class InventoryUnitListPaginationHelper
    {
        private int _warehouseId;
        private int _productId;

        private int totalRecords = 0;
        private int pageSize = 20;
        public int offset = 0;

        BindingSource bindingSource1;
        DataGridView dataGridView1;
        BindingNavigator bindingNavigator1;
        private readonly IInventoryUnitService _inventoryUnitService;


        public InventoryUnitListPaginationHelper(BindingSource bindingSource, DataGridView dataGridView, BindingNavigator bindingNavigator, IInventoryUnitService _inventoryUnitService, int warehouseId, int productId)
        {
            this.bindingSource1 = bindingSource;
            this.dataGridView1 = dataGridView;
            this.bindingNavigator1 = bindingNavigator;
            this._inventoryUnitService = _inventoryUnitService;
            _warehouseId = warehouseId;
            _productId = productId;

            bindingNavigator1.BindingSource = bindingSource1;
            bindingSource1.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            var totalRecords = _inventoryUnitService.GetInventoryUnitCount(warehouseId, productId);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            // The desired page has changed, so fetch the page of records using the "Current" offset 
            offset = ((int?)bindingSource1.Current) ?? 0;
            //var records = new List<OrderModel>();
            //for (int i = offset; i < offset + pageSize && i < totalRecords; i++)
            //    records.Add(new OrderModel { ReferenceNumber = "This is rtest " + i });
            var records = _inventoryUnitService.GetInventoryUnitList(_warehouseId, _productId, pageSize, offset);
            dataGridView1.DataSource = records.DataList;
            this.totalRecords = records.TotalCount;
        }
        

        public class PageOffsetList : System.ComponentModel.IListSource
        {
            private int totalRecords;
            private int pageSize;
            public bool ContainsListCollection { get; protected set; }

            private PageOffsetList()
            {

            }

            public PageOffsetList(int totalRecords, int pageSize)
            {
                this.totalRecords = totalRecords;
                this.pageSize = pageSize;
            }


            public System.Collections.IList GetList()
            {
                // Return a list of page offsets based on "totalRecords" and "pageSize"
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }

        public void Reset(int warehouseId, int productId)
        {
            _warehouseId = warehouseId;
            _productId = productId;

            totalRecords = _inventoryUnitService.GetInventoryUnitCount(_warehouseId, _productId);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }
    }

    public class MovementListPaginationHelper
    {
        private int _productId;
        DateTime? _date;

        private int totalRecords = 0;
        private int pageSize = 20;
        public int offset = 0;

        BindingSource bindingSource1;
        DataGridView dataGridView1;
        BindingNavigator bindingNavigator1;
        private readonly IInventoryUnitService _inventoryUnitService;


        public MovementListPaginationHelper(BindingSource bindingSource, DataGridView dataGridView, BindingNavigator bindingNavigator, IInventoryUnitService _inventoryUnitService, int productId, DateTime? date)
        {
            this.bindingSource1 = bindingSource;
            this.dataGridView1 = dataGridView;
            this.bindingNavigator1 = bindingNavigator;
            this._inventoryUnitService = _inventoryUnitService;
            _productId = productId;
            _date = date;

            bindingNavigator1.BindingSource = bindingSource1;
            bindingSource1.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            var totalRecords = _inventoryUnitService.GetMovementListCount(productId, date);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            // The desired page has changed, so fetch the page of records using the "Current" offset 
            offset = ((int?)bindingSource1.Current) ?? 0;
            //var records = new List<OrderModel>();
            //for (int i = offset; i < offset + pageSize && i < totalRecords; i++)
            //    records.Add(new OrderModel { ReferenceNumber = "This is rtest " + i });
            var records = _inventoryUnitService.GetMovementList(_productId, _date, pageSize, offset);
            dataGridView1.DataSource = records.DataList;
            this.totalRecords = records.TotalCount;
        }
        

        public class PageOffsetList : System.ComponentModel.IListSource
        {
            private int totalRecords;
            private int pageSize;
            public bool ContainsListCollection { get; protected set; }

            private PageOffsetList()
            {

            }

            public PageOffsetList(int totalRecords, int pageSize)
            {
                this.totalRecords = totalRecords;
                this.pageSize = pageSize;
            }


            public System.Collections.IList GetList()
            {
                // Return a list of page offsets based on "totalRecords" and "pageSize"
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }

        public void Reset( int productId, DateTime? date)
        {
            _productId = productId;
            _date = date;

            totalRecords = _inventoryUnitService.GetMovementListCount( _productId, _date);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }
    }

    public class ManufactureListPaginationHelper
    {
        private int totalRecords = 0;
        private int pageSize = 20;
        public int offset = 0;

        BindingSource bindingSource1;
        DataGridView dataGridView1;
        BindingNavigator bindingNavigator1;
        private readonly IManufactureService _productService;

        private int _categoryId;
        private string _searchText;

        public ManufactureListPaginationHelper(BindingSource bindingSource, DataGridView dataGridView, BindingNavigator bindingNavigator, IManufactureService productService)
        {
            this.bindingSource1 = bindingSource;
            this.dataGridView1 = dataGridView;
            this.bindingNavigator1 = bindingNavigator;
            this._productService = productService;

            bindingNavigator1.BindingSource = bindingSource1;
            bindingSource1.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            var totalRecords = _productService.GetAllManufacturesCount(_categoryId, _searchText);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }

        private async void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            // The desired page has changed, so fetch the page of records using the "Current" offset 
            offset = ((int?)bindingSource1.Current) ?? 0;
            var records = await _productService.GetAllManufactures(_categoryId, _searchText, pageSize, offset);
            dataGridView1.DataSource = records.DataList;
            this.totalRecords = records.TotalCount;
        }
        

        public class PageOffsetList : System.ComponentModel.IListSource
        {
            private int totalRecords;
            private int pageSize;
            public bool ContainsListCollection { get; protected set; }

            private PageOffsetList()
            {

            }

            public PageOffsetList(int totalRecords, int pageSize)
            {
                this.totalRecords = totalRecords;
                this.pageSize = pageSize;
            }


            public System.Collections.IList GetList()
            {
                // Return a list of page offsets based on "totalRecords" and "pageSize"
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }

        public void Reset(int categoryId, string searchText)
        {
            _categoryId = categoryId;
            _searchText = searchText;
            var totalRecords = _productService.GetAllManufacturesCount(_categoryId, _searchText);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }
    }


    public class DepartmentListPaginationHelper
    {
        private int totalRecords = 0;
        private int pageSize = 20;
        public int offset = 0;

        BindingSource bindingSource1;
        DataGridView dataGridView1;
        BindingNavigator bindingNavigator1;
        private readonly IManufactureService _manufactureService;

        private string _searchText;

        public DepartmentListPaginationHelper(BindingSource bindingSource, DataGridView dataGridView, BindingNavigator bindingNavigator, IManufactureService manufactureService)
        {
            this.bindingSource1 = bindingSource;
            this.dataGridView1 = dataGridView;
            this.bindingNavigator1 = bindingNavigator;
            this._manufactureService = manufactureService;

            bindingNavigator1.BindingSource = bindingSource1;
            bindingSource1.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            var totalRecords = _manufactureService.GetAllDepartmentsCount(_searchText);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }

        private async void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            // The desired page has changed, so fetch the page of records using the "Current" offset 
            offset = ((int?)bindingSource1.Current) ?? 0;
            //var records = new List<OrderModel>();
            //for (int i = offset; i < offset + pageSize && i < totalRecords; i++)
            //    records.Add(new OrderModel { ReferenceNumber = "This is rtest " + i });
            var records = await _manufactureService.GetAllDepartments( _searchText, pageSize, offset);
            dataGridView1.DataSource = records.DataList;
            this.totalRecords = records.TotalCount;
        }
        

        public class PageOffsetList : System.ComponentModel.IListSource
        {
            private int totalRecords;
            private int pageSize;
            public bool ContainsListCollection { get; protected set; }

            private PageOffsetList()
            {

            }

            public PageOffsetList(int totalRecords, int pageSize)
            {
                this.totalRecords = totalRecords;
                this.pageSize = pageSize;
            }


            public System.Collections.IList GetList()
            {
                // Return a list of page offsets based on "totalRecords" and "pageSize"
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }

        public void Reset(string searchText)
        {
            _searchText = searchText;
            var totalRecords = _manufactureService.GetAllDepartmentsCount(_searchText);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }
    }

}
