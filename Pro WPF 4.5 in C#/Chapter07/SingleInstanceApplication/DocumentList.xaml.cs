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

namespace SingleInstanceApplication
{
    /// <summary>
    /// Interaction logic for DocumentList.xaml
    /// </summary>

    public partial class DocumentList : System.Windows.Window
    {
        public DocumentList()
        {
            InitializeComponent();

            // Show the window names in a list.
            lstDocuments.DisplayMemberPath = "Name";
            lstDocuments.ItemsSource = ((WpfApp)Application.Current).Documents;
        }        
    }
}