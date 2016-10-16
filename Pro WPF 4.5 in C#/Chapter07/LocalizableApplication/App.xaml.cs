using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Threading;
using System.Globalization;

namespace LocalizableApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : System.Windows.Application
    {
        public App()
        {
            // Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");

        }

    }
}