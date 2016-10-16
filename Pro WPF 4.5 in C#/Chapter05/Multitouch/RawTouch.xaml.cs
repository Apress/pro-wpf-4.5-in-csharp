using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Multitouch
{
    /// <summary>
    /// Interaction logic for RawTouch.xaml
    /// </summary>
    public partial class RawTouch : Window
    {
        public RawTouch()
        {
            InitializeComponent();
        }

        // Store the active ellipses, each of which corresponds to a place the user is currently touching down.
        private Dictionary<int, Ellipse> movingEllipses = new Dictionary<int, Ellipse>();       

        private void canvas_TouchDown(object sender, TouchEventArgs e)
        {
            // Create an ellipse to draw at the new touch-down point.
            Ellipse ellipse;
            ellipse = new Ellipse();
            ellipse.Width = 30;
            ellipse.Height = 30;
            ellipse.Stroke = Brushes.White;
            ellipse.Fill = Brushes.Green;

            // Position the ellipse at the touch-down point.
            TouchPoint touchPoint = e.GetTouchPoint(canvas);
            Canvas.SetTop(ellipse, touchPoint.Bounds.Top);
            Canvas.SetLeft(ellipse, touchPoint.Bounds.Left);

            // Store the ellipse in the active collection.
            movingEllipses[e.TouchDevice.Id] = ellipse;

            // Add the ellipse to the Canvas.
            canvas.Children.Add(ellipse);
        }

        private void canvas_TouchMove(object sender, TouchEventArgs e)
        {
            // Get the ellipse that corresponds to the current touch-down.
            Ellipse ellipse = movingEllipses[e.TouchDevice.Id];

            // Move it to the new touch-down point.
            TouchPoint touchPoint = e.GetTouchPoint(canvas);
            Canvas.SetTop(ellipse, touchPoint.Bounds.Top);
            Canvas.SetLeft(ellipse, touchPoint.Bounds.Left);
        }

        private void canvas_TouchUp(object sender, TouchEventArgs e)
        {
            // Remove the ellipse from the collection.
            movingEllipses.Remove(e.TouchDevice.Id);
            // (You could also, optionally, remove the ellipse from the Canvas.)
        }
    }
}
