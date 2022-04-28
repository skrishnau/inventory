using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Utility
{
    public class ConfigKeyValue
    {
        public ApplicationSettingsEnum Key { get; set; }
        public string Value { get; set; }
        public string ConvertToPlainText()
        {
            return Key.ToString() + " = " + Value;
        }
    }
    public class ApplicationSettings
    {
        public string DatabaseServer { get; set; }
        public string DatabaseDatabase { get; set; }
        public string DatabaseUsername { get; set; }
        public string DatabasePassword { get; set; }

        public static ConfigKeyValue TrimAndGetSettingsKeyAndValue(string l)
        {
            if (string.IsNullOrEmpty(l))
                return null;
            var trimmed = l.Trim();
            if (trimmed.StartsWith("#"))
                return null;
            var split = trimmed.Split(new char[] { '=' });
            if (split.Length < 2)
                return null;
            if (!Enum.TryParse<ApplicationSettingsEnum>(split[0], out ApplicationSettingsEnum settingEnum))
                return null;
            var settingValue = string.Empty;
            if (split.Length > 2)
            {
                var valueList = new List<string>();
                split[1] = split[1].TrimStart(); // trim left part of first value
                for (var i = 1; i < split.Length; i++)
                    valueList.Add(split[i]);
                string.Join("=", valueList);
            }
            else
            {
                settingValue = split[1];
            }
            return new ConfigKeyValue { Key = settingEnum, Value = settingValue };
        }
    }

    public enum ApplicationSettingsEnum
    {
        DB_Server,
        DB_Database,
        DB_Username,
        DB_Password
    }

    public class ConnectionStrings
    {
        public string EDMXConnectionString { get; set; }
        public string CodeFirstConnectionString { get; set; }
    }
}
