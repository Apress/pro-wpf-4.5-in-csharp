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

namespace Printing
{
    /// <summary>
    /// Interaction logic for PrintFlowDocumentWithHeader.xaml
    /// </summary>

    public partial class PrintFlowDocumentWithHeader : System.Windows.Window
    {

        public PrintFlowDocumentWithHeader()
        {
            InitializeComponent();
        }

        private void cmdPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                // Save all the existing settings.                                
                double pageHeight = docReader.Document.PageHeight;
                double pageWidth = docReader.Document.PageWidth;
                Thickness pagePadding = docReader.Document.PagePadding;
                double columnGap = docReader.Document.ColumnGap;
                double columnWidth = docReader.Document.ColumnWidth;

                // Make the FlowDocument page match the printed page.
                docReader.Document.PageHeight = printDialog.PrintableAreaHeight;
                docReader.Document.PageWidth = printDialog.PrintableAreaWidth;
                docReader.Document.PagePadding = new Thickness(50);

                // Use two columns.
                docReader.Document.ColumnGap = 25;
                docReader.Document.ColumnWidth = (docReader.Document.PageWidth - docReader.Document.ColumnGap
                    - docReader.Document.PagePadding.Left - docReader.Document.PagePadding.Right) / 2;

                FlowDocument document = docReader.Document;
                docReader.Document = null;
                
                HeaderedFlowDocumentPaginator paginator = new HeaderedFlowDocumentPaginator(document);
                printDialog.PrintDocument(paginator, "A Flow Document");

                docReader.Document = document;

                // Reapply the old settings.
                docReader.Document.PageHeight = pageHeight;
                docReader.Document.PageWidth = pageWidth;
                docReader.Document.PagePadding = pagePadding;
                docReader.Document.ColumnGap = columnGap;
                docReader.Document.ColumnWidth = columnWidth;
            }
        }
    }
}