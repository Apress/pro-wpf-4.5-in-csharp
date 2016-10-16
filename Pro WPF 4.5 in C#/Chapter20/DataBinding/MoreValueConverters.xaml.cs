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
using StoreDatabase;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MoreValueConverters.xaml
    /// </summary>

    public partial class MoreValueConverters : System.Windows.Window
    {

        public MoreValueConverters()
        {
            InitializeComponent();
        }

        private ICollection<Product> products;
        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            products = App.StoreDb.GetProducts();
            lstProducts.ItemsSource = products;
        }
    }
}