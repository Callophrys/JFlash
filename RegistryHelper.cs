using Microsoft.Win32;

namespace JFlash
{
    internal static class RegistryHelper
    {
        private const string RegistryPath = @"Software\Callophrys\JFlash";

        public static void SaveSetting(string keyName, string value)
        {
            using RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryPath);
            key.SetValue(keyName, value);
        }

        public static string LoadSetting(string keyName, string defaultValue = "")
        {
            using RegistryKey? key = Registry.CurrentUser.OpenSubKey(RegistryPath);
            return key?.GetValue(keyName, defaultValue)?.ToString() ?? defaultValue;
        }
    }
}
