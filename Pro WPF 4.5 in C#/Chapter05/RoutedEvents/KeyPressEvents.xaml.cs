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
    /// Interaction logic for KeyPressEvents.xaml
    /// </summary>

    public partial class KeyPressEvents : System.Windows.Window
    {

        public KeyPressEvents()
        {
            InitializeComponent();
        }
                
        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if ((bool)chkIgnoreRepeat.IsChecked && e.IsRepeat) return;
            
            string message = //"At: " + e.Timestamp.ToString() +
                "Event: " + e.RoutedEvent + " " +
                " Key: " + e.Key;
            lstMessages.Items.Add(message);            
        }

        private void TextInput(object sender, TextCompositionEventArgs e)
        {
            string message = //"At: " + e.Timestamp.ToString() +
                "Event: " + e.RoutedEvent + " " +
                " Text: " + e.Text;
            lstMessages.Items.Add(message);
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            string message =
                "Event: " + e.RoutedEvent;
            lstMessages.Items.Add(message);
        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {            
            lstMessages.Items.Clear();
        }
    }
}