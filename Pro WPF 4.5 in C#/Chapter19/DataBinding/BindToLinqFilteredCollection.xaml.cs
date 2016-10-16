using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StoreDatabase;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for BindToLinqFilteredCollection.xaml
    /// </summary>
    public partial class BindToLinqFilteredCollection : Window
    {
        public BindToLinqFilteredCollection()
        {
            InitializeComponent();
        }

        private ICollection<Product> products;

        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {            
            products = App.StoreDb.GetProductsFilteredWithLinq(Decimal.Parse(txtMinimumCost.Text));
            lstProducts.ItemsSource = products;
        }

        private void cmdDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            products.Remove((Product)lstProducts.SelectedItem);
        }

        private void cmdAddProduct_Click(object sender, RoutedEventArgs e)
        {
            products.Add(new Product("00000", "?", 0, "?"));
        }

        private bool isDirty = false;
        private void txt_TextChanged(object sender, RoutedEventArgs e)
        {
            isDirty = true;
        }

        private void lstProducts_SelectionChanged(object sender, RoutedEventArgs e)
        {
            isDirty = false;
        }
    }
}
