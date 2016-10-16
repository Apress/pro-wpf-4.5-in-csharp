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
    /// Interaction logic for TunneledKeyPress.xaml
    /// </summary>

    public partial class TunneledKeyPress : System.Windows.Window
    {

        public TunneledKeyPress()
        {
            InitializeComponent();
        }

        protected int eventCounter = 0;

        private void SomeKeyPressed(object sender, RoutedEventArgs e)
        {
            eventCounter++;
            string message = "#" + eventCounter.ToString() + ":\r\n" +
                " Sender: " + sender.ToString() + "\r\n" +
                " Source: " + e.Source + "\r\n" +
                " Original Source: " + e.OriginalSource + "\r\n" +
                " Event: " + e.RoutedEvent;
            lstMessages.Items.Add(message);
            e.Handled = (bool)chkHandle.IsChecked;
        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            eventCounter = 0;
            lstMessages.Items.Clear();
        }
    }
}