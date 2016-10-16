using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;
using System.Globalization;

namespace Printing
{
    public class HeaderedFlowDocumentPaginator : DocumentPaginator
    {
        private DocumentPaginator flowDocumentPaginator;

        public HeaderedFlowDocumentPaginator(FlowDocument document)
        {
            flowDocumentPaginator = ((IDocumentPaginatorSource)document).DocumentPaginator;
        }

        public override DocumentPage GetPage(int pageNumber)
        {
            // Get the requested page.
            DocumentPage page = flowDocumentPaginator.GetPage(pageNumber);

            // Wrap the page in a Visual. You can then add a transformation and extras.
            ContainerVisual newVisual = new ContainerVisual();
            newVisual.Children.Add(page.Visual);

            // Create a header. 
            DrawingVisual header = new DrawingVisual();
            using (DrawingContext context = header.RenderOpen())
            {
                Typeface typeface = new Typeface("Times New Roman");                
                FormattedText text = new FormattedText("Page " + (pageNumber + 1).ToString(),
                  CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                  typeface, 14, Brushes.Black);
                
                // Leave a quarter-inch of space between the page edge and this text.
                context.DrawText(text, new Point(96*0.25, 96*0.25));
            }
            // Add the title to the visual.
            newVisual.Children.Add(header);

            // Wrap the visual in a new page.
            DocumentPage newPage = new DocumentPage(newVisual);
            return newPage;            
        }

        public override bool IsPageCountValid
        {
            get { return flowDocumentPaginator.IsPageCountValid;  }
        }

        public override int PageCount
        {
            get { return flowDocumentPaginator.PageCount; }
        }

        public override System.Windows.Size PageSize
        {
            get { return flowDocumentPaginator.PageSize; }
            set { flowDocumentPaginator.PageSize = value; }
        }

        public override IDocumentPaginatorSource Source
        {
            get { return flowDocumentPaginator.Source; }
        }
    }
}
