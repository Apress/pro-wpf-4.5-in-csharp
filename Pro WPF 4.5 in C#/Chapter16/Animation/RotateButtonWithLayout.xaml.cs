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

namespace Animation
{
    /// <summary>
    /// Interaction logic for RotateButtonWithLayout.xaml
    /// </summary>

    public partial class RotateButtonWithLayout : System.Windows.Window
    {

        public RotateButtonWithLayout()
        {
            InitializeComponent();
        }

        private void cmd_Clicked(object sender, RoutedEventArgs e)
        {
            lbl.Text = "You clicked: " + ((Button)e.OriginalSource).Content;
        }

    }
}