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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for RadioButtonList.xaml
    /// </summary>

    public partial class RadioButtonList : System.Windows.Window
    {

        public RadioButtonList()
        {
            InitializeComponent();
                        
            lstProducts.ItemsSource = App.StoreDb.GetProducts();
        }

        private void cmdGetSelectedItem(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(lstProducts.SelectedItem.ToString());
        }
    }
}