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
    /// Interaction logic for Save_To_DB__Single_.xaml
    /// </summary>
    public partial class Save_To_DB__Single_ : Window
    {
        string roll_no, sub_code, qp_code, marks, scanned_file;
        List<string> data = new List<string>();
        List<string> dept_data = new List<string>();
        public Save_To_DB__Single_(OMRSoft.OMRSoft obj, string scanned_file)
        {
            InitializeComponent();
            roll_no = obj.roll_no; sub_code = obj.subject_code; qp_code = obj.qp_code; 
            marks = Worker.marks_scored(obj.answer_key, Worker.answer_key.answer).ToString();
            this.scanned_file = scanned_file;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            data.Add("Select Year");
            data.Add("S.E.");
            data.Add("T.E.");
            data.Add("B.E.");

            
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

            this.lbl_marks.Content = marks.ToString();
            this.lbl_roll.Content = roll_no;
            this.lbl_subject.Content = sub_code;
            this.lbl_qp.Content = qp_code;
            dept_label.Visibility = System.Windows.Visibility.Hidden;


        }
        private void btn_discard_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            DateTime timestamp = DateTime.Now;
            string result = "FAILED";
            string dept_name = this.dept.SelectedItem as string;
            string dept_year = this.year.SelectedItem as string;
            if (Convert.ToInt16(marks) > 40)
                result = "PASS";
            this.lbl_marks.Content = marks.ToString();
            this.lbl_roll.Content = roll_no;
            this.lbl_subject.Content = sub_code;
            this.lbl_qp.Content = qp_code;
            string query = "";
            switch (dept_name)
            {
                case "Automobile":
                    {
                        dept_name = "auto";
                        query = @"Insert into " + dept_name + "(roll_no, sub_code, qpaper_code, marks, result, view_sheet, answer_key, time_stamp, year) VALUES ('" + roll_no + "', '" + sub_code + "', '" + qp_code + "','" + marks + "','" + result + "','" + scanned_file + "','" + Worker.answer_key_path + "','" + timestamp.ToString() + "','" + dept_year + "');";
                        break;
                    }
                case "Computer":
                    {
                        dept_name = "comp";
                        query = @"Insert into " + dept_name + "(roll_no, sub_code, qpaper_code, marks, result, view_sheet, answer_key, time_stamp, year) VALUES ('" + roll_no + "', '" + sub_code + "', '" + qp_code + "','" + marks + "','" + result + "','" + scanned_file + "','" + Worker.answer_key_path + "','" + timestamp.ToString() + "','" + dept_year + "');";
                        break;
                    }
                case "Civil":
                    {
                        dept_name = "civil";
                        query = @"Insert into " + dept_name + "(roll_no, sub_code, qpaper_code, marks, result, view_sheet, answer_key, time_stamp, year) VALUES ('" + roll_no + "', '" + sub_code + "', '" + qp_code + "','" + marks + "','" + result + "','" + scanned_file + "','" + Worker.answer_key_path + "','" + timestamp.ToString() + "','" + dept_year + "');";
                        break;
                    }
                case "IT":
                    {
                        dept_name = "it";
                        query = @"Insert into " + dept_name + "(roll_no, sub_code, qpaper_code, marks, result, view_sheet, answer_key, time_stamp, year) VALUES ('" + roll_no + "', '" + sub_code + "', '" + qp_code + "','" + marks + "','" + result + "','" + scanned_file + "','" + Worker.answer_key_path + "','" + timestamp.ToString() + "','" + dept_year + "');";
                        break;
                    }
                case "EXTC":
                    {
                        dept_name = "extc";
                        query = @"Insert into " + dept_name + "(roll_no, sub_code, qpaper_code, marks, result, view_sheet, answer_key, time_stamp, year) VALUES ('" + roll_no + "', '" + sub_code + "', '" + qp_code + "','" + marks + "','" + result + "','" + scanned_file + "','" + Worker.answer_key_path + "','" + timestamp.ToString() + "','" + dept_year + "');";
                        break;
                    }
                case "Mechanical":
                    {
                        dept_name = "mech";
                        query = @"Insert into " + dept_name + "(roll_no, sub_code, qpaper_code, marks, result, view_sheet, answer_key, time_stamp, year) VALUES ('" + roll_no + "', '" + sub_code + "', '" + qp_code + "','" + marks + "','" + result + "','" + scanned_file + "','" + Worker.answer_key_path + "','" + timestamp.ToString() + "','" + dept_year + "');";
                        break;
                    }
                case "F.E.":
                    {
                        dept_name = "fe";
                        query = @"Insert into " + dept_name + "(roll_no, sub_code, qpaper_code, marks, result, view_sheet, answer_key, time_stamp, year) VALUES ('" + roll_no + "', '" + sub_code + "', '" + qp_code + "','" + marks + "','" + result + "','" + scanned_file + "','" + Worker.answer_key_path + "','" + timestamp.ToString() + "','" + dept_year + "');";
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
            this.Close();
        }
    }
}
