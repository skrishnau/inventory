using IMS.Forms.Common;
using IMS.Forms.Common.Base;
using Infrastructure.Context;
using Microsoft.SqlServer.Management.Smo;
using Service;
using Service.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModel.Utility;

namespace IMS.Forms.Backup
{
    public partial class DatabaseConfigForm : BaseDialogForm
    {
        public DatabaseConfigForm()
        {
            InitializeComponent();
            this.Load += DatabaseConfigForm_Load;
        }

        private void DatabaseConfigForm_Load(object sender, EventArgs e)
        {
            // get all servers

            // PopulateServers();

            txtAuthKey.Text = GetAuthKey();

            btnSave.Click += BtnSave_Click;
        }
        private string GetAuthKey()
        {
            var random = new Random((int)DateTime.Now.Ticks);
            var list = new List<string>();
            for(var i=0; i< 4; i++)
            {
            ;
                list.Add(random.Next(1000, 9999).ToString());
            }
            return string.Join("-", list);
        }
       
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                PopupMessage.ShowInfoMessage("Please fill up required fields.");
                return;
            }
            //if (!CheckAuthCode())
            //{
            //    PopupMessage.ShowInfoMessage("Invalid Authorization Code!");
            //    return;
            //}
            var dbConnModel = new DatabaseConnectionModel
            {
                ServerName = cbServer.Text?.ToString(),
                DatabaseName = cbDatabase.Text?.ToString(),
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };
            var connectionString = dbConnModel.GetConnectionString();//DatabaseHelper.GetConnectionString(, , , );
            if (connectionString != null)
            {
                var testSuccess = DatabaseHelper.TestDatabaseConnection(connectionString);
                if (testSuccess)
                {
                    var saveSuccess = SaveConnectionStringToConfigFile(cbServer.Text?.ToString(), cbDatabase.Text?.ToString(), txtUsername.Text, txtPassword.Text);
                    if (saveSuccess)
                    {
                        UserSession.DatabaseConnectionModel = dbConnModel;
                        DialogResult = DialogResult.OK;
                        try
                        {
                            this.Close();
                        }
                        catch (Exception) { }
                    }
                    else
                    {
                        PopupMessage.ShowInfoMessage("Couldn't save database settings to config file. Make sure the app has permission to read write local temp folder.");
                    }
                }
                else
                {
                    PopupMessage.ShowInfoMessage("Couldn't connect to the given Database");
                }
            }
            // save 
        }

        private bool CheckAuthCode()
        {
            var authKey = txtAuthKey.Text;
            var authCode = txtAuthCode.Text;
            if (string.IsNullOrEmpty(authCode))
                return false;
            var reversed = authKey.Replace("-", "").Split().Reverse().Select(x => int.Parse(x)).ToList();
            var authCodeResult = string.Empty;
            var length = reversed.Count;
            for(var i=0; i< reversed.Count; i++)
            {
                authCodeResult += ((i == length - 1) ? reversed[0] + reversed[i] : reversed[i] + reversed[i + 1]) * 3 % 10;
                if (i < reversed.Count - 1 && i % 4 == 0)
                    authCodeResult += "-";
            }
            return authCodeResult == authCode;
        }

        private bool ValidateInputs()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(cbDatabase.Text))
            {
                errorProvider1.SetError(cbDatabase, "Required");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(cbDatabase, string.Empty);
            }
            if (string.IsNullOrEmpty(cbServer.Text))
            {
                errorProvider1.SetError(cbServer, "Required");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(cbServer, string.Empty);
            }
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Required");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtUsername, string.Empty);
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Required");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtPassword, string.Empty);
            }
            return isValid;
        }

        private bool SaveConnectionStringToConfigFile(string server, string database, string username, string password)
        {
            if (server != null && database != null)
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                path = Path.Combine(path, Constants.APP_NAME);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                var fileFullPath = Path.Combine(path, Constants.DATABASE_CONFIG_FILENAME);

                // (key, value)
                var toWriteList = new List<(string, string)>();//new Dictionary<string, string>();
                var applicationSettings = new ApplicationSettingsModel();
                if (File.Exists(fileFullPath))
                {
                    var lines = File.ReadAllLines(fileFullPath);
                    foreach (var l in lines)
                    {
                        var trimmed = l.Trim();
                        var keyValue = ApplicationSettingsModel.TrimAndGetSettingsKeyAndValue(l);
                        if (keyValue == null)
                        {
                            toWriteList.Add(("", l));
                            continue;
                        }
                        if (keyValue.Key == ApplicationSettingsEnum.DB_Server)
                            keyValue.Value = server;
                        else if (keyValue.Key == ApplicationSettingsEnum.DB_Database)
                            keyValue.Value = database;
                        else if (keyValue.Key == ApplicationSettingsEnum.DB_Username)
                            keyValue.Value = username;
                        else if (keyValue.Key == ApplicationSettingsEnum.DB_Password)
                            keyValue.Value = password;
                        toWriteList.Add((keyValue.Key.ToString(), keyValue.ConvertToPlainText()));
                    }
                }
                if(!toWriteList.Any(x=>x.Item1 == ApplicationSettingsEnum.DB_Server.ToString()))
                {
                    toWriteList.Add((ApplicationSettingsEnum.DB_Server.ToString(), ApplicationSettingsEnum.DB_Server.ToString() + " = " + server));
                }
                if(!toWriteList.Any(x=>x.Item1 == ApplicationSettingsEnum.DB_Database.ToString()))
                {
                    toWriteList.Add((ApplicationSettingsEnum.DB_Database.ToString(), ApplicationSettingsEnum.DB_Database.ToString() + " = " + database));
                }
                if(!toWriteList.Any(x=>x.Item1 == ApplicationSettingsEnum.DB_Username.ToString()))
                {
                    toWriteList.Add((ApplicationSettingsEnum.DB_Username.ToString(), ApplicationSettingsEnum.DB_Username.ToString() + " = " + username));
                }
                if(!toWriteList.Any(x=>x.Item1 == ApplicationSettingsEnum.DB_Password.ToString()))
                {
                    toWriteList.Add((ApplicationSettingsEnum.DB_Password.ToString(), ApplicationSettingsEnum.DB_Password.ToString() + " = " + password));
                }
                File.WriteAllLines(fileFullPath, toWriteList.Select(x=>x.Item2).ToArray());
                return true;
            }
            return false;
        }
    }
}

/*
       private void PopulateServers()
       {
           string myServer = Environment.MachineName;

           // SqlDataSourceEnumerator will only find named instances if the SQL Server Browser services are running. Please check your SQL Server Browser service.
           var list = new List<string>();

           DataTable servers = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
           for (int i = 0; i < servers.Rows.Count; i++)
           {
               if (myServer == servers.Rows[i]["ServerName"].ToString()) ///// used to get the servers in the local machine////
               {
                   if ((servers.Rows[i]["InstanceName"] as string) != null)
                       list.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);
                   else
                       list.Add(servers.Rows[i]["ServerName"].ToString());
               }
           }
           //DataTable dataTable = SmoApplication.EnumAvailableSqlServers(true);
           //for (int i = 0; i < dataTable.Rows.Count; i++)
           //{
           //    list.Add(dataTable.Rows[i]["Name"]as string);
           //}
           cbServer.DataSource = list;
       }
       public List<string> PopulateDatabaseList(string server, string userId, string password)
       {
           List<string> list = new List<string>();
           string conString;
           // Open connection to the database
           if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
               conString = $"server={server};uid={userId};pwd={password};database=master";
           else conString = $"server={server};database=master";

           using (SqlConnection con = new SqlConnection(conString))
           {
               con.Open();

               // Set up a command with the given query and associate
               // this with the current connection.
               using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
               {
                   using (IDataReader dr = cmd.ExecuteReader())
                   {
                       while (dr.Read())
                       {
                           list.Add(dr[0].ToString());
                       }
                   }
               }
           }
           cbDatabase.DataSource = list;
           return list;

       }
       */
