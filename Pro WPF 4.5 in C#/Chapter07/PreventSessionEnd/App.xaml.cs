using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Windows.Threading;

namespace PreventSessionEnd
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        private bool unsavedData = false;
        public bool UnsavedData
        {
            get { return unsavedData; }
            set { unsavedData = value; }
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            UnsavedData = true;
        }

        protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
        {
            base.OnSessionEnding(e);

            if (UnsavedData)
            {
                e.Cancel = true;
                MessageBox.Show("The application attempted to close as a result of " +
                    e.ReasonSessionEnding.ToString() +
                    ". This is not allowed, as you have unsaved data.");
            }
        }

        private void App_DispatcherUnhandledException(object sender,
            DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled " + e.Exception.GetType().ToString() + 
                " exception was caught and ignored.");
            e.Handled = true;
        }
    }
}