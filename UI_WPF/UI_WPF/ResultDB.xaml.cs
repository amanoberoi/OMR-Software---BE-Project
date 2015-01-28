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
    /// Interaction logic for ResultDB.xaml
    /// </summary>
    public partial class ResultDB : Window
    {

        public ResultDB()
        {
            InitializeComponent();
            dept_label.Visibility = System.Windows.Visibility.Hidden;
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

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Select Department");
            data.Add("Automobile");
            data.Add("Civil");
            data.Add("Computer");
            data.Add("EXTC");
            data.Add("IT");
            data.Add("Mechanical");
            data.Add("F.E.");

            this.cmb_box_dept.ItemsSource = data;
            this.cmb_box_dept.SelectedIndex = 0;
        }

        private void cmb_box_year_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Select Year");
            data.Add("S.E.");
            data.Add("T.E.");
            data.Add("B.E.");

            this.cmb_box_year.ItemsSource = data;
            this.cmb_box_year.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (this.cmb_box_dept.SelectedItem as string)
            {
                case "Automobile":
                    {
                        Database new_window = new Database("auto", cmb_box_year.SelectedItem as string);
                        new_window.ShowDialog();
                        break;
                    }
                case "Computer":
                    {
                        Database new_window = new Database("comp", cmb_box_year.SelectedItem as string);
                        new_window.ShowDialog();
                        break;
                    }
                case "Civil":
                    {
                        Database new_window = new Database("civil", cmb_box_year.SelectedItem as string);
                        new_window.ShowDialog();
                        break;
                    }
                case "IT":
                    {
                        Database new_window = new Database("it", cmb_box_year.SelectedItem as string);
                        new_window.ShowDialog();
                        break;
                    }
                case "EXTC":
                    {
                        Database new_window = new Database("extc", cmb_box_year.SelectedItem as string);
                        new_window.ShowDialog();
                        break;
                    }
                case "Mechanical":
                    {
                        Database new_window = new Database("mech", cmb_box_year.SelectedItem as string);
                        new_window.ShowDialog();
                        break;
                    }
                case "F.E.":
                    {
                        Database new_window = new Database("fe", cmb_box_year.SelectedItem as string);
                        new_window.ShowDialog();
                        break;
                    }
                default:
                    {
                        dept_label.Visibility = System.Windows.Visibility.Visible;
                        break;
                    }
            }
        }

    }
}
