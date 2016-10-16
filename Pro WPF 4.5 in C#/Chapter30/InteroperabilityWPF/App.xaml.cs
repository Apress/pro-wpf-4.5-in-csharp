using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace InteroperabilityWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Raises the Startup event.
            base.OnStartup(e);

            System.Windows.Forms.Application.EnableVisualStyles();
        }
    }
}