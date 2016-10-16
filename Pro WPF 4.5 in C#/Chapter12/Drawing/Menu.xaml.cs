using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;


namespace Drawing
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Menu : Window
    {

        public Menu()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {            
            // Get the current button.
            Button cmd = (Button)e.OriginalSource;
                
            // Create an instance of the window named
            // by the current button.
            Type type = this.GetType();
            Assembly assembly = type.Assembly;                       
            Window win = (Window)assembly.CreateInstance(
                type.Namespace + "." + cmd.Content);

            // Show the window.
            win.ShowDialog();
        }
    }
}