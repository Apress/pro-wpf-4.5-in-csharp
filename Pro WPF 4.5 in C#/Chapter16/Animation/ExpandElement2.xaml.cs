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
    /// Interaction logic for ExpandElement2.xaml
    /// </summary>

    public partial class ExpandElement2 : System.Windows.Window
    {

        public ExpandElement2()
        {
            InitializeComponent();
        }

        private void storyboardCompleted(object sender, EventArgs e)
        {
            rectangle.Visibility = Visibility.Collapsed;
        }

    }
}