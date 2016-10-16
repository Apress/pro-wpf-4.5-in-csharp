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
using System.Windows.Media.Media3D;

namespace DrawingIn3D
{
    /// <summary>
    /// Interaction logic for Materials.xaml
    /// </summary>

    public partial class Materials : System.Windows.Window
    {

        public Materials()
        {
            InitializeComponent();
        }
        private void chk_Click(object sender, RoutedEventArgs e)
        {
            materialsGroup.Children.Clear();
            if (chkBackground.IsChecked == true)
                rect.Visibility = Visibility.Visible;
            else
                rect.Visibility = Visibility.Hidden;

            if (chkDiffuse.IsChecked == true)
                materialsGroup.Children.Add((Material)FindResource("diffuse"));

            if (chkSpecular.IsChecked == true)
                materialsGroup.Children.Add((Material)FindResource("specular"));

            if (chkEmissive.IsChecked == true)
                materialsGroup.Children.Add((Material)FindResource("emissive"));
            
        }
    }
}