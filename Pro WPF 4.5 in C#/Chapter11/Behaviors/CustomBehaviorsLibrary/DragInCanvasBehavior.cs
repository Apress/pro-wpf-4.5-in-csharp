using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Interactivity;

namespace CustomBehaviorsLibrary
{
    public class DragInCanvasBehavior : Behavior<UIElement>
    {
        private Canvas canvas;
        
        protected override void OnAttached()
        {
            base.OnAttached();                       

            // Hook up event handlers.            
            this.AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
            this.AssociatedObject.MouseMove += AssociatedObject_MouseMove;
            this.AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLeftButtonUp;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            // Detach event handlers.
            this.AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
            this.AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
            this.AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseLeftButtonUp;
        }

        // Keep track of when the element is being dragged.
        private bool isDragging = false;

        // When the element is clicked, record the exact position
        // where the click is made.
        private Point mouseOffset;

        private void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Find the canvas.
            if (canvas == null) canvas = VisualTreeHelper.GetParent(this.AssociatedObject) as Canvas;

            // Dragging mode begins.
            isDragging = true;

            // Get the position of the click relative to the element
            // (so the top-left corner of the element is (0,0).
            mouseOffset = e.GetPosition(AssociatedObject);

            // Capture the mouse. This way you'll keep receiveing
            // the MouseMove event even if the user jerks the mouse
            // off the element.
            AssociatedObject.CaptureMouse();
        }

        private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Get the position of the element relative to the Canvas.
                Point point = e.GetPosition(canvas);

                // Move the element.
                AssociatedObject.SetValue(Canvas.TopProperty, point.Y - mouseOffset.Y);
                AssociatedObject.SetValue(Canvas.LeftProperty, point.X - mouseOffset.X);
            }
        }

        private void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDragging)
            {
                AssociatedObject.ReleaseMouseCapture();
                isDragging = false;
            }
        }
    }
}
