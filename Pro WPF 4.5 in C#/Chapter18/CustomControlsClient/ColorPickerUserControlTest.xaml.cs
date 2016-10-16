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

namespace CustomControlsClient
{
    /// <summary>
    /// Interaction logic for ColorPickerUserControlTest.xaml
    /// </summary>

    public partial class ColorPickerUserControlTest : System.Windows.Window
    {

        public ColorPickerUserControlTest()
        {
            InitializeComponent();
        }

        private void cmdGet_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(colorPicker.Color.ToString());
        }
        private void cmdSet_Click(object sender, RoutedEventArgs e)
        {
            colorPicker.Color = Colors.Beige;
        }

        private void colorPicker_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {            
            if (lblColor!=null) lblColor.Text = "The new color is " + e.NewValue.ToString();
        }

    }
}