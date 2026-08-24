using System;
using System.Configuration;
using System.Text;

namespace ProjetoFinal
{
    public static class ConfigHelper
    {
        public static string? GetSetting(string key)
        {
            return Environment.GetEnvironmentVariable(key)
                ?? Environment.GetEnvironmentVariable(ToEnvironmentKey(key))
                ?? ConfigurationManager.AppSettings[key];
        }

        public static string GetSetting(string key, string defaultValue)
        {
            return GetSetting(key)
                ?? defaultValue;
        }

        public static string GetRequiredSetting(string key)
        {
            string value = GetSetting(key);
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException($"Configuração obrigatória ausente: {key}");
            }

            return value;
        }

        public static string GetOracleConnectionString()
        {
            return GetRequiredSetting("OracleConnectionString");
        }

        private static string ToEnvironmentKey(string key)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < key.Length; i++)
            {
                char current = key[i];
                if (i > 0 && char.IsUpper(current))
                {
                    builder.Append('_');
                }

                builder.Append(char.ToUpperInvariant(current));
            }

            return builder.ToString();
        }
    }
}
