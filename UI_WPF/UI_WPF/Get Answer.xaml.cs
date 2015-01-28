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
    /// Interaction logic for Get_Answer.xaml
    /// </summary>
    public partial class Get_Answer : Window
    {
        int count;
        public Get_Answer(ref int count)
        {
            this.count = count;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_enter_answer.Visibility = System.Windows.Visibility.Hidden;
            txt_answer.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txt_answer.Text == "")
            {
                lbl_enter_answer.Visibility = System.Windows.Visibility.Visible;
                txt_answer.Focus();
                return;
            }
            else if (!Check_Answer(Convert.ToChar(txt_answer.Text)))
            {
                lbl_enter_answer.Visibility = System.Windows.Visibility.Visible;
                txt_answer.Focus();
                return;
            }
            Worker.set_answer_key[count] = Convert.ToChar(txt_answer.Text);
            this.Close();
        }

        private void txt_answer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (txt_answer.Text == "")
                {
                    lbl_enter_answer.Visibility = System.Windows.Visibility.Visible;
                    txt_answer.Focus();
                    return;
                }
                else if ( !Check_Answer(Convert.ToChar(txt_answer.Text)))
                {
                    lbl_enter_answer.Visibility = System.Windows.Visibility.Visible;
                    txt_answer.Focus();
                    return;
                }
                Worker.set_answer_key[count] = Convert.ToChar(txt_answer.Text);
                this.Close();
            }
             
        }
        private bool Check_Answer(char ch)
        {
            if (ch == 'A' || ch == 'a' || ch == 'B' || ch == 'b' || ch == 'C' || ch == 'c' || ch == 'd' || ch == 'D')
                return true;
            else
                return false;
        }
    }
}
