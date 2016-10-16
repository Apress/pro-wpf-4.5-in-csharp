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

namespace Commands
{
    /// <summary>
    /// Interaction logic for TwoDocument.xaml
    /// </summary>

    public partial class TwoDocument : System.Windows.Window
    {

        public TwoDocument()
        {
            InitializeComponent();
        }

        private void SaveCommand(object sender, ExecutedRoutedEventArgs e)
        {            
            string text = ((TextBox)sender).Text;
            MessageBox.Show("About to save: " + text);
            isDirty[sender] = false;
        }

        private Dictionary<Object, bool> isDirty = new Dictionary<Object, bool>();
        private void txt_TextChanged(object sender, RoutedEventArgs e)
        {
            isDirty[sender] = true;
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (isDirty.ContainsKey(sender) && isDirty[sender] == true)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }             
        }
    }
}