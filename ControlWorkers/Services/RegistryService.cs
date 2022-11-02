using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ControlWorkers.Services
{
    public class RegistryService
    {
        #region SETTINGS
        private static readonly string registryPathSettings = Path.Combine(Registry.CurrentUser.Name, "SOFTWARE\\ControlWorkers\\Settings");
        public static string GetRegistryKeySettings(string key)
        {
            return (string)Registry.GetValue(registryPathSettings, key, string.Empty);
        }
        public static void SetRegistryKeySettings(string key, string value)
        {
            Registry.SetValue(registryPathSettings, key, value, RegistryValueKind.String);
        }
        #endregion

        #region USER
        private static readonly string registryPathUser = Path.Combine(Registry.CurrentUser.Name, "SOFTWARE\\ControlWorkers\\CurrentUser");
        public static string GetRegistryKeyUser(string key)
        {
            return (string)Registry.GetValue(registryPathUser, key, string.Empty);
        }
        public static void SetRegistryKeyUser(string key, string value)
        {
            Registry.SetValue(registryPathUser, key, value, RegistryValueKind.String);
        }
        #endregion
    }
}
