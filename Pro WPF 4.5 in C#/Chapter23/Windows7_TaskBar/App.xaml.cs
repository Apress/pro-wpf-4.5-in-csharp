using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Shell;
using System.IO;

namespace Windows7_TaskBar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Retrieve the current jump list.
            JumpList jumpList = new JumpList();
            JumpList.SetJumpList(Application.Current, jumpList);
                        
            // Add a new JumpPath for a file in the application folder.
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(path, "readme.txt");
            if (File.Exists(path))
            {
                JumpTask jumpTask = new JumpTask();
                jumpTask.CustomCategory = "Documentation";
                jumpTask.Title = "Read the readme.txt";
                jumpTask.ApplicationPath = @"c:\windows\notepad.exe";
                jumpTask.IconResourcePath = @"c:\windows\notepad.exe";
                jumpTask.Arguments = path;
                jumpList.JumpItems.Add(jumpTask);
            }
            
            // Update the jump list.
            jumpList.Apply();
        }
    }
}
