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
using System.Windows.Media.Animation;

namespace SoundAndVideo
{
    /// <summary>
    /// Interaction logic for CodePlayback.xaml
    /// </summary>

    public partial class CodePlayback : System.Windows.Window
    {

        public CodePlayback()
        {
            InitializeComponent();
            
            
        }

        private void sliderSpeed_ValueChanged(object sender, RoutedEventArgs e)
        {
             media.SpeedRatio = ((Slider)sender).Value;
        }

        private void cmdPlay_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
        }
        private void cmdPause_Click(object sender, RoutedEventArgs e)
        {
            media.Pause();
        }
        private void cmdStop_Click(object sender, RoutedEventArgs e)
        {            
            media.Stop();
            media.SpeedRatio = 1;
        }
        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            sliderPosition.Maximum = media.NaturalDuration.TimeSpan.TotalSeconds;
        }
        private void sliderPosition_ValueChanged(object sender, RoutedEventArgs e)
        {
            media.Pause();
            media.Position = TimeSpan.FromSeconds(sliderPosition.Value);
            media.Play();
        }

           
      
      
    }
}