using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace UI_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Worker.GetInfo();
            Worker.database_connection.Open();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Worker.Cleanup();
        }
    }
}
