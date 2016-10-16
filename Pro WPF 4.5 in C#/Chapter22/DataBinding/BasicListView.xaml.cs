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
    /// Interaction logic for BasicListView.xaml
    /// </summary>

    public partial class BasicListView : System.Windows.Window
    {
            

        public BasicListView()
        {
            InitializeComponent();                    
            
            lstProducts.ItemsSource = App.StoreDb.GetProducts();         
        }

    }
}