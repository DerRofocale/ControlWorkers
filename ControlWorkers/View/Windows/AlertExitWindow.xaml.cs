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
using System.Windows.Threading;

namespace ControlWorkers.View.Windows
{
    /// <copyright>
    /// © Dmitry Yalchik 2022. All rights are protected by the law of the Russian Federation
    /// </copyright>
    public partial class AlertExitWindow : Window
    {
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private int CooldownTime = 10;
        public AlertExitWindow()
        {
            InitializeComponent();
            totalSecondsTB.Text = CooldownTime.ToString();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            if (CooldownTime <= 1)
            {
                App.Current.Shutdown();
            }
            CooldownTime -= 1;
            totalSecondsTB.Text = CooldownTime.ToString();
        }

        private void cancelAction(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            this.Close();
        }
    }
}
