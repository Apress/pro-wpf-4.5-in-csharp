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
using System.ComponentModel;
using StoreDatabase;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for GroupInRanges.xaml
    /// </summary>

    public partial class GroupInRanges : System.Windows.Window
    {

        public GroupInRanges()
        {
            InitializeComponent();
        }
        private ICollection<Product> products;

        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            products = App.StoreDb.GetProducts();
            CollectionViewSource viewSource = (CollectionViewSource)this.FindResource("GroupByRangeView");
            viewSource.Source = products;
            //lstProducts.ItemsSource = products;

            //ICollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource);
            //view.SortDescriptions.Add(new SortDescription("UnitCost", ListSortDirection.Ascending));
            //PriceRangeProductGrouper grouper = new PriceRangeProductGrouper();
            //grouper.GroupInterval = 50;
            //view.GroupDescriptions.Add(new PropertyGroupDescription("UnitCost", grouper));
        }
    }
}