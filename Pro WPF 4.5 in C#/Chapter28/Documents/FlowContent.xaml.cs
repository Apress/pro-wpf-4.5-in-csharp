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

namespace Documents
{
    /// <summary>
    /// Interaction logic for FlowContent.xaml
    /// </summary>

    public partial class FlowContent : System.Windows.Window
    {

        public FlowContent()
        {
            InitializeComponent();           
            
        }

        private void cmdCreateDynamicDocument_Click(object sender, RoutedEventArgs e)
        {
            // Create first part of sentence.
            Run runFirst = new Run();
            runFirst.Text = "Hello world of ";

            // Create bolded text.
            Bold bold = new Bold();
            Run runBold = new Run();
            runBold.Text = "dynamically generated";
            bold.Inlines.Add(runBold);

            // Create last part of sentence.
            Run runLast = new Run();
            runLast.Text = " documents";

            // Add three parts of sentence to a paragraph, in order.
            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.Add(runFirst);
            paragraph.Inlines.Add(bold);
            paragraph.Inlines.Add(runLast);

            // Create a document and add this paragraph.
            FlowDocument document = new FlowDocument();
            document.Blocks.Add(paragraph);

            // Show the document.
            docViewer.Document = document;
        }
    }
}