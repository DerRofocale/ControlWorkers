using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using ControlWorkers.Services;

namespace ControlWorkers.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для SplashScreenWindow.xaml
    /// </summary>
    public partial class SplashScreenWindow : Window
    {
        public SplashScreenWindow()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            // ПЕРВЫЙ ЗАПУСК
            if (RegistryService.GetRegistryKeySettings("isNotFirstStart") != "1")
            {
                RegistryService.SetRegistryKeySettings("isNotFirstStart", "1");
                RegistryService.SetRegistryKeySettings("DBHost", "localhost");
                RegistryService.SetRegistryKeySettings("DBPort", "5432");
                RegistryService.SetRegistryKeySettings("DBName", "testDiplom");
                RegistryService.SetRegistryKeySettings("DBUser", "postgres");
                RegistryService.SetRegistryKeySettings("DBPassword", "postgres");
                
            }
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerAsync();
        }

        private void Worker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            if (progressBar.Value == 100)
            {
                AuthWindow authWindow = new AuthWindow();
                Close();
                authWindow.ShowDialog();
            }
        }

        private void Worker_DoWork(object? sender, DoWorkEventArgs e)
        {

            for (int i = 0; i <= 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(40);
            }
        }
    }
}
