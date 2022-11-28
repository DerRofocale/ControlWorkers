using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using ControlWorkers.DataBase;
using ControlWorkers.Services;
using ControlWorkers.View.Windows;

namespace ControlWorkers
{
    /// <copyright>
    /// © Dmitry Yalchik 2022. All rights are protected by the law of the Russian Federation
    /// </copyright>
    public partial class MainWindow : Window
    {
        private AppDBContext db;
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                db = new AppDBContext();

                User? currentUser = db.Users.Where(i => i.Id == new Guid(RegistryService.GetRegistryKeyUser("UserID"))).FirstOrDefault();
                if (currentUser != null)
                {
                    userNameTB.Text = $"Здравствуйте, {currentUser.FirstName}!";
                }
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
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

            if (RegistryService.GetRegistryKeySettings("StartFullScreen") == "True")
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(300);
                    if (RegistryService.GetRegistryKeySettings("AutoCloseAppAfter5Min") == "True" ? true : false)
                    {
                        var idleTime = IdleTimeDetectorService.GetIdleTimeInfo();
                        if (idleTime.IdleTime.TotalMinutes >= 5)
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                new AlertExitWindow().ShowDialog();
                            });
                        }
                    }
                }
            });
            if (!String.IsNullOrEmpty(RegistryService.GetRegistryKeyUser("UserID")))
            {

            }
        }

        private void PagesRotate(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                db = new AppDBContext();
                EmployeesDG.ItemsSource = db.Users.ToList();
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            }
            catch (Exception)
            { }
            finally
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
            }
        }

        private void AddNewUserDBTClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("AddNew");
        }
    }
}
