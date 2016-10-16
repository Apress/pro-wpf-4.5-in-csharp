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
    /// Interaction logic for RoutedLabelClick.xaml
    /// </summary>

    public partial class BubbledLabelClick : System.Windows.Window
    {

        public BubbledLabelClick()
        {
            InitializeComponent();
        }

        protected int eventCounter = 0;

        private void SomethingClicked(object sender, RoutedEventArgs e)
        {            
            eventCounter++;
            string message = "#" + eventCounter.ToString() + ":\r\n" + 
                " Sender: " + sender.ToString() + "\r\n" +
                " Source: " + e.Source + "\r\n" +
                " Original Source: " + e.OriginalSource;
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