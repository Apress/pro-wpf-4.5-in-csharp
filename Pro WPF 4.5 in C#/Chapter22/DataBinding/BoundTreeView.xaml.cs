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
    /// Interaction logic for BoundTreeView.xaml
    /// </summary>

    public partial class BoundTreeView : System.Windows.Window
    {

        public BoundTreeView()
        {
            InitializeComponent();

            treeCategories.ItemsSource = App.StoreDb.GetCategoriesAndProducts();
        }

    }
}