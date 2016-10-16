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
    /// Interaction logic for Manipulations.xaml
    /// </summary>
    public partial class Manipulations : Window
    {
        public Manipulations()
        {
            InitializeComponent();
        }

        private void image_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            // Set the container (used for coordinates.)
            e.ManipulationContainer = canvas;

            // Choose what manipulations to allow.
            e.Mode = ManipulationModes.All;
        }

        private void image_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            // Get the image that's being manipulated.            
            FrameworkElement element = (FrameworkElement)e.Source;

            // Use the matrix to manipulate the element.
            Matrix matrix = ((MatrixTransform)element.RenderTransform).Matrix;

            var deltaManipulation = e.DeltaManipulation;
            // Find the old center, and apply the old manipulations.
            Point center = new Point(element.ActualWidth / 2, element.ActualHeight / 2);
            center = matrix.Transform(center);

            // Apply zoom manipulations.
            matrix.ScaleAt(deltaManipulation.Scale.X, deltaManipulation.Scale.Y, center.X, center.Y);

            // Apply rotation manipulations.
            matrix.RotateAt(e.DeltaManipulation.Rotation, center.X, center.Y);

            // Apply panning.
            matrix.Translate(e.DeltaManipulation.Translation.X, e.DeltaManipulation.Translation.Y);

            // Set the final matrix.
            ((MatrixTransform)element.RenderTransform).Matrix = matrix;

        }
    }


}
