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
using System.Data;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for DataTemplateControls.xaml
    /// </summary>

    public partial class DataTemplateControls : System.Windows.Window
    {

        public DataTemplateControls()
        {
            InitializeComponent();
            lstCategories.ItemsSource = App.StoreDbDataSet.GetCategoriesAndProducts().Tables["Categories"].DefaultView;
        }

        private void cmdView_Clicked(object sender, RoutedEventArgs e)
        {
            Button cmd = (Button)sender;
            DataRowView row = (DataRowView)cmd.Tag;
            lstCategories.SelectedItem = row;
            
            // Alternate selection approach.
            //ListBoxItem item = (ListBoxItem)lstCategories.ItemContainerGenerator.ContainerFromItem(row);
            //item.IsSelected = true;

            MessageBox.Show("You chose category #" + row["CategoryID"].ToString() + ": " + (string)row["CategoryName"]);
        }
    }
}