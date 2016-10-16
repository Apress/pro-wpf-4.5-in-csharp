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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFWindowLibrary
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>

    public partial class UserControl1 : System.Windows.Controls.UserControl
    {

        public UserControl1()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello from WPF");
        }
    }
}