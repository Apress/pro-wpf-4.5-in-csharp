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

namespace SoundAndVideo
{
    /// <summary>
    /// Interaction logic for Video.xaml
    /// </summary>

    public partial class Video : System.Windows.Window
    {

        public Video()
        {
            InitializeComponent();
            
        }

        private void cmdPlay_Click(object sender, RoutedEventArgs e)
        {
            video.Position = TimeSpan.Zero;
            video.Play();
        }

    }
}