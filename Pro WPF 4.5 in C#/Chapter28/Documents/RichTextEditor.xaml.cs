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
using System.IO;
using Microsoft.Win32;

namespace Documents
{
    /// <summary>
    /// Interaction logic for RichTextEditor.xaml
    /// </summary>

    public partial class RichTextEditor : System.Windows.Window
    {

        public RichTextEditor()
        {
            InitializeComponent();
        }

        private void cmdBold_Click(object sender, RoutedEventArgs e)
        {
            if (richTextBox.Selection.Text == "")
            {
                FontWeight fontWeight = richTextBox.Selection.Start.Paragraph.FontWeight;
                if (fontWeight == FontWeights.Bold)
                    fontWeight = FontWeights.Normal;
                else
                    fontWeight = FontWeights.Bold;

                richTextBox.Selection.Start.Paragraph.FontWeight = fontWeight;
            }
            else
            {
            Object obj = richTextBox.Selection.GetPropertyValue(TextElement.FontWeightProperty);
            if (obj == DependencyProperty.UnsetValue)
            {
                TextRange range = new TextRange(richTextBox.Selection.Start,
                    richTextBox.Selection.Start);
                obj = range.GetPropertyValue(TextElement.FontWeightProperty);
            }

            FontWeight fontWeight = (FontWeight)obj;

            if (fontWeight == FontWeights.Bold)
              fontWeight = FontWeights.Normal;
            else
              fontWeight = FontWeights.Bold;

            richTextBox.Selection.ApplyPropertyValue(
              TextElement.FontWeightProperty, fontWeight);
            }
        }
        

        private void cmdShowXAML_Click(object sender, RoutedEventArgs e)
        {
            UpdateMarkupDisplay();
        }


        private void UpdateMarkupDisplay()
        {
            TextRange range;

            range = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            
            MemoryStream stream = new MemoryStream();
            range.Save(stream, DataFormats.Xaml);
            stream.Position = 0;

            StreamReader r = new StreamReader(stream);

            txtFlowDocumentMarkup.Text = r.ReadToEnd();
            r.Close();
            stream.Close();
        }


        private void cmdOpen_Click(object sender, RoutedEventArgs e)
        {             

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "XAML Files (*.xaml)|*.xaml|RichText Files (*.rtf)|*.rtf|All Files (*.*)|*.*";

            if (openFile.ShowDialog() == true)
            {
                // Create a TextRange around the entire document.
                TextRange documentTextRange = new TextRange(
                    richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                                
                using (FileStream fs = File.Open(openFile.FileName, FileMode.Open))
                {
                    if (Path.GetExtension(openFile.FileName).ToLower() == ".rtf")
                    {
                        documentTextRange.Load(fs, DataFormats.Rtf);
                    }
                    else
                    {
                        documentTextRange.Load(fs, DataFormats.Xaml);
                    }
                }
            }
        }

        private void cmdSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "XAML Files (*.xaml)|*.xaml|RichText Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
                        
            if (saveFile.ShowDialog() == true)
            {
                // Create a TextRange around the entire document.
                TextRange documentTextRange = new TextRange(
                    richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);

                // If this file exists, it's overwritten.
                using (FileStream fs = File.Create(saveFile.FileName))
                {
                    if (Path.GetExtension(saveFile.FileName).ToLower() == ".rtf")
                    {
                        documentTextRange.Save(fs, DataFormats.Rtf);
                    }
                    else
                    {
                        documentTextRange.Save(fs, DataFormats.Xaml);
                    }
                }
            }
        }

        private void cmdNew_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Document = new FlowDocument();
        }

        private void richTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
            TextPointer location = richTextBox.GetPositionFromPoint(Mouse.GetPosition(richTextBox), true);
            TextRange word = WordBreaker.GetWordRange(location);
            txtFlowDocumentMarkup.Text = word.Text;
            }
        }
    }
}