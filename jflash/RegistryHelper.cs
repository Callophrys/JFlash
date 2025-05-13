using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace JFlash
{
    internal static class RegistryHelper
    {
        private const string RegistryPath = @"Software\NateDawg\JFlash";

        public static void SaveSetting(string keyName, string value)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryPath))
            {
                key.SetValue(keyName, value);
            }
        }

        public static string LoadSetting(string keyName, string defaultValue = "")
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryPath))
            {
                return key?.GetValue(keyName, defaultValue)?.ToString() ?? defaultValue;
            }
        }
    }
}
