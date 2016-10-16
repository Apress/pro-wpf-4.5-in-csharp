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
    /// Interaction logic for DragAndDrop.xaml
    /// </summary>

    public partial class DragAndDrop : System.Windows.Window
    {

        public DragAndDrop()
        {
            InitializeComponent();
        }

        private void lblSource_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label lbl = (Label)sender;
            DragDrop.DoDragDrop(lbl, lbl.Content, DragDropEffects.Copy);
        }

        private void lblTarget_Drop(object sender, DragEventArgs e)
        {
            ((Label)sender).Content = e.Data.GetData(DataFormats.Text);
        }

        private void lblTarget_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;
        }

       

    }
}