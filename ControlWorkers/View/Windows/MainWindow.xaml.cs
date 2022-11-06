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
using ControlWorkers.Services;
using ControlWorkers.View.Windows;

namespace ControlWorkers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
                        var idleTime = IdleTimeDetector.GetIdleTimeInfo();
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
        }
    }
}
