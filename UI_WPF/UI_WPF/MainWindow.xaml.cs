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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Scanner;
using OMRSoft;
using XMLRead;
namespace UI_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Sheet sheet = null;
        public string file = "";
        public MainWindow()
        {
            InitializeComponent();
            
            Worker.GetInfo();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = Worker.templates_dir;
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";
            dlg.Filter = "XML Files (*.xml)|*.xml";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            string filename = "";
            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                filename = dlg.FileName;
                TextBox.Text = filename;
                
            }
            Select_DPI new_window = new Select_DPI();
            new_window.ShowDialog();
            sheet = new Sheet(filename);
            lbl_id.Content = sheet.id;
            lbl_choices.Content = sheet.choice;
            lbl_questions.Content = sheet.questions;

        }

        private void btn_scan_Click(object sender, RoutedEventArgs e)
        {
            bool scanner_flag = false;
            Scanner.Scanner scanner = null;
            try
            {
                scanner = new Scanner.Scanner();
                
            }
            catch (Exception expcep)
            {
                scanner_flag = true;
                MessageBox.Show(" Scanner has not been detected. Please turn on your scanner and connect to the system and make sure it has been detected by Windows.\n The application will now shut down", "Scanner not detected.",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            if (scanner_flag == true)
            {
                Application.Current.Shutdown();
            }
            else
            {
                scanner.scan(XMLRead.Scanner_DPI.dpi_value);
                file = Worker.scanned_img_dir + "Scan_" + Worker.scanned_image_index + ".jpg";
                Worker.scanned_image_index++;
                scanner.save(file);
                preview_window.Source = new BitmapImage(new Uri(file));
            }
        }

        private void btn_process_Click(object sender, RoutedEventArgs e)
        {
            
            OMRSoft.OMRSoft obj = new OMRSoft.OMRSoft(file);

            obj.PreProcess();
            obj.blob_detect();
            obj.generate_results(sheet);
            
            Save_To_DB__Single_ new_window = new Save_To_DB__Single_(obj, file);
            new_window.ShowDialog();

        }

        private void SingleScan_Closed(object sender, EventArgs e)
        {
            
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Worker.Cleanup();
            Application.Current.Shutdown();
        }

       
    }
}
