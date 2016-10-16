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
    /// Interaction logic for FilterCollection.xaml
    /// </summary>

    public partial class GroupList : System.Windows.Window
    {

        public GroupList()
        {
            InitializeComponent();
        }


        private ICollection<Product> products;

        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            products = App.StoreDb.GetProducts();
            lstProducts.ItemsSource = products;

            ICollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("CategoryName", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("ModelName", ListSortDirection.Ascending));

            view.GroupDescriptions.Add(new PropertyGroupDescription("CategoryName"));

 
        }

      
    }

   

}

