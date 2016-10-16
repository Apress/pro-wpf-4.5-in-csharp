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
    /// Interaction logic for BindingGroupValidation.xaml
    /// </summary>
    public partial class BindingGroupValidation : Window
    {
        public BindingGroupValidation()
        {
            InitializeComponent();
        }

        private ICollection<Product> products;

        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            products = App.StoreDb.GetProducts();
            lstProducts.ItemsSource = products;
        }

        private void cmdUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            // Make sure update has taken place.
            FocusManager.SetFocusedElement(this, (Button)sender);            
        }

        private void txt_LostFocus(object sender, RoutedEventArgs e)
        {
            productBindingGroup.CommitEdit();
        }

        private void lstProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            productBindingGroup.CommitEdit();
        }
    }
}
