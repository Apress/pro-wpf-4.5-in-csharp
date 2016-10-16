using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Shell;
using System.IO;
using System.Reflection;

namespace JumpListApplicationTask
{
    public class Startup
    {
        [STAThread]
        public static void Main(string[] args)
        {            
            JumpListApplicationTaskWrapper wrapper = new JumpListApplicationTaskWrapper();
            wrapper.Run(args);           
        }
    }

    public class JumpListApplicationTaskWrapper : 
        Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
    {        
        public JumpListApplicationTaskWrapper()
        {
            // Enable single-instance mode.
            this.IsSingleInstance = true;
        }

        // Create the WPF application class.
        private WpfApp app;
        protected override bool OnStartup(
            Microsoft.VisualBasic.ApplicationServices.StartupEventArgs e)
        {           
            app = new WpfApp();
            app.Run();

            return false;
        }

        // Direct multiple instances
        protected override void OnStartupNextInstance(
            Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs e)
        {
            if (e.CommandLine.Count > 0)
            {                
                app.ProcessMessage(e.CommandLine[0]);
            }
        }
    }

    public class WpfApp : System.Windows.Application
    {
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            base.OnStartup(e);

            // Retrieve the current jump list.
            JumpList jumpList = new JumpList();
            JumpList.SetJumpList(Application.Current, jumpList);

            // Add a new JumpPath for an application task.            
            JumpTask jumpTask = new JumpTask();
            jumpTask.CustomCategory = "Tasks";
            jumpTask.Title = "Do Something";
            jumpTask.ApplicationPath = Assembly.GetExecutingAssembly().Location;
            jumpTask.IconResourcePath = jumpTask.ApplicationPath;
            jumpTask.Arguments = "@#StartOrder";
            jumpList.JumpItems.Add(jumpTask);         

            // Update the jump list.
            jumpList.Apply();

            // Load the main window.
            Window1 win = new Window1();
            win.Show();
        }               

        public void ProcessMessage(string message)
        {
            MessageBox.Show("Message " + message + " received.");
        }
    }   
}
