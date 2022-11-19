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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ControlWorkers.DataBase;
using ControlWorkers.Services;
using MaterialDesignThemes.Wpf;

namespace ControlWorkers.View.Windows
{
    /// <copyright>
    /// © Dmitry Yalchik 2022. All rights are protected by the law of the Russian Federation
    /// </copyright>
    public partial class AuthWindow : Window
    {
        private AppDBContext db;
        public AuthWindow()
        {
            InitializeComponent();

            if (RegistryService.GetRegistryKeySettings("SaveLastEnter") == "True" ? true : false &&
                !String.IsNullOrEmpty(RegistryService.GetRegistryKeyUser("UserID")))
            {
                try
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                    db = new AppDBContext();

                    User? lastUser = db.Users.Where(i => i.Id == new Guid(RegistryService.GetRegistryKeyUser("UserID"))).FirstOrDefault();
                    if (lastUser != null)
                    {
                        firstNameTB.Text = $"Здравствуйте, {lastUser.FirstName}!";
                        txtUsername.Text = lastUser.Email;
                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                        txtPassword.Focus();
                    }
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
            else
            {
                txtUsername.Focus();
            }
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
            ValidationFields();
        }

        private void validateNullPsw(object sender, RoutedEventArgs e)
        {
            ValidationFields();
        }

        private void ValidationFields()
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
            this.Visibility = Visibility.Collapsed;
            dataBaseSettingsWindow.ShowDialog();
            this.Visibility = Visibility.Visible;
            try
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                db = new AppDBContext();
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

        private void GoToTheNextField(object sender, KeyEventArgs e)
        {
            if (txtUsername.Text.Length > 0 && e.Key == Key.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void Login()
        {

            User currentUser = db.Users.Where(u => u.Email.ToLower().Equals(txtUsername.Text.ToLower()) || u.PhoneNumber.Equals(txtUsername.Text)).FirstOrDefault();
            if (currentUser != null)
            {
                if (currentUser.Password.Equals(SHA256Service.ConvertToSHA256(txtPassword.Password)))
                {
                    if (currentUser.IsActivated == true)
                    {
                        RegistryService.SetRegistryKeyUser("UserID", currentUser.Id.ToString());
                        MainWindow mainWindow = new MainWindow();
                        Close();
                        mainWindow.ShowDialog();
                    }
                    else
                    {
                        ErrorWindow erWin = new ErrorWindow("Ваш аккаунт не активирован!\nОбратитесь к системному администратору.");
                        erWin.Owner = this;
                        erWin.ShowDialog();
                        try
                        {
                            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                            db = new AppDBContext();
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
                }
                else
                {
                    txtPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    try
                    {
                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                        db = new AppDBContext();
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
            }
            else
            {
                txtUsername.BorderBrush = new SolidColorBrush(Colors.Red);
                try
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                    db = new AppDBContext();
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
        }

        private void EnterLogin(object sender, KeyEventArgs e)
        {
            if (txtPassword.Password.Length > 0 && e.Key == Key.Enter)
            {
                Login();
            }
            
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                db = new AppDBContext();
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
    }
}
