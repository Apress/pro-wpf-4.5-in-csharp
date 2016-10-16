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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for AdvancedListView.xaml
    /// </summary>

    public partial class AdvancedListView : System.Windows.Window
    {

        public AdvancedListView()
        {
            InitializeComponent();

            lstProducts.ItemsSource = App.StoreDb.GetProducts();
        }

       

       private void gridViewColumn_Click(object sender, RoutedEventArgs e)
       {

       }




   }
}