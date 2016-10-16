using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using mshtml;

namespace WebBrowserTest
{
    /// <summary>
    /// Interaction logic for BrowseDOM.xaml
    /// </summary>
    public partial class BrowseDOM : Window
    {
        public BrowseDOM()
        {
            InitializeComponent();
        }

        private void cmdAnalyzeDOM_Click(object sender, RoutedEventArgs e)
        {
            cmdBuildTree_Click(null, null);
        }

        private void cmdBuildTree_Click(object sender, System.EventArgs e)
        {
            // Analyzing a page takes a nontrivial amount of time.
            // Use the hourglass cursor to warn the user.
            this.Cursor = Cursors.Wait;

            HTMLDocument dom = (HTMLDocument)webBrowser.Document;

            // Process all the HTML elements on the page.
            ProcessElement(dom.documentElement, treeDOM.Items);

            this.Cursor = null;
        }

        private void ProcessElement(IHTMLElement parentElement,
          ItemCollection nodes)
        {
            // Scan through the collection of elements.
            foreach (IHTMLElement element in parentElement.children)
            {
                // Create a new node that shows the tag name.
                TreeViewItem node = new TreeViewItem();
                node.Header = "<" + element.tagName + ">";
                nodes.Add(node);

                if ((element.children.length == 0) && (element.innerText != null))
                {
                    // If this element doesn't contain any other elements, add
                    // any leftover text content as a new node.
                    node.Items.Add(element.innerText);
                }
                else
                {
                    // If this element contains other elements, process them recursively.
                    ProcessElement(element, node.Items);
                }
            }
        }

    }
}
