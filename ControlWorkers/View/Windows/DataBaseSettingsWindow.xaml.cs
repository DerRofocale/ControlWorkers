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
using ControlWorkers.DataBase;
using ControlWorkers.Services;

namespace ControlWorkers.View.Windows
{
    /// <copyright>
    /// © Dmitry Yalchik 2022. All rights are protected by the law of the Russian Federation
    /// </copyright>
    public partial class DataBaseSettingsWindow : Window
    {
        #region VALUES
        private string _currentDBHost { get; set; }
        private string _currentDBPort { get; set; }
        private string _currentDBName { get; set; }
        private string _currentDBUser { get; set; }
        private string _currentDBPassword { get; set; }
        private AppDBContext db;
        #endregion

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

            txtHost.Focus();
            txtHost.SelectAll();
        }

        #region VALIDATIONS
        /// <summary>
        /// ВАЛИДАЦИЯ ДЛЯ TEXTBOX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validateNullTxt(object sender, TextChangedEventArgs e)
        {
            //txtHost.Text = txtHost.Text.Replace(" ", "");
            //txtDatabase.Text = txtDatabase.Text.Replace(" ", "");
            //txtPort.Text = txtPort.Text.Replace(" ", "");
            //txtUsername.Text = txtUsername.Text.Replace(" ", "");

            if ((_currentDBHost == txtHost.Text &&
                _currentDBPort == txtPort.Text &&
                _currentDBName == txtDatabase.Text &&
                _currentDBUser == txtUsername.Text &&
                _currentDBPassword == txtPassword.Password) ||
                (txtHost.Text.Length == 0 ||
                txtPort.Text.Length == 0 ||
                txtDatabase.Text.Length == 0 ||
                txtUsername.Text.Length == 0 ||
                txtPassword.Password.Length == 0))
            {
                saveBtn.IsEnabled = false;
            }
            else
            {
                saveBtn.IsEnabled = true;
            }
        }

        /// <summary>
        /// ВАЛИДАЦИЯ ДЛЯ PASSWORDBOX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validateNullPsw(object sender, RoutedEventArgs e)
        {
            //txtHost.Text = txtHost.Text.Replace(" ", "");
            //txtDatabase.Text = txtDatabase.Text.Replace(" ", "");
            //txtPort.Text = txtPort.Text.Replace(" ", "");
            //txtUsername.Text = txtUsername.Text.Replace(" ", "");

            if ((_currentDBHost == txtHost.Text &&
                _currentDBPort == txtPort.Text &&
                _currentDBName == txtDatabase.Text &&
                _currentDBUser == txtUsername.Text &&
                _currentDBPassword == txtPassword.Password) ||
                (txtHost.Text.Length == 0 ||
                txtPort.Text.Length == 0 ||
                txtDatabase.Text.Length == 0 ||
                txtUsername.Text.Length == 0 ||
                txtPassword.Password.Length == 0))
            {
                saveBtn.IsEnabled = false;
            }
            else
            {
                saveBtn.IsEnabled = true;
            }
        }

        /// <summary>
        /// ВАЛИДАЦИЯ ЧИСЛОВОГО ПОРТА
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PortDistinctValidation(object sender, TextCompositionEventArgs e)
        {
            foreach (var ch in e.Text)
            {
                if (!Char.IsDigit(ch))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        #endregion

        #region CLICKS
        /// <summary>
        /// ПЕРЕМЕЩЕНИЕ ОКНА ДРОПОМ
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
            this.Owner.Top = this.Top;
            this.Owner.Left = this.Left;
        }

        /// <summary>
        /// ЗАКРЫТИЕ ОКНА
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitApp(object sender, RoutedEventArgs e)
        {
            Close();

        }

        /// <summary>
        /// СОХРАНЕНИЕ ПАРАМЕТРОВ В РЕЕСТРЕ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveSettingsBtn(object sender, RoutedEventArgs e)
        {
            SaveValues();
        }
        #endregion

        private void SaveValues()
        {
            try
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
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
                db = new AppDBContext();
                saveBtn.IsEnabled = false;
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                new ErrorWindow(ex.Message).ShowDialog();
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            }
            finally
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
            }
        }


        private void ValidHostTB(object sender, TextCompositionEventArgs e)
        {
            foreach (var ch in e.Text)
            {
                if (Char.Equals(ch, ' '))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void HostValidTB(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            else if (e.Key == Key.Enter)
            {
                txtPort.Focus();
                txtPort.SelectAll();
            }
        }

        private void PortValidTB(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            else if (e.Key == Key.Enter)
            {
                txtDatabase.Focus();
                txtDatabase.SelectAll();
            }
        }

        private void DatabaseValidTB(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            else if (e.Key == Key.Enter)
            {
                txtUsername.Focus();
                txtUsername.SelectAll();
            }
        }

        private void UserValidTB(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            else if (e.Key == Key.Enter)
            {
                txtPassword.Focus();
                txtPassword.SelectAll();
            }
        }

        private void PasswordValidTB(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            else if (e.Key == Key.Enter)
            {
                SaveValues();
            }
        }
    }
}
