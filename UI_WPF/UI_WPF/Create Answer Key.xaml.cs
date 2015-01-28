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
using System.IO;
namespace UI_WPF
{
    /// <summary>
    /// Interaction logic for Create_Answer_Key.xaml
    /// </summary>
    public partial class Create_Answer_Key : Window
    {
        static char[] answers = null;
        public Create_Answer_Key()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int total_questions = Convert.ToInt16(this.txt_total_questions.Text);
            Worker.set_answer_key = new char[total_questions];
            Get_Answer[] get_answer = new Get_Answer[total_questions];
            for (int i = 0; i < total_questions; ++i)
            {
                get_answer[i] = new Get_Answer(ref i);
                
                get_answer[i].ShowDialog();

                this.listview_anskey.Items.Add((i+1).ToString() + "     " + Worker.set_answer_key[i].ToString());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string filename = Worker.answer_key_dir+ txt_filename.Text;
            FileStream fs = new FileStream(filename, FileMode.Create);
            fs.Close();
            
            using (StreamWriter sr = new StreamWriter(filename))
            {
                sr.WriteLine(txt_total_questions.Text.ToString());
                for (int i = 0; i < Worker.set_answer_key.Length; ++i)
                {
                    sr.WriteLine(Worker.set_answer_key[i].ToString());
                }
            }
            this.Close();
        }
    }
}
