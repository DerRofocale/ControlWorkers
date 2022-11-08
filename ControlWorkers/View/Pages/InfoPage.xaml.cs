using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ControlWorkers.Services;

namespace ControlWorkers.View.Pages
{
    /// <copyright>
    /// © Dmitry Yalchik 2022. All rights are protected by the law of the Russian Federation
    /// </copyright>
    public partial class ThanksPage : Page
    {
        public ThanksPage()
        {
            InitializeComponent();
            startUpWindowsCB.IsChecked = RegistryService.GetRegistryKeySettings("AutoStartUp") == "True" ? true : false;
            fullScreenCB.IsChecked = RegistryService.GetRegistryKeySettings("StartFullScreen") == "True" ? true : false;
            autoExitCB.IsChecked = RegistryService.GetRegistryKeySettings("AutoCloseAppAfter5Min") == "True" ? true : false;
            logOutCB.IsChecked = RegistryService.GetRegistryKeySettings("AutoLogOutAfter5Min") == "True" ? true : false;

        }

        private void AutoStartUpCHBX(object sender, RoutedEventArgs e)
        {
            RegistryService.SetRegistryKeySettings("AutoStartUp", startUpWindowsCB.IsChecked.Value.ToString());
        }

        private void FullScreenCHBX(object sender, RoutedEventArgs e)
        {
            RegistryService.SetRegistryKeySettings("StartFullScreen", fullScreenCB.IsChecked.Value.ToString());
        }

        private void AutoCloseAppCHBX(object sender, RoutedEventArgs e)
        {
            RegistryService.SetRegistryKeySettings("AutoCloseAppAfter5Min", autoExitCB.IsChecked.Value.ToString());
            if (!autoExitCB.IsChecked.Value)
            {
                RegistryService.SetRegistryKeySettings("AutoLogOutAfter5Min", "False");
            }
        }

        private void AutoLogOutCHBX(object sender, RoutedEventArgs e)
        {
            RegistryService.SetRegistryKeySettings("AutoLogOutAfter5Min", logOutCB.IsChecked.Value.ToString());

        }
    }
}
