﻿using System;
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

namespace ControlWorkers.View.Windows
{
    /// <copyright>
    /// © Dmitry Yalchik 2022. All rights are protected by the law of the Russian Federation
    /// </copyright>
    public partial class ErrorWindow : Window
    {
        public ErrorWindow(string _msg)
        {
            InitializeComponent();
            txtErrorMsg.Text = _msg;
        }

        private void closeWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
