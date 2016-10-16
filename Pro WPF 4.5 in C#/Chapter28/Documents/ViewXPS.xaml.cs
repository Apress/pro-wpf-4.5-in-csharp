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
using System.Windows.Xps.Packaging;
using System.IO;

namespace Documents
{
    /// <summary>
    /// Interaction logic for ViewXPS.xaml
    /// </summary>

    public partial class ViewXPS : System.Windows.Window
    {

        public ViewXPS()
        {
            InitializeComponent();
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            XpsDocument doc = new XpsDocument("ch19.xps", FileAccess.Read);
            docViewer.Document = doc.GetFixedDocumentSequence();
            doc.Close();
        }
    }
}