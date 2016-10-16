using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Windows
{
    /// <summary>
    /// Interaction logic for WindowOwnership.xaml
    /// </summary>

    public partial class WindowOwnership : System.Windows.Window
    {

        public WindowOwnership()
        {
            InitializeComponent();
        }

        private void cmdCreate_Click(object sender, RoutedEventArgs e)
        {
            WindowOwnership win = new WindowOwnership();
            win.Owner = this;
            win.Title = "Owned Window";
            win.Height = this.Height/2;
            win.Width = this.Width/2;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.Show();
        }
    }
}