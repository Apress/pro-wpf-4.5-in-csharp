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
using System.Windows.Xps.Packaging;
using System.IO;

namespace LayoutPanels
{
    /// <summary>
    /// Interaction logic for ModularContent.xaml
    /// </summary>

    public partial class ModularContent : System.Windows.Window
    {

        public ModularContent()
        {
            InitializeComponent();

            AddHandler(CheckBox.CheckedEvent, new RoutedEventHandler(chk_Checked));
            AddHandler(CheckBox.UncheckedEvent, new RoutedEventHandler(chk_Unchecked));            
        }

        private void chk_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chk = (CheckBox)e.OriginalSource;
            DependencyObject obj = LogicalTreeHelper.FindLogicalNode(this, chk.Content.ToString());
            ((FrameworkElement)obj).Visibility = Visibility.Visible;
        }

        private void chk_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chk = (CheckBox)e.OriginalSource;
            DependencyObject obj = LogicalTreeHelper.FindLogicalNode(this, chk.Content.ToString());
            ((FrameworkElement)obj).Visibility = Visibility.Collapsed;
        }
    }
}