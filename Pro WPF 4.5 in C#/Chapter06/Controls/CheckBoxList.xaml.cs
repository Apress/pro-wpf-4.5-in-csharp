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
    /// Interaction logic for ListBoxTest.xaml
    /// </summary>

    public partial class CheckBoxList : System.Windows.Window
    {

        public CheckBoxList()
        {
            InitializeComponent();
        }
        
        private void lst_SelectionChanged(object sender, RoutedEventArgs e)
        {
            // Select when checkbox portion is clicked (optional).
            if (e.OriginalSource is CheckBox)
            {
                lst.SelectedItem = e.OriginalSource;
            }
            
            if (lst.SelectedItem == null) return;
            txtSelection.Text = String.Format(                
                "You chose item at position {0}.\r\nChecked state is {1}.",
                lst.SelectedIndex,
                ((CheckBox)lst.SelectedItem).IsChecked);
        }

        private void cmd_CheckAllItems(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (CheckBox item in lst.Items)
            {
                if (item.IsChecked == true)
                {
                    sb.Append(
                        item.Content + " is checked.");
                    sb.Append("\r\n");                      
                }
            }
            txtSelection.Text = sb.ToString();
        }
    }
}