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
using System.Data.SqlClient;

namespace UI_WPF
{
    /// <summary>
    /// Interaction logic for StartScreen.xaml
    /// </summary>
    public partial class StartScreen : Window
    {
        public StartScreen()
        {
            InitializeComponent();
            
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Multi_Scan window = new Multi_Scan();
            window.Show();
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            AnswerKey window = new AnswerKey();
            window.Show();
            this.Close();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            ResultDB window = new ResultDB();
            window.Show();
            this.Close();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Help window = new Help();
            window.Show();
            this.Close();

        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            About window = new About();
            window.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.imgbox_logo.Source = new BitmapImage(new Uri(@"D:\UI_WPF\UI_WPF\logo.png"));
        } 
    }
}
