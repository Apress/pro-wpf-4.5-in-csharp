using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;


namespace SingleInstanceApplication
{
    public partial class Document : Window
    {
        private DocumentReference docRef;

        public Document()
        {
            InitializeComponent();            
        }

        public void LoadFile(DocumentReference docRef)
        {
            this.docRef = docRef;
            this.Content = File.ReadAllText(docRef.Name);
            this.Title = docRef.Name;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            ((WpfApp)Application.Current).Documents.Remove(docRef);
        }
    }
}