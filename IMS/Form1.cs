using IMS.Forms.Inventory;
using System;
using System.Windows.Forms;
using IMS.Forms.POS;
using IMS.Forms.Inventory.Orders;
using ViewModel.Enums;
using IMS.Forms.Authorization;

namespace IMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

           // InitializeEvents();
            
            // open inventory at first initialization

            this.Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowLoginFormOrLogin();
        }

        private void ShowLoginFormOrLogin()
        {
            // ask for password
            var loginForm = Program.container.GetInstance<LoginForm>();//new InventoryUC();
            DialogResult result = loginForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                DisplayInventory();
            }
            else if(result == DialogResult.Abort)
            {
                ShowLoginFormOrLogin();
            }else
            {
                this.Close();
                try {
                    this.Dispose();
                }
                catch (Exception) { }
            }

        }

        private void DisplayInventory()
        {
            this.Controls.Clear();
            var productListUC = Program.container.GetInstance<InventoryUC>();//new InventoryUC();
            this.Controls.Add(productListUC);
        }

        //private void InitializeEvents()
        //{
        //}

        /*
       private void BtnInventory_Click(object sender, EventArgs e)
       {
          // SetButtonSelection(sender);
           pnlBody.Controls.Clear();
           var productListUC = Program.container.GetInstance<InventoryUC>();//new InventoryUC();
           productListUC.Dock = DockStyle.Fill;
           pnlBody.Controls.Add(productListUC);
       }

       private void btnHome_Click(object sender, EventArgs e)
       {
           //SetButtonSelection(sender);
           // add the body
           pnlBody.Controls.Clear();
           var dashBoardUC = Program.container.GetInstance<DashboardUC>();
           dashBoardUC.Dock = DockStyle.Fill;
           pnlBody.Controls.Add(dashBoardUC);
       }


       private void SetButtonSelection(object button)
       {
           var btn = button as Button;
           if (btn != null)
           {
               ClearButtonSelection();
               btn.FlatStyle = FlatStyle.Flat;
               btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
               //btn.BackColor = System.Drawing.SystemColors.ControlLight;
           }
       }

       private void ClearButtonSelection()
       {
           foreach(var control in pnlSidebarBody.Controls)
           {
               var btn = control as Button;
               if (btn != null)
               {
                   // clear the selection style
                   btn.FlatStyle = FlatStyle.Standard;//System.Drawing.SystemColors.Control;
                   btn.ForeColor = System.Drawing.SystemColors.ControlText;
                   //btn.BackColor = System.Drawing.SystemColors.ControlLight;
               }
           }
       }
       */

    }
}
