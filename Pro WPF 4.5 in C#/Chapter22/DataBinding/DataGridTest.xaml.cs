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
    /// Interaction logic for DataGridTest.xaml
    /// </summary>
    public partial class DataGridTest : Window
    {
        public DataGridTest()
        {
            InitializeComponent();
            
            gridProducts.ItemsSource = App.StoreDb.GetProducts();
        }

        // Reuse brush objects for efficiency in large data displays.
        private SolidColorBrush highlightBrush = new SolidColorBrush(Colors.Orange);
        private SolidColorBrush normalBrush = new SolidColorBrush(Colors.White);

        private void gridProducts_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Product product = (Product)e.Row.DataContext;
            if (product.UnitCost > 100)
                e.Row.Background = highlightBrush;
            else
                e.Row.Background = normalBrush;

        }

        private void FormatRow(DataGridRow row)
        {
            Product product = (Product)row.DataContext;
            if (product.UnitCost > 100)
                row.Background = highlightBrush;
            else
                row.Background = normalBrush;
        }   
    }
}
