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
    /// Interaction logic for AnswerKey.xaml
    /// </summary>
    public partial class AnswerKey : Window
    {
        public AnswerKey()
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

        private void btn_new_anskey_Click(object sender, RoutedEventArgs e)
        {
            Create_Answer_Key new_form = new Create_Answer_Key();
            new_form.ShowDialog();
        }

        private void btn_select_anskey_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = Worker.answer_key_dir;

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";
            dlg.Filter = "All Files (*.*)|*.*";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            string filename = "";
            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                filename = dlg.FileName;
            }
            
            Worker.answer_key = new OMRSoft.AnswerKey(filename);
            Worker.answer_key_path = filename;   
        }

    }
}
