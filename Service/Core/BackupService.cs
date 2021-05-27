using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core
{
    public class BackupService
    {
        private readonly string _connectionString;
        private readonly string _backupFolderFullPath;
        private string _fileName;
        private readonly string[] _systemDatabaseNames = { "master", "tempdb", "model", "msdb" };

        public BackupService(string connectionString, string backupFolderFullPath)
        {
            _connectionString = connectionString;
            _backupFolderFullPath = backupFolderFullPath;
        }
        public BackupService(string connectionString, string backupFolderFullPath, string fileName)
        {
            _connectionString = connectionString;
            _backupFolderFullPath = backupFolderFullPath;
            _fileName = fileName;
        }
        //public BackupService(string backupFolderFullPath)
        //{
        //    _backupFolderFullPath = backupFolderFullPath;
        //    // read connectionstring from config file
        //    //var connectionString =  System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;
        //}

        public async void BackupAllUserDatabases()
        {
            foreach (string databaseName in GetAllUserDatabases())
            {
                await BackupDatabase(databaseName);
            }
        }

        public async Task<int> BackupDatabase(string databaseName)
        {
            string filePath = BuildBackupPathWithFilename(databaseName);

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = String.Format("BACKUP DATABASE [{0}] TO DISK='{1}'", databaseName, filePath);

                using (var command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        return await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        private IEnumerable<string> GetAllUserDatabases()
        {
            var databases = new List<String>();

            DataTable databasesTable;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                databasesTable = connection.GetSchema("Databases");

                connection.Close();
            }

            foreach (DataRow row in databasesTable.Rows)
            {
                string databaseName = row["database_name"].ToString();

                if (_systemDatabaseNames.Contains(databaseName))
                    continue;

                databases.Add(databaseName);
            }

            return databases;
        }

        public string BuildBackupPathWithFilename(string databaseName)
        {
            if (string.IsNullOrEmpty(_fileName))
                _fileName = GetFileName(databaseName);
            return Path.Combine(_backupFolderFullPath, _fileName);
        }

        public static string GetFileName(string databaseName)
        {
            return string.Format("{0}-{1}.bak", databaseName, DateTime.Now.ToString("yyyy-MM-dd"));
        }


    }
}
