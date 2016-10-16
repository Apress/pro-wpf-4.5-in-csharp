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
    /// Interaction logic for PrintScaledVisual.xaml
    /// </summary>

    public partial class PrintScaledVisual : System.Windows.Window
    {

        public PrintScaledVisual()
        {
            InitializeComponent();
        }

        private void cmdPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                // Create the text.
                Run run = new Run("This is a test of the printing functionality in the Windows Presentation Foundation.");

                // Wrap it in a TextBlock.
                TextBlock visual = new TextBlock(run);                
                visual.Margin = new Thickness(15);
                // Allow wrapping to fit the page width.
                visual.TextWrapping = TextWrapping.Wrap;

                // Scale the TextBlock in both dimensions.
                double zoom;
                if (Double.TryParse(txtScale.Text, out zoom))
                {
                    visual.LayoutTransform = new ScaleTransform(zoom / 100, zoom / 100);

                    // Get the size of the page.
                    Size pageSize = new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);
                    // Trigger the sizing of the element.                
                    visual.Measure(pageSize);
                    visual.Arrange(new Rect(0, 0, pageSize.Width, pageSize.Height));

                    // Print the element.
                    printDialog.PrintVisual(visual, "A Scaled Drawing");
                }
                else
                {
                    MessageBox.Show("Invalid scale value.");
                }
            }

        }
    }
}