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
using System.Media;
using System.ComponentModel;
using System.IO;
using System.Reflection;

namespace SoundAndVideo
{
    /// <summary>
    /// Interaction logic for SoundPlayerTest.xaml
    /// </summary>

    public partial class SoundPlayerTest : System.Windows.Window
    {

        public SoundPlayerTest()
        {
            InitializeComponent();
        }

        private void cmdPlayAudio_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.Stream = Properties.Resources.chimes;
            try
            {
                player.Load();
                player.PlaySync();
            }
            catch (System.IO.FileNotFoundException err)
            {
                // An error will occur here if the file can't be found.
            }
            catch (FormatException err)
            {
                // A FormatException will occur here if the file doesn't
                // contain valid WAV audio.
            }
        }

        private void cmdPlayAudioAsync_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.wav");
            try
            {
                player.Load();
                player.Play();
            }
            catch (System.IO.FileNotFoundException err)
            {
                // An error will occur here if the file can't be found.
            }
            catch (FormatException err)
            {
                // A FormatException will occur here if the file doesn't
                // contain valid WAV audio.
            }
        }

        private MediaPlayer player = new MediaPlayer();

        private void cmdPlayWithMediaPlayer_Click(object sender, RoutedEventArgs e)
        {            
            player.Open(new Uri("test.mp3", UriKind.Relative));
            player.Play();
        }

        private void window_Closed(object sender, EventArgs e)
        {
            player.Close();
        }
    }
}