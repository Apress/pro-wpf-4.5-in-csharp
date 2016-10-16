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
    /// Interaction logic for CustomListViewTest.xaml
    /// </summary>

    public partial class CustomListViewTest : System.Windows.Window
    {
        public CustomListViewTest()
        {
            InitializeComponent();

            lstProducts.ItemsSource = App.StoreDb.GetProducts();
            
        }
        private void lstView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)lstView.SelectedItem;
            lstProducts.View = (ViewBase)this.FindResource(selectedItem.Content);
        }
    }
}