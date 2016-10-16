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
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace BombDropper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            bombTimer.Tick += bombTimer_Tick;
        }

        private void canvasBackground_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            RectangleGeometry rect = new RectangleGeometry();
            rect.Rect = new Rect(0, 0, canvasBackground.ActualWidth, canvasBackground.ActualHeight);
            canvasBackground.Clip = rect;
        }

        // "Adjustments" happen periodically, increasing the speed of bomb
        // falling and shortening the time between bombs.
        private DateTime lastAdjustmentTime = DateTime.MinValue;

        // Perform an adjustment every 15 seconds.
        private double secondsBetweenAdjustments = 15;

        // Initially, bombs fall every 1.3 seconds, and hit the ground after 3.5 seconds.
        private double initialSecondsBetweenBombs = 1.3;
        private double initialSecondsToFall = 3.5;
        private double secondsBetweenBombs;
        private double secondsToFall;

        // After every adjustment, shave 0.1 seconds off both.
        private double secondsBetweenBombsReduction = 0.1;
        private double secondsToFallReduction = 0.1;

        // Make it possible to look up a storyboard based on a bomb.
        private Dictionary<Bomb, Storyboard> storyboards = new Dictionary<Bomb, Storyboard>();

        // Fires events on the user interface thread.
        private DispatcherTimer bombTimer = new DispatcherTimer();

        // Start the game.
        private void cmdStart_Click(object sender, RoutedEventArgs e)
        {
            cmdStart.IsEnabled = false;

            // Reset the game.
            droppedCount = 0;
            savedCount = 0;
            secondsBetweenBombs = initialSecondsBetweenBombs;
            secondsToFall = initialSecondsToFall;
            
            // Start bomb dropping events.            
            bombTimer.Interval = TimeSpan.FromSeconds(secondsBetweenBombs);
            bombTimer.Start();
        }

        // Drop a bomb.
        private void bombTimer_Tick(object sender, EventArgs e)
        {
            // Perform an "adjustment" when needed.
            if ((DateTime.Now.Subtract(lastAdjustmentTime).TotalSeconds >
                secondsBetweenAdjustments))
            {
                lastAdjustmentTime = DateTime.Now;
          
                secondsBetweenBombs -= secondsBetweenBombsReduction;
                secondsToFall -= secondsToFallReduction;

                // (Technically, you should check for 0 or negative values.
                // However, in practice these won't occur because the game will
                // always end first.)
                
                // Set the timer to drop the next bomb at the appropriate time.
                bombTimer.Interval = TimeSpan.FromSeconds(secondsBetweenBombs);

                // Update the status message.
                lblRate.Text = String.Format("A bomb is released every {0} seconds.",
                    secondsBetweenBombs);
                lblSpeed.Text = String.Format("Each bomb takes {0} seconds to fall.",
                    secondsToFall);
            }

            // Create the bomb.
            Bomb bomb = new Bomb();
            bomb.IsFalling = true;

            // Position the bomb.            
            Random random = new Random();      
            bomb.SetValue(Canvas.LeftProperty, 
                (double)(random.Next(0, (int)(canvasBackground.ActualWidth - 50))));
            bomb.SetValue(Canvas.TopProperty, -100.0);

            // Attach mouse click event (for defusing the bomb).
            bomb.MouseLeftButtonDown += bomb_MouseLeftButtonDown;
                       
            // Create the animation for the falling bomb.
            Storyboard storyboard = new Storyboard();
            DoubleAnimation fallAnimation = new DoubleAnimation();            
            fallAnimation.To = canvasBackground.ActualHeight;
            fallAnimation.Duration = TimeSpan.FromSeconds(secondsToFall);
            
            Storyboard.SetTarget(fallAnimation, bomb);            
            Storyboard.SetTargetProperty(fallAnimation, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(fallAnimation);

            // Create the animation for the bomb "wiggle."
            DoubleAnimation wiggleAnimation = new DoubleAnimation();            
            wiggleAnimation.To = 30;
            wiggleAnimation.Duration = TimeSpan.FromSeconds(0.2);
            wiggleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            wiggleAnimation.AutoReverse = true;
                        
            Storyboard.SetTarget(wiggleAnimation, ((TransformGroup)bomb.RenderTransform).Children[0]);
            Storyboard.SetTargetProperty(wiggleAnimation, new PropertyPath("Angle"));
            storyboard.Children.Add(wiggleAnimation);
                                                
            // Add the bomb to the Canvas.
            canvasBackground.Children.Add(bomb);

            // Add the storyboard to the tracking collection.            
            storyboards.Add(bomb, storyboard);

            // Configure and start the storyboard.
            storyboard.Duration = fallAnimation.Duration;
            storyboard.Completed += storyboard_Completed;
            storyboard.Begin();            
        }

        private void bomb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Get the bomb.
            Bomb bomb = (Bomb)sender;
            bomb.IsFalling = false;

            // Get the bomb's current position.
            Storyboard storyboard = storyboards[bomb];
            double currentTop = Canvas.GetTop(bomb);

            // Stop the bomb from falling.
            storyboard.Stop();

            // Reuse the existing storyboard, but with new animations.
            // Send the bomb on a new trajectory by animating Canvas.Top
            // and Canvas.Left.
            storyboard.Children.Clear();
            
            DoubleAnimation riseAnimation = new DoubleAnimation();
            riseAnimation.From = currentTop;
            riseAnimation.To = 0;
            riseAnimation.Duration = TimeSpan.FromSeconds(2);

            Storyboard.SetTarget(riseAnimation, bomb);
            Storyboard.SetTargetProperty(riseAnimation, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(riseAnimation);

            DoubleAnimation slideAnimation = new DoubleAnimation();
            double currentLeft = Canvas.GetLeft(bomb);
            // Throw the bomb off the closest side.
            if (currentLeft < canvasBackground.ActualWidth / 2)
            {
                slideAnimation.To = -100;
            }
            else
            {
                slideAnimation.To = canvasBackground.ActualWidth + 100;
            }
            slideAnimation.Duration = TimeSpan.FromSeconds(1);
            Storyboard.SetTarget(slideAnimation, bomb);
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("(Canvas.Left)"));
            storyboard.Children.Add(slideAnimation);

            // Start the new animation.
            storyboard.Duration = slideAnimation.Duration;
            storyboard.Begin();
        }

        // Keep track of how many are dropped and stopped.
        private int droppedCount = 0;
        private int savedCount = 0;

        // End the game at maxDropped.
        private int maxDropped = 5;

        private void storyboard_Completed(object sender, EventArgs e)
        {            
            ClockGroup clockGroup = (ClockGroup)sender;
            
            // Get the first animation in the storyboard, and use it to find the
            // bomb that's being animated.
            DoubleAnimation completedAnimation = (DoubleAnimation)clockGroup.Children[0].Timeline;            
            Bomb completedBomb = (Bomb)Storyboard.GetTarget(completedAnimation);
                        
            // Determine if a bomb fell or flew off the Canvas after being clicked.
            if (completedBomb.IsFalling)
            {
                droppedCount++;
            }
            else
            {
                savedCount++;
            }

            // Update the display.
            lblStatus.Text = String.Format("You have dropped {0} bombs and saved {1}.",
                droppedCount, savedCount);
                        
            // Check if it's game over.
            if (droppedCount >= maxDropped)
            {
                bombTimer.Stop();
                lblStatus.Text += "\r\n\r\nGame over.";

                // Find all the storyboards that are underway.
                foreach (KeyValuePair<Bomb, Storyboard> item in storyboards)
                {
                    Storyboard storyboard = item.Value;
                    Bomb bomb = item.Key;

                    storyboard.Stop();
                    canvasBackground.Children.Remove(bomb);
                }
                // Empty the tracking collection.
                storyboards.Clear();                

                // Allow the user to start a new game.
                cmdStart.IsEnabled = true;
            }
            else
            {                
                Storyboard storyboard = (Storyboard)clockGroup.Timeline;
                storyboard.Stop();
                                
                storyboards.Remove(completedBomb);
                canvasBackground.Children.Remove(completedBomb);
            }
        }

        

        
    }
}
