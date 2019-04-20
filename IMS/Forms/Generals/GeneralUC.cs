using System.Windows.Forms;
using IMS.Forms.Common.Display;

namespace IMS.Forms.Generals
{
    public partial class GeneralUC : UserControl
    {
        private static readonly string MODULE_NAME = "General";
        private BodyTemplate _bodyTemplate;
        private GeneralMenuBar _menubar;

        public GeneralUC(GeneralMenuBar menubar)
        {
            this._menubar = menubar;

            InitializeComponent();

            InitializeRootTemplate();

            InitializeMenuBarButtonEvents();
        }

        private void InitializeRootTemplate()
        {
            // body
            _bodyTemplate = new BodyTemplate();
            _bodyTemplate.Dock = DockStyle.Fill;
            this.Controls.Add(_bodyTemplate);
            _bodyTemplate.lblHeading.Text = MODULE_NAME;
            // menubar template
            _bodyTemplate.pnlMenuBar.Controls.Add(_menubar);
        }

        private void InitializeMenuBarButtonEvents()
        {


            //_menubar.btnNewCategory.Click += BtnNewCategory_Click;
            //_menubar.btnAttributeList.Click += BtnAttributeList_Click;
            //_menubar.btnNewAttribute.Click += BtnNewAttribute_Click;
            // branch
            // _menubar.btnNewBranch.Click += BtnNewBranch_Click;

        }



        #region Product



        //private void BtnAttributeList_Click(object sender, EventArgs e)
        //{
        //    var attributeListUC = Program.container.GetInstance<AttributeListUC>();
        //    _bodyTemplate.pnlBody.Controls.Clear();
        //    attributeListUC.Dock = DockStyle.Fill;
        //    _bodyTemplate.pnlBody.Controls.Add(attributeListUC);

        //    _menubar.ClearSelection();
        //    _menubar.btnAttributeList.FlatStyle = FlatStyle.Flat;
        //}

        //private void BtnNewProduct_Click(object sender, EventArgs e)
        //{
        //    using (AsyncScopedLifestyle.BeginScope(Program.container))
        //    {
        //        var productCreate = Program.container.GetInstance<ProductCreate>();
        //        productCreate.ShowInTaskbar = false;
        //        productCreate.ShowDialog();
        //    }
        //}

        //private void BtnNewCategory_Click(object sender, EventArgs e)
        //{
        //    using (AsyncScopedLifestyle.BeginScope(Program.container))
        //    {
        //        var categoryCreate = Program.container.GetInstance<CategoryCreate>();
        //        categoryCreate.ShowInTaskbar = false;
        //        categoryCreate.ShowDialog();
        //    }
        //}

        //private void BtnNewAttribute_Click(object sender, EventArgs e)
        //{
        //    using (AsyncScopedLifestyle.BeginScope(Program.container))
        //    {
        //        var attributeCreate = Program.container.GetInstance<AttributeCreate>();
        //        attributeCreate.ShowInTaskbar = false;
        //        attributeCreate.ShowDialog();
        //    }
        //}

        #endregion


        #region Branches



        //private void BtnNewBranch_Click(object sender, EventArgs e)
        //{
        //    using (AsyncScopedLifestyle.BeginScope(Program.container))
        //    {
        //        var branchCreate = Program.container.GetInstance<BranchCreate>();
        //        branchCreate.ShowDialog();
        //        //PopulateBranchData();
        //    }
        //}

        #endregion



    }
}
