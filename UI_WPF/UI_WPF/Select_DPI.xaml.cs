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

namespace UI_WPF
{
    /// <summary>
    /// Interaction logic for Select_DPI.xaml
    /// </summary>
    public partial class Select_DPI : Window
    {
        public Select_DPI()
        {
            InitializeComponent();
            warning_label.Visibility = System.Windows.Visibility.Hidden ;
            this.btn_ok.Focus();
        }

        private void _200_dpi_Checked(object sender, RoutedEventArgs e)
        {
            XMLRead.Scanner_DPI.dpi_value = 200;
        }

        private void _300_dpi_Checked(object sender, RoutedEventArgs e)
        {
            XMLRead.Scanner_DPI.dpi_value = 300;
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            if (this._300_dpi.IsChecked == false && this._200_dpi.IsChecked == false)
            {
                warning_label.Visibility = System.Windows.Visibility.Visible;
            }
            else
                this.Close();
        }
    }
}
