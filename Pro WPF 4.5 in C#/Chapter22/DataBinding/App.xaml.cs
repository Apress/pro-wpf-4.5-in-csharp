using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using StoreDatabase;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : System.Windows.Application
    {
        private static StoreDb storeDb = new StoreDb();
        public static StoreDb StoreDb
        {
            get { return storeDb; }
        }

        private static StoreDbDataSet storeDbDataSet = new StoreDbDataSet();
        public static StoreDbDataSet StoreDbDataSet
        {
            get { return storeDbDataSet; }
        }
    }
}