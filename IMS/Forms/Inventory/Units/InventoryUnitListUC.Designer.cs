namespace IMS.Forms.Inventory.Units
{
    partial class InventoryUnitListUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this._sidebar = new IMS.Forms.Inventory.Units.InventoryUnitsMenu();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(13, 418);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(779, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(13, 418);
            this.panel2.TabIndex = 2;
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(13, 32);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(766, 418);
            this.pnlBody.TabIndex = 3;
            // 
            // _sidebar
            // 
            this._sidebar.BackColor = System.Drawing.Color.Gainsboro;
            this._sidebar.Dock = System.Windows.Forms.DockStyle.Top;
            this._sidebar.Location = new System.Drawing.Point(0, 0);
            this._sidebar.Name = "_sidebar";
            this._sidebar.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this._sidebar.Size = new System.Drawing.Size(792, 32);
            this._sidebar.TabIndex = 0;
            // 
            // InventoryUnitListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._sidebar);
            this.Name = "InventoryUnitListUC";
            this.Size = new System.Drawing.Size(792, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private InventoryUnitsMenu _sidebar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlBody;
    }
}
