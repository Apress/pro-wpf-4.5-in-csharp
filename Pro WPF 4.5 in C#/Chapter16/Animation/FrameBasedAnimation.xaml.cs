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

namespace Animation
{
    /// <summary>
    /// Interaction logic for FrameBasedAnimation.xaml
    /// </summary>

    public partial class FrameBasedAnimation : System.Windows.Window
    {

        public FrameBasedAnimation()
        {
            InitializeComponent();
        }

        private bool rendering = false;
        private void cmdStart_Clicked(object sender, RoutedEventArgs e)
        {
            if (!rendering)
            {
                ellipses.Clear();
                canvas.Children.Clear();

                CompositionTarget.Rendering += RenderFrame;
                rendering = true;
            }
        }
        private void cmdStop_Clicked(object sender, RoutedEventArgs e)
        {
            StopRendering();
        }

        private void StopRendering()
        {
            CompositionTarget.Rendering -= RenderFrame;
            rendering = false;            
        }
                
        private List<EllipseInfo> ellipses = new List<EllipseInfo>();
        
        private double accelerationY = 0.1;
        private int minStartingSpeed = 1;
        private int maxStartingSpeed = 50;
        private double speedRatio = 0.1;
        private int minEllipses = 20;
        private int maxEllipses = 100;        
        private int ellipseRadius = 10;
            
        private void RenderFrame(object sender, EventArgs e)
        {
            if (ellipses.Count == 0)
            {
                // Animation just started. Create the ellipses.
                int halfCanvasWidth = (int)canvas.ActualWidth / 2;                
                
                Random rand = new Random();
                int ellipseCount = rand.Next(minEllipses, maxEllipses+1);
                for (int i = 0; i < ellipseCount; i++)
                {
                    Ellipse ellipse = new Ellipse();
                    ellipse.Fill = Brushes.LimeGreen;
                    ellipse.Width = ellipseRadius;
                    ellipse.Height = ellipseRadius;
                    Canvas.SetLeft(ellipse, halfCanvasWidth + rand.Next(-halfCanvasWidth, halfCanvasWidth));
                    Canvas.SetTop(ellipse, 0);
                    canvas.Children.Add(ellipse);

                    EllipseInfo info = new EllipseInfo(ellipse, speedRatio * rand.Next(minStartingSpeed, maxStartingSpeed));
                    ellipses.Add(info);
                }
            }
            else
            {
                for (int i = ellipses.Count-1; i >= 0; i--)                
                {
                    EllipseInfo info = ellipses[i];
                    double top = Canvas.GetTop(info.Ellipse);
                    Canvas.SetTop(info.Ellipse, top + 1 * info.VelocityY);                    

                    if (top >= (canvas.ActualHeight - ellipseRadius*2 - 10))
                    {
                        // This circle has reached the bottom.
                        // Stop animating it.
                        ellipses.Remove(info);
                    }
                    else
                    {
                        // Increase the velocity.
                        info.VelocityY += accelerationY;
                    }

                    if (ellipses.Count == 0)
                    {
                        // End the animation.
                        // There's no reason to keep calling this method
                        // if it has no work to do.
                        StopRendering();
                    }
                }
            }
        }
    }

    public class EllipseInfo
    {        
        public Ellipse Ellipse
        {
            get; set;
        }
                
        public double VelocityY
        {
            get; set;
        }

        public EllipseInfo(Ellipse ellipse, double velocityY)
        {
            VelocityY = velocityY;
            Ellipse = ellipse;
        }
    }
}