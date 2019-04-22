using Service.Core.Inventory;
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

namespace IMS.Forms.Inventory.Create
{
    [Obsolete("Brand is not used any more.", true)]
    public partial class BrandCreate : Form
    {
        private readonly IInventoryService inventoryService;

        public BrandCreate(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;

            InitializeComponent();

            InitializeEvents();
        }



        private void InitializeEvents()
        {
           // btnSave.Click += BtnSave_Click;
            //btnCancel.Click += BtnCancel_Click;

            this.Load += BrandCreate_Load;
        }

        private void BrandCreate_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            var point = new Point(MousePosition.X + 15, MousePosition.Y);
            this.Location = point;
          
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //if (tbBrandName.Text == "")
            //{
            //    tbBrandName.BackColor = Color.LightPink;
            //    return;
            //}
            //var brandModel = new BrandModel
            //{
            //    Name = tbBrandName.Text
            //};
            //inventoryService.AddUpdateBrand(brandModel);
            //this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       /* private void BrandCreate_Paint(object sender, PaintEventArgs e)
        {
            var pen = new Pen(Color.Blue, 2);
            var rect = new Rectangle(1, 1, 100, 100);
            e.Graphics.DrawRectangle(pen, rect);
        } */
    }
}
