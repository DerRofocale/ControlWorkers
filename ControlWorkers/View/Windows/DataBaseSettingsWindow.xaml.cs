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
using System.Windows.Shapes;
using ControlWorkers.Services;

namespace ControlWorkers.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для DataBaseSettingsWindow.xaml
    /// </summary>
    public partial class DataBaseSettingsWindow : Window
    {
        private string _currentDBHost { get; set; }
        private string _currentDBPort { get; set; }
        private string _currentDBName { get; set; }
        private string _currentDBUser { get; set; }
        private string _currentDBPassword { get; set; }
        public DataBaseSettingsWindow()
        {
            InitializeComponent();
            _currentDBHost = RegistryService.GetRegistryKeySettings("DBHost");
            _currentDBPort = RegistryService.GetRegistryKeySettings("DBPort");
            _currentDBName = RegistryService.GetRegistryKeySettings("DBName");
            _currentDBUser = RegistryService.GetRegistryKeySettings("DBUser");
            _currentDBPassword = RegistryService.GetRegistryKeySettings("DBPassword");
            txtHost.Text = _currentDBHost;
            txtPort.Text = _currentDBPort;
            txtDatabase.Text = _currentDBName;
            txtUsername.Text = _currentDBUser;
            txtPassword.Password = _currentDBPassword;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void validateNullTxt(object sender, TextChangedEventArgs e)
        {
            if (_currentDBHost == txtHost.Text &&
                _currentDBPort == txtPort.Text &&
                _currentDBName == txtDatabase.Text &&
                _currentDBUser == txtUsername.Text &&
                _currentDBPassword == txtPassword.Password)
            {
                saveBtn.IsEnabled = false;
            }
            else
            {
                saveBtn.IsEnabled = true;
            }
        }

        private void validateNullPsw(object sender, RoutedEventArgs e)
        {
            if (_currentDBHost == txtHost.Text &&
                _currentDBPort == txtPort.Text &&
                _currentDBName == txtDatabase.Text &&
                _currentDBUser == txtUsername.Text &&
                _currentDBPassword == txtPassword.Password)
            {
                saveBtn.IsEnabled = false;
            }
            else
            {
                saveBtn.IsEnabled = true;
            }
        }

        private void SaveSettingsBtn(object sender, RoutedEventArgs e)
        {
            RegistryService.SetRegistryKeySettings("DBHost", txtHost.Text.ToString());
            RegistryService.SetRegistryKeySettings("DBPort", txtPort.Text.ToString());
            RegistryService.SetRegistryKeySettings("DBName", txtDatabase.Text.ToString());
            RegistryService.SetRegistryKeySettings("DBUser", txtUsername.Text.ToString());
            RegistryService.SetRegistryKeySettings("DBPassword", txtPassword.Password.ToString());

            _currentDBHost = RegistryService.GetRegistryKeySettings("DBHost");
            _currentDBPort = RegistryService.GetRegistryKeySettings("DBPort");
            _currentDBName = RegistryService.GetRegistryKeySettings("DBName");
            _currentDBUser = RegistryService.GetRegistryKeySettings("DBUser");
            _currentDBPassword = RegistryService.GetRegistryKeySettings("DBPassword");

            saveBtn.IsEnabled = false;
        }
    }
}
