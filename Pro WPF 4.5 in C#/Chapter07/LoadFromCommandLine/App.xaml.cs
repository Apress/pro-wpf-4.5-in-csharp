using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.IO;

namespace LoadFromCommandLine
{    
    public partial class App : Application
    {
        // The command-line argument is set through the Visual Studio
        // project properties (the Debug tab).
        private void App_Startup(object sender, StartupEventArgs e)
        {           
            // At this point, the main window has been created but not shown.
            FileViewer win = new FileViewer();

            if (e.Args.Length > 0)
            {
                string file = e.Args[0];
                if (File.Exists(file))
                {
                    // Configure the main window.                    
                    win.LoadFile(file);
                }
            }

            // This window will automatically be set as the Application.MainWindow.
            win.Show();
        }
    }
}
