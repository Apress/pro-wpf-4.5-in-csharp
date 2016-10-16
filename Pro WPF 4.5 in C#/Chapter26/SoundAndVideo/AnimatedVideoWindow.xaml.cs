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
    /// Interaction logic for AnimatedVideoWindow.xaml
    /// </summary>

    public partial class AnimatedVideoWindow : System.Windows.Window
    {

        public AnimatedVideoWindow()
        {
            InitializeComponent();
        }

        private void cmdPlayCode_Click(object sender, RoutedEventArgs e)
        {
            // Create the MediaPlayer.
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri("test.mpg", UriKind.Relative));

            // Create the VideoDrawing.
            VideoDrawing videoDrawing = new VideoDrawing();
            videoDrawing.Rect = new Rect(150, 0, 100, 100);
            videoDrawing.Player = player;

            // Assign the DrawingBrush.
            DrawingBrush brush = new DrawingBrush(videoDrawing);
            this.Background = brush;

            // Start playback.
            player.Play();

        }
    }
}