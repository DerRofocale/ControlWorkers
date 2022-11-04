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
using MaterialDesignThemes.Wpf;

namespace ControlWorkers.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            txtUsername.Focus();
        }


        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void validateNullTxt(object sender, TextChangedEventArgs e)
        {
            txtUsername.BorderBrush = new SolidColorBrush(Colors.LightGray);
            txtPassword.BorderBrush = new SolidColorBrush(Colors.LightGray);
            if (txtPassword.Password.Length != 0 && txtUsername.Text.Length != 0)
            {
                loginBtn.IsEnabled = true;
            }
            else
            {
                loginBtn.IsEnabled = false;
            }
        }

        private void validateNullPsw(object sender, RoutedEventArgs e)
        {
            txtUsername.BorderBrush = new SolidColorBrush(Colors.LightGray);
            txtPassword.BorderBrush = new SolidColorBrush(Colors.LightGray);
            if (txtPassword.Password.Length != 0 && txtUsername.Text.Length != 0)
            {
                loginBtn.IsEnabled = true;
            }
            else
            {
                loginBtn.IsEnabled = false;
            }
        }

        private void enterBtn(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void GoToRegisterWindowBTN(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            this.Visibility = Visibility.Hidden;
            registerWindow.Owner = this;
            registerWindow.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void openDBSettingsWindow(object sender, RoutedEventArgs e)
        {
            DataBaseSettingsWindow dataBaseSettingsWindow = new DataBaseSettingsWindow();
            dataBaseSettingsWindow.Owner = this;
            this.Visibility = Visibility.Hidden;
            dataBaseSettingsWindow.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void GoToTheNextField(object sender, KeyEventArgs e)
        {
            if (txtUsername.Text.Length > 0 && e.Key == Key.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void Login()
        {
            if (txtPassword.Password == "11032003" && txtUsername.Text == "Dmitry")
            {
                MainWindow mainWindow = new MainWindow();
                Close();
                mainWindow.ShowDialog();
            }
            else
            {
                txtUsername.BorderBrush = new SolidColorBrush(Colors.Red);
                txtPassword.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }

        private void EnterLogin(object sender, KeyEventArgs e)
        {
            if (txtPassword.Password.Length > 0 && e.Key == Key.Enter)
            {
                Login();
            }
            
        }
    }
}
