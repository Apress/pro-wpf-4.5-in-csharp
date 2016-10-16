using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace StoreDatabase
{
    public class Category : INotifyPropertyChanged
    {
        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CategoryName"));
            }
        }

        // For DataGridComboBoxColumn example.
        private int categoryID;
        public int CategoryID
        {
            get { return categoryID; }
            set {
                categoryID = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CategoryID"));
            }
        }

        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Products"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public Category(string categoryName, ObservableCollection<Product> products)
        {
            CategoryName = categoryName;
            Products = products;
        }

        public Category(string categoryName, int categoryID)
        {
            CategoryName = categoryName;
            CategoryID = categoryID;            
        }

    }

}
