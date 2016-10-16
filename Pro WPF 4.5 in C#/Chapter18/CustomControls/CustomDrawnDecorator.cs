using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CustomControls
{
    public class CustomDrawnDecorator : Decorator
    {
        static CustomDrawnDecorator()
        {
            CustomDrawnElement.BackgroundColorProperty.AddOwner(            
                typeof(CustomDrawnDecorator));
        }


        public Color BackgroundColor
        {
            get
            {
                return (Color)GetValue(CustomDrawnElement.BackgroundColorProperty);
            }
            set
            {
                SetValue(CustomDrawnElement.BackgroundColorProperty, value);
            }
        }

        private Brush GetForegroundBrush()
        {
            if (!IsMouseOver)
            {
                return new SolidColorBrush(BackgroundColor);
            }
            else
            {
                RadialGradientBrush brush = new RadialGradientBrush(Colors.White, BackgroundColor);
                Point absoluteGradientOrigin = Mouse.GetPosition(this);
                Point relativeGradientOrigin = new Point(
                    absoluteGradientOrigin.X / base.ActualWidth, absoluteGradientOrigin.Y / base.ActualHeight);

                brush.GradientOrigin = relativeGradientOrigin;
                brush.RadiusX = 0.2;
                brush.Center = relativeGradientOrigin;
                brush.Freeze();
                return brush;
            }
        }
        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            Rect bounds = new Rect(0, 0, base.ActualWidth, base.ActualHeight);
            dc.DrawRectangle(GetForegroundBrush(), null, bounds);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.InvalidateVisual();
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            this.InvalidateVisual();
        }

        protected override Size MeasureOverride(Size constraint)
        {
            UIElement child = this.Child;
            if (child != null)
            {
                child.Measure(constraint);
                return child.DesiredSize;
            }
            else
            {
                return new Size();
            }

        }
    }
}