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
    public class ClientListPaginationHelper
    {
        private UserTypeEnum _userType;
        private string _searchName;

        private int totalRecords = 0;
        private int pageSize = 20;

        BindingSource bindingSource1;
        DataGridView dataGridView1;
        BindingNavigator bindingNavigator1;
        private readonly IUserService _userService;


        public ClientListPaginationHelper(BindingSource bindingSource, DataGridView dataGridView, BindingNavigator bindingNavigator, IUserService userService, UserTypeEnum userType, string searchName)
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

            int offset = ((int?)bindingSource1.Current)??0;
            //var records = new List<OrderModel>();
            //for (int i = offset; i < offset + pageSize && i < totalRecords; i++)
            //    records.Add(new OrderModel { ReferenceNumber = "This is rtest " + i });
            var records = _userService.GetAllUsers(_userType, pageSize, offset, _searchName);
            dataGridView1.DataSource = records.DataList;
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

        public void Reset(UserTypeEnum userType, string searchName)
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
            int offset = ((int?)bindingSource1.Current)??0;
            //var records = new List<OrderModel>();
            //for (int i = offset; i < offset + pageSize && i < totalRecords; i++)
            //    records.Add(new OrderModel { ReferenceNumber = "This is rtest " + i });
            var records = await _productService.GetAllProducts(_categoryId, _searchText, pageSize, offset);
            dataGridView1.DataSource = records.DataList;
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
        private int pageSize = 20;

        BindingSource bindingSource1;
        DataGridView dataGridView1;
        BindingNavigator bindingNavigator1;
        private readonly IOrderService _orderService;
        private OrderTypeEnum _orderType;
        private string _searchClient;
        private string _searchReceiptNo;

        public TransactionListPaginationHelper(BindingSource bindingSource, DataGridView dataGridView, BindingNavigator bindingNavigator, IOrderService orderService, OrderTypeEnum orderType )
        {
            this.bindingSource1 = bindingSource;
            this.dataGridView1 = dataGridView;
            this.bindingNavigator1 = bindingNavigator;
            this._orderService = orderService;
            _orderType = orderType;

            bindingNavigator1.BindingSource = bindingSource1;
            bindingSource1.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            var totalRecords = _orderService.GetAllOrdersCount(_orderType, _searchClient, _searchReceiptNo);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            // The desired page has changed, so fetch the page of records using the "Current" offset 
            int offset = ((int?)bindingSource1.Current)??0;
            //var records = new List<OrderModel>();
            //for (int i = offset; i < offset + pageSize && i < totalRecords; i++)
            //    records.Add(new OrderModel { ReferenceNumber = "This is rtest " + i });
            var records = _orderService.GetAllOrders(_orderType, _searchClient, _searchReceiptNo, pageSize, offset);
            dataGridView1.DataSource = records.OrderList;
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

        public void Reset(OrderTypeEnum orderType, string serachClient, string searchReceiptNo)
        {
            _orderType = orderType;
            _searchClient = serachClient;
            _searchReceiptNo = searchReceiptNo;
            var totalRecords = _orderService.GetAllOrdersCount(_orderType, _searchClient, _searchReceiptNo);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }
    }

    public class PaymentListPaginationHelper
    {
        private ClientTypeEnum _clientType;
        private string _searchName;

        private int totalRecords = 0;
        private int pageSize = 20;

        BindingSource bindingSource1;
        DataGridView dataGridView1;
        BindingNavigator bindingNavigator1;
        private readonly IPaymentService _paymentService;


        public PaymentListPaginationHelper(BindingSource bindingSource, DataGridView dataGridView, BindingNavigator bindingNavigator, IPaymentService paymentService, ClientTypeEnum clientType, string searchName)
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

            int offset = ((int?)bindingSource1.Current) ?? 0;
            //var records = new List<OrderModel>();
            //for (int i = offset; i < offset + pageSize && i < totalRecords; i++)
            //    records.Add(new OrderModel { ReferenceNumber = "This is rtest " + i });
            var records = _paymentService.GetAllPayments(_clientType, pageSize, offset, _searchName);
            dataGridView1.DataSource = records.DataList;
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

        public void Reset(ClientTypeEnum userType, string searchName)
        {
            _clientType = userType;
            _searchName = searchName;

            totalRecords = _paymentService.GetAllPaymentsCount(_clientType, searchName);
            bindingSource1.DataSource = new PageOffsetList(totalRecords, pageSize);
        }
    }


}
