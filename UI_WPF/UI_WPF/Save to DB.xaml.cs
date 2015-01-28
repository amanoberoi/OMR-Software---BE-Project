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
using System.Data.SQLite;
namespace UI_WPF
{
    /// <summary>
    /// Interaction logic for Save_to_DB.xaml
    /// </summary>
    public partial class Save_to_DB : Window
    {
        List<OMRSoft.OMRSoft> objects;
        List<string> scanned_files;
        int total;
        public Save_to_DB(List<OMRSoft.OMRSoft> objects, List<string> scanned_files, int t)
        {
            InitializeComponent();
            this.objects = objects;
            this.scanned_files = scanned_files;
            total = t;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Select Year");

            data.Add("S.E.");
            data.Add("T.E.");
            data.Add("B.E.");

            List<string> dept_data = new List<string>();
            dept_data.Add("Select Department");
            dept_data.Add("Automobile");
            dept_data.Add("Civil");
            dept_data.Add("Computer");
            dept_data.Add("EXTC");
            dept_data.Add("F.E.");
            dept_data.Add("IT");
            dept_data.Add("Mechanical");


            this.year.ItemsSource = data;
            this.year.SelectedIndex = 0;
            this.dept.ItemsSource = dept_data;
            this.dept.SelectedIndex = 0;
            dept_label.Visibility = System.Windows.Visibility.Hidden;
            lbl_total_sheets.Content = total.ToString();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            for (int i =0; i < objects.Count; ++i)
            {
                string dept_name = this.dept.SelectedItem as string;
                string dept_year = this.year.SelectedItem as string;
                string roll_no = objects[i].roll_no;
                string sub_code = objects[i].subject_code;
                string qp_code = objects[i].qp_code;
                int marks = Worker.marks_scored(objects[i].answer_key, Worker.answer_key.answer);
                string result = "FAILED";
                if (marks > 40)
                    result = "PASSED";
                DateTime timestamp = DateTime.Now;
                string query = "";
                switch (dept_name)
                {
                    case "Automobile":
                        {
                            dept_name = "auto";
                            query = @"Insert into " + dept_name + "(roll_no, sub_code, qpaper_code, marks, result, view_sheet, answer_key, time_stamp, year) VALUES ('" + roll_no + "', '" + sub_code + "', '" + qp_code + "','" + marks + "','" + result + "','" + scanned_files[i] + "','" + Worker.answer_key_path + "','" + timestamp.ToString() + "','" + dept_year + "');";
                            break;
                        }
                    case "Computer":
                        {
                            dept_name = "comp";
                            query = @"Insert into " + dept_name + "(roll_no, sub_code, qpaper_code, marks, result, view_sheet, answer_key, time_stamp, year) VALUES ('" + roll_no + "', '" + sub_code + "', '" + qp_code + "','" + marks + "','" + result + "','" + scanned_files[i] + "','" + Worker.answer_key_path + "','" + timestamp.ToString() + "','" + dept_year + "');";
                            break;
                        }
                    case "Civil":
                        {
                            dept_name = "civil";
                            query = @"Insert into " + dept_name + "(roll_no, sub_code, qpaper_code, marks, result, view_sheet, answer_key, time_stamp, year) VALUES ('" + roll_no + "', '" + sub_code + "', '" + qp_code + "','" + marks + "','" + result + "','" + scanned_files[i] + "','" + Worker.answer_key_path + "','" + timestamp.ToString() + "','" + dept_year + "');";
                            break;
                        }
                    case "IT":
                        {
                            dept_name = "it";
                            query = @"Insert into " + dept_name + "(roll_no, sub_code, qpaper_code, marks, result, view_sheet, answer_key, time_stamp, year) VALUES ('" + roll_no + "', '" + sub_code + "', '" + qp_code + "','" + marks + "','" + result + "','" + scanned_files[i] + "','" + Worker.answer_key_path + "','" + timestamp.ToString() + "','" + dept_year + "');";
                            break;
                        }
                    case "EXTC":
                        {
                            dept_name = "extc";
                            query = @"Insert into " + dept_name + "(roll_no, sub_code, qpaper_code, marks, result, view_sheet, answer_key, time_stamp, year) VALUES ('" + roll_no + "', '" + sub_code + "', '" + qp_code + "','" + marks + "','" + result + "','" + scanned_files[i] + "','" + Worker.answer_key_path + "','" + timestamp.ToString() + "','" + dept_year + "');";
                            break;
                        }
                    case "Mechanical":
                        {
                            dept_name = "mech";
                            query = @"Insert into " + dept_name + "(roll_no, sub_code, qpaper_code, marks, result, view_sheet, answer_key, time_stamp, year) VALUES ('" + roll_no + "', '" + sub_code + "', '" + qp_code + "','" + marks + "','" + result + "','" + scanned_files[i] + "','" + Worker.answer_key_path + "','" + timestamp.ToString() + "','" + dept_year + "');";
                            break;
                        }
                    case "F.E.":
                        {
                            dept_name = "fe";
                            query = @"Insert into " + dept_name + "(roll_no, sub_code, qpaper_code, marks, result, view_sheet, answer_key, time_stamp, year) VALUES ('" + roll_no + "', '" + sub_code + "', '" + qp_code + "','" + marks + "','" + result + "','" + scanned_files[i] + "','" + Worker.answer_key_path + "','" + timestamp.ToString() + "','" + dept_year + "');";
                            break;
                        }
                    default:
                        {
                            dept_label.Visibility = System.Windows.Visibility.Visible;
                            break;
                        }
                }

                SQLiteCommand cmd = new SQLiteCommand(query, Worker.database_connection);
                cmd.ExecuteNonQuery();
            }

            this.Close();
        }

        private void btn_discard_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
