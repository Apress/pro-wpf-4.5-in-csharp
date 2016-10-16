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

namespace RoutedEvents
{
    /// <summary>
    /// Interaction logic for MousePosition.xaml
    /// </summary>

    public partial class MousePosition : System.Windows.Window
    {

        public MousePosition()
        {
            InitializeComponent();
        }

        
        private void cmdCapture_Click(object sender, RoutedEventArgs e)
        {
           this.AddHandler(
                  Mouse.LostMouseCaptureEvent,
                  new RoutedEventHandler(this.LostCapture));
                Mouse.Capture(rect);

                cmdCapture.Content = "[ Mouse is now captured ... ]";
        }

        private void MouseMoved(object sender, MouseEventArgs e)
        {
            Point pt = e.GetPosition(this);
            lblInfo.Text = 
                String.Format("You are at ({0},{1}) in window coordinates",
                pt.X, pt.Y);            
        }

        private void LostCapture(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Lost capture");
            cmdCapture.Content = "Capture the Mouse";
        }
    }
}