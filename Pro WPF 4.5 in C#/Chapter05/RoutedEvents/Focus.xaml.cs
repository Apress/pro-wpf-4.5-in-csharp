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
    /// Interaction logic for Focus.xaml
    /// </summary>

    public partial class Focus : System.Windows.Window
    {

        public Focus()
        {
            InitializeComponent();
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            cmdFocus.Focus();
        }
    }
}