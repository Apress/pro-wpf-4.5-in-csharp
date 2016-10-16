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
    /// Interaction logic for BindProductObject.xaml
    /// </summary>

    public partial class BindProductObject : System.Windows.Window
    {

        public BindProductObject()
        {
            InitializeComponent();
        }

        private void cmdGetProduct_Click(object sender, RoutedEventArgs e)
        {
            int ID;
            if (Int32.TryParse(txtID.Text, out ID))
            {
                try
                {
                    gridProductDetails.DataContext = App.StoreDb.GetProduct(ID);                    
                }
                catch
                {
                    MessageBox.Show("Error contacting database.");
                }
            }
            else
            {
                MessageBox.Show("Invalid ID.");
            }
        }
    }
}