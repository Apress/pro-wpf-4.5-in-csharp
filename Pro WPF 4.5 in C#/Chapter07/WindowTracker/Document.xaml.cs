using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WindowTracker
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>

    public partial class Document : Window
    {
        public Document()
        {
            InitializeComponent();
        }

        public void SetContent(string content)
        {
            this.Content = content;
        }
    }
}