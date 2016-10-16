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

namespace ControlTemplates
{
    /// <summary>
    /// Interaction logic for SimpleCustomButton.xaml
    /// </summary>

    public partial class GradientButtonTest : System.Windows.Window
    {

        public GradientButtonTest()
        {
            InitializeComponent();
        }

        private void Clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You clicked " + ((Button)sender).Name);
        }

        private void chkGreen_Checked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri(
              "Resources/GradientButtonVariant.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries[0] = resourceDictionary;                
        }

        private void chkGreen_Unchecked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri(
              "Resources/GradientButton.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries[0] = resourceDictionary;                
        }
    }
}