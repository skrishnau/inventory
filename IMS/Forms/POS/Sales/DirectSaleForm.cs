using Service.Core.Orders;
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
    public partial class DirectSaleForm : Form
    {
        private readonly ISaleService saleService;
        public DirectSaleForm(ISaleService saleService)
        {
            this.saleService = saleService;
            InitializeComponent();
            InitializeEvents();
            tbDate.Text = DateTime.Now.ToString();
        }
        private void InitializeEvents()
        {
            btnNewItem.Click += BtnNewItem_Click;
        }

        private void BtnNewItem_Click(object sender, EventArgs e)
        {
            var newItemAddForm = Program.container.GetInstance<NewItemAddForm>();
            newItemAddForm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            //if(tbInvoiceNo.Text == "")
            //{
            //    tbInvoiceNo.BackColor = Color.LightPink;
            //    return;
            //}
            //if(tbVatNo.Text == "")
            //{
            //    tbVatNo.BackColor = Color.LightPink;
            //    return;
            //}
            //List<SaleItemModel> saleItemModels = new List<SaleItemModel>();
            //var rowCount = dataGridView1.RowCount;
            //for(int i = 0; i < rowCount - 1; i++)
            //{
            //    var saleItem = new SaleItemModel();
            //    saleItem.SKU = dataGridView1.Rows[i].Cells[1].Value.ToString();
            //    saleItem.Quantity = decimal.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            //    //var saleitem = (ViewModel.Core.Sales.SaleItemModel)dataGridView1.SelectedRows[0].DataBoundItem;

            //    saleItemModels.Add(saleItem);
            //}
            
            //var saleModel = new SaleModel
            //{
            //    Address = tbAddress.Text,
            //    BillNo = tbInvoiceNo.Text,
            //    CustomerName = tbBillTo.Text,
            //    Date = tbDate.Text,
            //    MobileNo = tbMobileNo.Text,
            //    TotalAmount = tbTotal.Text == "" ? decimal.Parse("0.0") : decimal.Parse(tbTotal.Text),
            //    VatNo = tbVatNo.Text,
            //    SaleItems = saleItemModels
                
               
            //};



            ////saleModel.SaleItem.Add(new SaleItemModel)

            //saleService.AddOrUpdateSale(saleModel);
            
            
        }

        

       
    }
}
