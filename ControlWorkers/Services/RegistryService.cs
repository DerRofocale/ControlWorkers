using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ControlWorkers.Services
{
    /// <copyright>
    /// © Dmitry Yalchik 2022. All rights are protected by the law of the Russian Federation
    /// </copyright>
    public class RegistryService
    {
        #region SETTINGS
        private static readonly string registryPathSettings = Path.Combine(Registry.CurrentUser.Name, "SOFTWARE\\ControlWorkers\\Settings");
        /// <summary>
        /// Получить значение из реестра по ключу настройки
        /// </summary>
        /// <param name="key">Ключ настройки</param>
        /// <returns>Значение по ключу настройки</returns>
        public static string GetRegistryKeySettings(string key)
        {
            return (string)Registry.GetValue(registryPathSettings, key, string.Empty);
        }
        /// <summary>
        /// Установить значение в реест по ключу настройки
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение</param>
        public static void SetRegistryKeySettings(string key, string value)
        {
            Registry.SetValue(registryPathSettings, key, value, RegistryValueKind.String);
        }
        #endregion

        #region USER
        private static readonly string registryPathUser = Path.Combine(Registry.CurrentUser.Name, "SOFTWARE\\ControlWorkers\\CurrentUser");
        /// <summary>
        /// Получить значение из реестра по ключу пользователя
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetRegistryKeyUser(string key)
        {
            return (string)Registry.GetValue(registryPathUser, key, string.Empty);
        }
        /// <summary>
        /// Установить значение в реест по ключу пользователя
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значние</param>
        public static void SetRegistryKeyUser(string key, string value)
        {
            Registry.SetValue(registryPathUser, key, value, RegistryValueKind.String);
        }
        #endregion
    }
}
