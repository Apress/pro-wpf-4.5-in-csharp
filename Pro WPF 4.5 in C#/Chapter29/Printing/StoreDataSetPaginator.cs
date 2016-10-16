using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;
using System.Windows.Media;
using System.Data;
using System.Globalization;
using System.Windows;

namespace Printing
{
    public class StoreDataSetPaginator : DocumentPaginator
    {
        private DataTable dt;

        // Could be wrapped with public properties that call PaginateData() when set.
        private Typeface typeface;
        private double fontSize;
        private double margin;

        public StoreDataSetPaginator(DataTable dt, Typeface typeface, double fontSize, double margin, Size pageSize)
        {
            this.dt = dt;
            this.typeface = typeface;
            this.fontSize = fontSize;
            this.margin = margin;
            this.pageSize = pageSize;
            PaginateData();
        }

        public override bool IsPageCountValid
        {
            get { return true; }
        }

        private int pageCount;
        public override int PageCount
        {
            get { return pageCount; }
        }

        private Size pageSize;
        public override Size PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value;
                PaginateData();
            }
        }

        public override IDocumentPaginatorSource Source
        {
            get { return null; }
        }


        // This helper method splits the data into pages.
        // In some cases you'll need to store objects representing the per-page data.
        // Here, a rowsPerPage value is enough becuase every page is the same.
        private int rowsPerPage;
        private void PaginateData()
        {
            // Create a test string for the purposes of measurement.
            FormattedText text = GetFormattedText("A");

            // Count the lines that fit on a page.
            rowsPerPage = (int)((pageSize.Height-margin*2) / text.Height);

            // Leave a row for the headings
            rowsPerPage -= 1;

            pageCount = (int)Math.Ceiling((double)dt.Rows.Count / rowsPerPage);
        }

        public override DocumentPage GetPage(int pageNumber)
        {
            // Create a test string for the purposes of measurement.
            FormattedText text = GetFormattedText("A");
            // Size columns relative to the width of one "A" letter.
            // It's a shortcut that works in this example.
            double col1_X = margin;
            double col2_X = col1_X + text.Width * 15;

            // Calculate the range of rows that fits on this page.
            int minRow = pageNumber * rowsPerPage;
            int maxRow = minRow + rowsPerPage;
                                    
            // Create the visual for the page.
            DrawingVisual visual = new DrawingVisual();
            
            // Initially, set the position to the top-left corner of the printable area.
            Point point = new Point(margin, margin);

            // Print the column values.
            using (DrawingContext dc = visual.RenderOpen())
            {
                // Draw the column headers.
                Typeface columnHeaderTypeface = new Typeface(typeface.FontFamily, FontStyles.Normal, FontWeights.Bold, FontStretches.Normal);
                point.X = col1_X;
                text = GetFormattedText("Model Number", columnHeaderTypeface);
                dc.DrawText(text, point);
                text = GetFormattedText("Model Name", columnHeaderTypeface);
                point.X = col2_X;
                dc.DrawText(text, point);

                // Draw the line underneath.
                dc.DrawLine(new Pen(Brushes.Black, 2),
                    new Point(margin, margin + text.Height),
                    new Point(pageSize.Width - margin, margin + text.Height));
                
                point.Y += text.Height;

                // Draw the column values.
                for (int i = minRow; i < maxRow; i++)
                {   
                    // Check for the end of the last (half-filled) page.
                    if (i > (dt.Rows.Count - 1)) break;

                    point.X = col1_X;   
                    text = GetFormattedText(dt.Rows[i]["ModelNumber"].ToString());
                    dc.DrawText(text, point);

                    // Add second column.                    
                    text = GetFormattedText(dt.Rows[i]["ModelName"].ToString());
                    point.X = col2_X;
                    dc.DrawText(text, point);
                    point.Y += text.Height;
                }
            }            
            return new DocumentPage(visual, pageSize, new Rect(pageSize), new Rect(pageSize));
        }


        private FormattedText GetFormattedText(string text)
        {
            return GetFormattedText(text, typeface);
        }
        private FormattedText GetFormattedText(string text, Typeface typeface)
        {            
            return new FormattedText(
                text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                        typeface, fontSize, Brushes.Black);
        }

    }
}
