using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NonCompiledXaml
{
    public class Program : Application
    {
        [STAThread()]
        static void Main()
        {
            // Create a program that will show two different windows,
            // and will wait until both are closed before ending.
            Program app = new Program();
            app.ShutdownMode = ShutdownMode.OnLastWindowClose;

            // First approach: window with XAML content.
            Window1 window1 = new Window1("Window1.xaml");
            window1.Show();

            // Second approach: XAML for complete window.            
            Xaml2009Window window2 = Xaml2009Window.LoadWindowFromXaml("Xaml2009.xaml");
            window2.Show();
            
            app.Run();
        }
    }
}
