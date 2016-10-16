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

namespace DrawingIn3D
{
    /// <summary>
    /// Interaction logic for ElementsIn3D.xaml
    /// </summary>

    public partial class ElementsIn3D : System.Windows.Window
    {

        public ElementsIn3D()
        {
            InitializeComponent();
        }
        private void cmd_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button clicked.");
        }
    }
}