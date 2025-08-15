using System.Configuration;

namespace ProjetoFinal
{
    public static class ConfigHelper
    {
        public static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
