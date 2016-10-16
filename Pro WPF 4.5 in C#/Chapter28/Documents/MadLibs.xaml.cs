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
    /// Interaction logic for MadLibs.xaml
    /// </summary>

    public partial class MadLibs : System.Windows.Window
    {

        public MadLibs()
        {
            InitializeComponent();
        }
        
        private void WindowLoaded(Object sender, RoutedEventArgs e)
        {
            // Clear grid of text entry controls.
            gridWords.Children.Clear();

            // Look at paragraphs.
            foreach (Block block in document.Blocks)
            {
                Paragraph paragraph = block as Paragraph;

                // Look for spans.
                foreach (Inline inline in paragraph.Inlines)
                {
                    Span span = inline as Span;
                    if (span != null)
                    {
                        RowDefinition row = new RowDefinition();
                        gridWords.RowDefinitions.Add(row);

                        Label lbl = new Label();
                        lbl.Content = inline.Tag.ToString() + ":";
                        Grid.SetColumn(lbl, 0);
                        Grid.SetRow(lbl, gridWords.RowDefinitions.Count - 1);
                        gridWords.Children.Add(lbl);

                        TextBox txt = new TextBox();
                        Grid.SetColumn(txt, 1);
                        Grid.SetRow(txt, gridWords.RowDefinitions.Count - 1);
                        gridWords.Children.Add(txt); 
                                               
                        txt.Tag = span.Inlines.FirstInline;
                    }
                }
            }
        }

        private void cmdGenerate_Click(Object sender, RoutedEventArgs e)
        {
            foreach (UIElement child in gridWords.Children)
            {
                if (Grid.GetColumn(child) == 1)
                {
                    TextBox txt = (TextBox)child;

                    if (txt.Text != "") ((Run)txt.Tag).Text = txt.Text;
                }
            }
            docViewer.Visibility = Visibility.Visible;
        }
    }
}