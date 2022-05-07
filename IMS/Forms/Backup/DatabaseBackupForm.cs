using IMS.Forms.Common;
using Service;
using Service.Core;
using Service.Core.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Utility;

namespace IMS.Forms.Backup
{
    public partial class DatabaseBackupForm : Form
    {
        private readonly IAppSettingService _appSettingService;

        public DatabaseBackupForm(IAppSettingService appSettingService)
        {
            _appSettingService = appSettingService;

            InitializeComponent();

            this.Load += DatabaseBackupForm_Load;
        }

        private async void DatabaseBackupForm_Load(object sender, EventArgs e)
        {
            var folderPath = (await _appSettingService.GetAppSettingAsync(Constants.KEY_BACKUP_FOLDER_PATH))?.Value ?? string.Empty;
            if (!string.IsNullOrEmpty(folderPath))
            {
                txtFolderPath.Text = folderPath;
                folderBrowserDialog1.SelectedPath = folderPath;
            }
            txtFileName.Text = BackupService.GetFileName(Constants.DATABASE_NAME);

            btnBackup.Click += BtnBackup_Click;
            btnBrowse.Click += BtnBrowse_Click;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtFolderPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private async void BtnBackup_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtFileName, string.Empty);
            errorProvider1.SetError(txtFolderPath, string.Empty);

            var folder = txtFolderPath.Text;
            var message = "";
            if (string.IsNullOrEmpty(folder))
            {
                errorProvider1.SetError(txtFolderPath, "Required");
                message += "Folder Path is requried \n";
            }
            var fileName = txtFileName.Text;
            if (string.IsNullOrEmpty(fileName))
            {
                errorProvider1.SetError(txtFileName, "Required");
                message += "File Name is requried \n";
            }

            var di = new DirectoryInfo(folder);
            if (!di.Exists)
            {
                message += "Folder path doesn't exist\n";
                errorProvider1.SetError(txtFolderPath, "Folder path doesn't exist");
            }
            if (!string.IsNullOrEmpty(message))
            {
                PopupMessage.ShowInfoMessage(message);
                this.Focus();
                return;
            }
            _appSettingService.SaveBackupFolderPath(folder);
            PopupMessage.ShowInfoMessage("Backup Started. You will be notified upon completion");
            this.Focus();
            var conn = UserSession.DatabaseConnectionModel.GetConnectionString().CodeFirstConnectionString;    //System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContextBackup"].ConnectionString;
            var backupService = new Service.Core.BackupService(conn, folder, fileName);
            try
            {
                this.Close();
                int val = await backupService.BackupDatabase(UserSession.DatabaseConnectionModel.DatabaseName);//"IMS");
                if (val < 0)
                {
                    PopupMessage.ShowSuccessMessage("Backup Completed!");
                    ParentForm?.Focus();
                }

            }
            catch (Exception ex)
            {
                PopupMessage.ShowErrorMessage(ex.Message);
                this?.Focus();
            }

        }
    }
}
