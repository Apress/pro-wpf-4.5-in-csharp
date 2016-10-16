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

namespace RoutedEvents
{
    /// <summary>
    /// Interaction logic for NoNumbers.xaml
    /// </summary>

    public partial class OnlyNumbers : System.Windows.Window
    {

        public OnlyNumbers()
        {
            InitializeComponent();
        }

        private void pnl_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            short val;
            if (!Int16.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }            
        }

        private void pnl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

    }
}