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

namespace CustomControlsClient
{
    /// <summary>
    /// Interaction logic for FlipPanelTest.xaml
    /// </summary>
    public partial class FlipPanelTest : Window
    {
        public FlipPanelTest()
        {
            InitializeComponent();
        }

        private void cmdFlip_Click(object sender, RoutedEventArgs e)
        {
            panel.IsFlipped = !panel.IsFlipped;
        }
    }
}
