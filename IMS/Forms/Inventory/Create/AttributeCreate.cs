using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMS.Forms.Inventory.Attributes;
using Service.Core.Inventory;
using ViewModel.Core.Inventory;

namespace IMS.Forms.Inventory.Create
{
    public partial class AttributeCreate : Form
    {
        private readonly IInventoryService inventoryService;

        private List<AttributeModel> _attributeList;

        private int attributeId;


        public AttributeCreate(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;
            InitializeComponent();
            PopulateAttributeNameCombo();
            this.Load += AttributeCreate_Load;
            _attributeList = this.inventoryService.GetAttributeList();
            
        }

        private void AttributeCreate_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            var point = new Point(MousePosition.X + 15, MousePosition.Y);
            this.Location = point;
        }

        void PopulateAttributeNameCombo()
        {
            var attribute = inventoryService.GetDistinctAttributes();
            //var attribute = inventoryService. ;
            cbAttributeName.DataSource = attribute;
            cbAttributeName.ValueMember = "Id";
            cbAttributeName.DisplayMember = "Name";
        }

        public void SetData(AttributeModel attributeModel)
        {
            attributeId = attributeModel.Id;
            tbValue.Text = attributeModel.Value;
            cbAttributeName.Text = attributeModel.Name;

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateAttribute();

            if (isValid)
            {
                // save
                var attributeModel = new AttributeModel
                {
                    Id = attributeId,
                    Name = cbAttributeName.Text,
                    Value = tbValue.Text
                };
                if (!inventoryService.AddOrUpdateAttribute(attributeModel))
                {
                    MessageBox.Show("Attribute-Value combo alreary in a database.");
                }
                else
                {
                    this.Close();
                }
            }
        }

        private bool ValidateAttribute()
        {
            if (tbValue.Text == "")
            {
                tbValue.BackColor = Color.LightPink;
                return false;
            }
            if (cbAttributeName.Text == "")
            {
                cbAttributeName.BackColor = Color.LightPink;
                return false;
            }
            return true;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAddAttributeValue_Click(object sender, EventArgs e)
        {
            var addAttribute = new AddAttributeValueUC();
            addAttribute.OnDeleteButtonClicked += AddAttribute_OnDeleteButtonClicked;
           // addAttribute.ParentPanel = panelAttribute;
            panelAttribute.Controls.Add(addAttribute);
        }

        private void AddAttribute_OnDeleteButtonClicked(object sender, EventArgs e)
        {
            panelAttribute.Controls.Remove((AddAttributeValueUC)sender);
        }

        private void AddAttributeValue_OnRemoveClicked(object sender, EventArgs e)
        {
            panelAttribute.Controls.Remove((AddAttributeValueUC)sender);
        }
    }
}
