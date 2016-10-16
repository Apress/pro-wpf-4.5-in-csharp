using System;
using System.Net;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using i=System.Windows.Interactivity;
using System.Windows.Interactivity;
using System.Windows.Controls.Primitives;
using System.Windows;

namespace CustomBehaviorsLibrary
{
    [DefaultTrigger(typeof(ButtonBase), typeof(i.EventTrigger), new object[] { "Click" })]
    [DefaultTrigger(typeof(Shape), typeof(i.EventTrigger), new object[] { "MouseEnter" })]
    [DefaultTrigger(typeof(UIElement), typeof(i.EventTrigger),
     new object[] { "MouseLeftButtonDown" })]
    public class PlaySoundAction : TriggerAction<FrameworkElement>
    {
        public static readonly DependencyProperty SourceProperty =
  DependencyProperty.Register("Source", typeof(Uri),
    typeof(PlaySoundAction), new PropertyMetadata(null));

        public Uri Source
        {
            get { return (Uri)GetValue(PlaySoundAction.SourceProperty); }
            set { SetValue(PlaySoundAction.SourceProperty, value); }
        }

        protected override void Invoke(object args)
        {
            // Find a place to insert the MediaElement.
            Panel container = FindContainer();

            if (container != null)
            {
                // Create and configure the MediaElement.
                MediaElement media = new MediaElement();
                media.Source = this.Source;

                // Hook up handlers that will clean up when playback finishes.
                media.MediaEnded += delegate
                {
                    container.Children.Remove(media);
                };

                media.MediaFailed += delegate
                {
                    container.Children.Remove(media);
                };

                // Add the MediaElement and begin playback.                
                container.Children.Add(media);
                
            }
        }

        private Panel FindContainer()
        {
            FrameworkElement element = this.AssociatedObject;

            // Search for some sort of panel where the MediaElement can be inserted.            
            while (element != null)
            {
                if (element is Panel) return (Panel)element;

                element = VisualTreeHelper.GetParent(element) as FrameworkElement;
            }
            return null;
        }

    }

}
