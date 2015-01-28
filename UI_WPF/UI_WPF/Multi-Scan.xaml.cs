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
using System.Drawing;
using XMLRead;
namespace UI_WPF
{
    /// <summary>
    /// Interaction logic for Multi_Scan.xaml
    /// </summary>
    public partial class Multi_Scan : Window
    {
        List<string> scanned_files;
        public Sheet sheet = null;
        public Multi_Scan()
        {
            InitializeComponent();
            this.lbl_total_sheets.Visibility = System.Windows.Visibility.Hidden;

        }

        private void btn_scan_Click(object sender, RoutedEventArgs e)
        {
            int total_sheets = Convert.ToInt16(this.txt_sheet_count.Text);
            scanned_files = new List<string>(total_sheets);
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
                
                List<OMRSoft.OMRSoft> sheets = new List<OMRSoft.OMRSoft>(total_sheets);
                for (int i = 0; i < total_sheets; ++i)
                {
                    MessageBox.Show("Place Sheet on the scanner and close the lid.", "Next Sheet", MessageBoxButton.OK, MessageBoxImage.Information);
                    string file = Worker.scanned_img_dir + "/Scan_" + Worker.scanned_image_index.ToString() + ".jpg";
                    Worker.scanned_image_index++;

                    Scanner.Scanner scanner1 = new Scanner.Scanner();
                    scanner1.scan(XMLRead.Scanner_DPI.dpi_value);
                    scanner1.save(file);
                    scanned_files.Add(file);
                    preview_window.Source = new BitmapImage( new Uri(file));
                    OMRSoft.OMRSoft sh = new OMRSoft.OMRSoft(file);
                    sh.PreProcess();
                    sh.blob_detect();
                    sh.generate_results(sheet);
                    sheets.Add(sh);
                    lbl_scanned_count.Content = (i+1).ToString();
                }

                Save_to_DB new_window = new Save_to_DB(sheets, scanned_files, total_sheets);
                new_window.ShowDialog();
            }
            

            
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

        private void btn_browse_Click(object sender, RoutedEventArgs e)
        {
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
                txt_browse.Text = filename;
                
            }
            Select_DPI new_window = new Select_DPI();
            new_window.ShowDialog();
            sheet = new Sheet(filename);
            lbl_id.Content = sheet.id;
            lbl_choices.Content = sheet.choice;
            lbl_questions.Content = sheet.questions;

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Worker.Cleanup();
            Application.Current.Shutdown();
        }

    }
}
