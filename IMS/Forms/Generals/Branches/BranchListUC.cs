using System;
using System.Windows.Forms;
using IMS.Forms.Common.Display;
using IMS.Forms.Business.Create;
using SimpleInjector.Lifestyles;
using Service.Core.Business;
using Service.Listeners;
using Service.Listeners.Business;
using ViewModel.Core.Business;

namespace IMS.Forms.Generals.Branches
{
    public partial class BranchListUC : UserControl
    {
        private readonly IBusinessService _businessService;
        private readonly IDatabaseChangeListener _listener;
        SubHeadingTemplate _header;

        private BranchModel _SelectedBranchModel;

        public BranchListUC(IBusinessService businessService, IDatabaseChangeListener listener)
        {
            _businessService = businessService;
            _listener = listener;

            InitializeComponent();
            this.Load += BranchListUC_Load;


        }

        private void BranchListUC_Load(object sender, EventArgs e)
        {
            InitializeHeader();

            PopulateBranchData();

            InitializeEvents();

            _listener.BranchUpdated += _listener_OnBranchUpdate;
        }

        private void InitializeEvents()
        {
            dgvBranch.SelectionChanged += DgvBranch_SelectionChanged;
        }

        private void DgvBranch_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBranch.SelectedRows.Count > 0)
            {
                _SelectedBranchModel = dgvBranch.SelectedRows[0].DataBoundItem as BranchModel;
            }
            else
            {
                _SelectedBranchModel = null;
            }
            HideShowEditDeleteButtons();
        }

        private void HideShowEditDeleteButtons()
        {
            var visible = _SelectedBranchModel != null;//dgvBranch.SelectedRows.Count > 0;
            _header.btnDelete.Visible = visible;
            _header.btnEdit.Visible = visible;
        }


        // other functions update the list via event
        private void _listener_OnBranchUpdate(object sender, BranchEventArgs e)
        {
            // TODO: update the record specifically
            PopulateBranchData();
        }

        private void InitializeHeader()
        {
            _header = SubHeadingTemplate.Instance;
            _header.btnNew.Visible = true;
            _header.btnNew.Click += BtnNew_Click;
            //_header.btnEdit.Visible = true;
            _header.btnEdit.Click += BtnEdit_Click;
            //_header.btnDelete.Visible = true;
            _header.btnDelete.Click += BtnDelete_Click;
            // add
            this.Controls.Add(_header);
            _header.SendToBack();
            // heading
            _header.lblHeading.Text = "Branches";

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ShowAddEditDialog(false);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // edit
            if (_SelectedBranchModel != null)
            {
                ShowAddEditDialog(true);
            }
        }

        private void ShowAddEditDialog(bool isEditMode)
        {
            using (AsyncScopedLifestyle.BeginScope(Program.container))
            {
                var branchCreate = Program.container.GetInstance<BranchCreate>();
                branchCreate.SetData(isEditMode ? _SelectedBranchModel : null);
                branchCreate.ShowDialog();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_SelectedBranchModel != null)
            {
                var dialogResult = MessageBox.Show(this, "Are you sure to delete?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _businessService.DeleteBranch(_SelectedBranchModel.Id);
                }
            }
        }

        private void PopulateBranchData()
        {
            dgvBranch.AutoGenerateColumns = false;
            var branchs = _businessService.GetBranchList();
            dgvBranch.DataSource = branchs;
        }

    }
}
