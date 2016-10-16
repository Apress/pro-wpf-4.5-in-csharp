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
using System.Collections;
using StoreDatabase;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for DataGridEditing.xaml
    /// </summary>
    public partial class DataGridEditing : Window
    {
        public DataGridEditing()
        {            
            
            InitializeComponent();
            categoryColumn.ItemsSource = App.StoreDb.GetCategories();
            gridProducts.ItemsSource = App.StoreDb.GetProducts();

        }

  


    }
}
