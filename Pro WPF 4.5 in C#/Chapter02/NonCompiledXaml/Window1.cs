using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.IO;

namespace NonCompiledXaml
{
    public class Window1 : Window
    {
        private Button button1;        

        public Window1(string xamlFile)
        {
            InitializeComponent(xamlFile);
        }                

        private void InitializeComponent(string xamlFile)
        {
            // Configure the form.
            this.Width = this.Height = 285;
            this.Left = this.Top = 100;
            this.Title = "Dynamically Loaded XAML";

            // Get the XAML content from an external file.
            DependencyObject rootElement;
            using (FileStream fs = new FileStream(xamlFile, FileMode.Open))
            {
                rootElement = (DependencyObject)XamlReader.Load(fs);
            }

            // Insert the markup into this window.
            this.Content = rootElement;                       

            // Find the control with the appropriate name.
            //button1 = (Button)LogicalTreeHelper.FindLogicalNode(rootElement, "button1");
            FrameworkElement frameworkElement = (FrameworkElement)rootElement;
            button1 = (Button)frameworkElement.FindName("button1");

            // Wire up the event handler.
            button1.Click += new RoutedEventHandler(button1_Click);
        }
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button1.Content = "Thank you.";
        }
    }
}



