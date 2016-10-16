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
using System.Globalization;

namespace Printing
{
    /// <summary>
    /// Interaction logic for PrintCustomPage.xaml
    /// </summary>

    public partial class PrintCustomPage : System.Windows.Window
    {

        public PrintCustomPage()
        {
            InitializeComponent();
        }

        private void cmdPrint_Click(object sender, RoutedEventArgs e)
        {           
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                // Create a visual for the page.
                DrawingVisual visual = new DrawingVisual();

                // Get the drawing context
                using (DrawingContext dc = visual.RenderOpen())
                {
                    // Define the text you want to print.
                    FormattedText text = new FormattedText(txtContent.Text,
                        CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                        new Typeface("Calibri"), 20, Brushes.Black);

                    // You must pick a maximum width to use wrapping with a FormattedText object.
                    text.MaxTextWidth = printDialog.PrintableAreaWidth / 2;

                    // Get the size required for the text.
                    Size textSize = new Size(text.Width, text.Height);

                    // Find the top-left corner where you want to place the text.
                    double margin = 96*0.25;                    
                    Point point = new Point((printDialog.PrintableAreaWidth - textSize.Width)/ 2 - margin,
                        (printDialog.PrintableAreaHeight - textSize.Height) / 2 - margin);

                    // Draw the content.
                    dc.DrawText(text, point);

                    // Add a border (a rectangle with no background).
                    dc.DrawRectangle(null, new Pen(Brushes.Black, 1),
                        new Rect(margin, margin, printDialog.PrintableAreaWidth - margin * 2,
                        printDialog.PrintableAreaHeight - margin * 2));
                }

                // Print the visual.
                printDialog.PrintVisual(visual, "A Custom-Printed Page");
            }

        }
    }
}