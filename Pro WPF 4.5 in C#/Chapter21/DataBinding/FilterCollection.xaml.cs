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

    public partial class FilterCollection : System.Windows.Window
    {

        public FilterCollection()
        {
            InitializeComponent();
        }


        private ICollection<Product> products;

        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
            products = App.StoreDb.GetProducts();
            lstProducts.ItemsSource = products;

            ICollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource);
            
            view.SortDescriptions.Add(new SortDescription("ModelName", ListSortDirection.Ascending));

            ListCollectionView lcview = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;
            // Now if you edit and reduce the price (below the filter condition) the record will disappear automatically.
            lcview.IsLiveFiltering = true;
            lcview.LiveFilteringProperties.Add("UnitCost");

            //view.GroupDescriptions.Add(new PropertyGroupDescription("CategoryName"));

            //ListCollectionView view = (ListCollectionView)CollectionViewSource.GetDefaultView(lstProducts.ItemsSource);
            //view.CustomSort = new SortByModelNameLength();

        }

        private void cmdFilter_Click(object sender, RoutedEventArgs e)
        {
            decimal minimumPrice;
            if (Decimal.TryParse(txtMinPrice.Text, out minimumPrice))
            {
                ListCollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;

                if (view != null)
                {
                    filterer = new ProductByPriceFilterer(minimumPrice);
                    view.Filter = new Predicate<object>(filterer.FilterItem);
                    view.Refresh();
                }
            }
        }               

        private void cmdRemoveFilter_Click(object sender, RoutedEventArgs e)
        {
            ListCollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;
            if (view != null)
            {
                view.Filter = null;
            }
        }

        private ProductByPriceFilterer filterer;

        private void txtMinPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListCollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;
            if (view != null)
            {                
                decimal minimumPrice;
                if (Decimal.TryParse(txtMinPrice.Text, out minimumPrice) && (filterer != null))
                {
                    filterer.MinimumPrice = minimumPrice;
                    //view.Refresh();
                }
            }
        }
    }

    public class ProductByPriceFilterer
    {
        public decimal MinimumPrice
        {
            get;
            set;
        }

        public ProductByPriceFilterer(decimal minimumPrice)
        {
            MinimumPrice = minimumPrice;
        }

        public bool FilterItem(Object item)
        {
            Product product = item as Product;
            if (product != null)
            {
                if (product.UnitCost > MinimumPrice)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class SortByModelNameLength : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            Product productX = (Product)x;
            Product productY = (Product)y;
            return productX.ModelName.Length.CompareTo(productY.ModelName.Length);
        }
    }

}

