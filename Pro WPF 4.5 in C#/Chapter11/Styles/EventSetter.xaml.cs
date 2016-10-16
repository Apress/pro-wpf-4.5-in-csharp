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

namespace Styles
{
    /// <summary>
    /// Interaction logic for EventSetter.xaml
    /// </summary>

    public partial class EventSetter : System.Windows.Window
    {

        public EventSetter()
        {
            InitializeComponent();
        }

        private void element_MouseEnter(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
        }
        private void element_MouseLeave(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Background = null;
        }
    }
}