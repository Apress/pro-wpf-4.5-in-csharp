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
using System.ComponentModel;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for DataGridGrouping.xaml
    /// </summary>
    public partial class DataGridGrouping : Window
    {
        public DataGridGrouping()
        {
            InitializeComponent();

            gridProducts.ItemsSource = App.StoreDb.GetProducts();
            ICollectionView view = CollectionViewSource.GetDefaultView(gridProducts.ItemsSource);
            
            view.GroupDescriptions.Add(new PropertyGroupDescription("CategoryName"));            
        }
    }
}
