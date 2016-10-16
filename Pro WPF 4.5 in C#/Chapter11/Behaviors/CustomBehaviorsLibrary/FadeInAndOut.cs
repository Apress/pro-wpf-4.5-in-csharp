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
    public class FadeOutAction : TargetedTriggerAction<UIElement>
    {
        // The default fade out time is 2 seconds.
        public static readonly DependencyProperty DurationProperty =
          DependencyProperty.Register("Duration", typeof(TimeSpan),
            typeof(FadeOutAction), new PropertyMetadata(TimeSpan.FromSeconds(2)));

        public TimeSpan Duration
        {
            get { return (TimeSpan)GetValue(FadeOutAction.DurationProperty); }
            set { SetValue(FadeOutAction.DurationProperty, value); }
        }

        private Storyboard fadeStoryboard = new Storyboard();
        private DoubleAnimation fadeAnimation = new DoubleAnimation();

        public FadeOutAction()
        {
            fadeStoryboard.Children.Add(fadeAnimation);
        }

        protected override void Invoke(object args)
        {
            // Make sure the storyboard isn't already running.
            fadeStoryboard.Stop();
            
            // Set up the storyboard.            
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath("Opacity"));
            Storyboard.SetTarget(fadeAnimation, this.Target);            

            // Set up the animation.
            // It's important to do this at the last possible instant,
            // in case the value for the Duration property changes.
            fadeAnimation.To = 0;
            fadeAnimation.Duration = Duration;

            fadeStoryboard.Begin();
        }
    }

    public class FadeInAction : TargetedTriggerAction<UIElement>
    {
        // The default fade in is 0.5 seconds.
        public static readonly DependencyProperty DurationProperty =
          DependencyProperty.Register("Duration", typeof(TimeSpan),
            typeof(FadeInAction), new PropertyMetadata(TimeSpan.FromSeconds(0.5)));

        public TimeSpan Duration
        {
            get { return (TimeSpan)GetValue(FadeInAction.DurationProperty); }
            set { SetValue(FadeInAction.DurationProperty, value); }
        }

        private Storyboard fadeStoryboard = new Storyboard();
        private DoubleAnimation fadeAnimation = new DoubleAnimation();
                
        public FadeInAction()
        {
            fadeStoryboard.Children.Add(fadeAnimation);
        }

        protected override void Invoke(object args)
        {
            // Make sure the storyboard isn't already running.
            fadeStoryboard.Stop();

            // Set up the storyboard.                        
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath("Opacity"));
            Storyboard.SetTarget(fadeAnimation, this.Target);
            
            // Set up the animation.            
            fadeAnimation.To = 1;
            fadeAnimation.Duration = Duration;

            fadeStoryboard.Begin();
        }
    }

}
