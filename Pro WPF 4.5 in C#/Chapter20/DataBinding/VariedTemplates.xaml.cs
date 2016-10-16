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
using System.Collections.ObjectModel;
using StoreDatabase;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for DataTemplateList.xaml
    /// </summary>

    public partial class VariedTemplates : System.Windows.Window
    {

        public VariedTemplates()
        {
            InitializeComponent();
        }

        private ICollection<Product> products;

        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            products = App.StoreDb.GetProducts();
            lstProducts.ItemsSource = products;
        }

        private void cmdApplyChange_Click(object sender, RoutedEventArgs e)
        {
            ((ObservableCollection<Product>)products)[1].CategoryName = "Travel";
            DataTemplateSelector selector = lstProducts.ItemTemplateSelector;
            lstProducts.ItemTemplateSelector = null;
            lstProducts.ItemTemplateSelector = selector;
        }
    }
}