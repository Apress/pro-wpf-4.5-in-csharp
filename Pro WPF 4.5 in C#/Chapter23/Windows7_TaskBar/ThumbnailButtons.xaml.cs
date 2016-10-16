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

namespace Windows7_TaskBar
{
    /// <summary>
    /// Interaction logic for ThumbnailButtons.xaml
    /// </summary>
    public partial class ThumbnailButtons : Window
    {
        public ThumbnailButtons()
        {
            InitializeComponent();
        }

        private void cmdPlay_Click(object sender, EventArgs e)
        {
            taskBarItem.ProgressState = System.Windows.Shell.TaskbarItemProgressState.Indeterminate;
            taskBarItem.Overlay = new BitmapImage(
  new Uri("pack://application:,,,/play.png"));
        }

        private void cmdPause_Click(object sender, EventArgs e)
        {
            taskBarItem.ProgressState = System.Windows.Shell.TaskbarItemProgressState.None;
            taskBarItem.Overlay = new BitmapImage(
  new Uri("pack://application:,,,/pause.png"));
        }

        
    }
}
