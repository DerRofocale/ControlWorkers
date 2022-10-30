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

namespace ControlWorkers.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для DataBaseSettingsWindow.xaml
    /// </summary>
    public partial class DataBaseSettingsWindow : Window
    {
        public DataBaseSettingsWindow()
        {
            InitializeComponent();
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

        }

        private void validateNullPsw(object sender, RoutedEventArgs e)
        {

        }
    }
}
