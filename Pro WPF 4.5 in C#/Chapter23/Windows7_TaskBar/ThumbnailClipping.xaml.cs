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

namespace Windows7_TaskBar
{
    /// <summary>
    /// Interaction logic for ThumbnailClipping.xaml
    /// </summary>
    public partial class ThumbnailClipping : Window
    {
        public ThumbnailClipping()
        {
            InitializeComponent();
        }

        private void cmdShrinkPreview_Click(object sender, RoutedEventArgs e)
        {
            // Find the position of the clicked button, in window coordinates.
            Button cmd = (Button)sender;
            Point locationFromWindow = cmd.TranslatePoint(new Point(0, 0), this);

            // Determine the width that should be added to every side.
            double left = locationFromWindow.X;
            double top = locationFromWindow.Y;
            double right = LayoutRoot.ActualWidth - cmd.ActualWidth - left;
            double bottom = LayoutRoot.ActualHeight - cmd.ActualHeight - top;
            
            // Apply the clipping.
            taskBarItem.ThumbnailClipMargin = new Thickness(left, top, right, bottom);
        }
    }
}
