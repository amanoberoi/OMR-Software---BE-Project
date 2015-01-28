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
using System.Data;
namespace UI_WPF
{
    /// <summary>
    /// Interaction logic for Database.xaml
    /// </summary>
    public partial class Database : Window
    {
        public Database(string dept, string year)
        {
            
            InitializeComponent();
            string SQL = "SELECT * FROM " + dept + " Where year='" + year+ "';";
            SQLiteCommand cmd = new SQLiteCommand(SQL, Worker.database_connection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            this.datagrid.DataContext = ds.Tables[0].DefaultView;
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
