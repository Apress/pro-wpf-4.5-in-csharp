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

namespace Controls
{
    /// <summary>
    /// Interaction logic for TextBoxColumn.xaml
    /// </summary>

    public partial class ScrollableTextBoxColumn : System.Windows.Window
    {

        public ScrollableTextBoxColumn()
        {
            InitializeComponent();
        }

        private void LineUp(object sender, RoutedEventArgs e)
        {
            scroller.LineUp();
        }
        private void LineDown(object sender, RoutedEventArgs e)
        {
            scroller.LineDown();
        }
        private void PageUp(object sender, RoutedEventArgs e)
        {
            scroller.PageUp();
        }
        private void PageDown(object sender, RoutedEventArgs e)
        {
            scroller.PageDown();
        }
    }
}