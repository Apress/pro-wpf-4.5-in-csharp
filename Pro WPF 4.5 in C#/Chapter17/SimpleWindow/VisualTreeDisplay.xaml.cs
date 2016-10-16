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

namespace SimpleWindow
{
    /// <summary>
    /// Interaction logic for VisualTreeDisplay.xaml
    /// </summary>

    public partial class VisualTreeDisplay : System.Windows.Window
    {

        public VisualTreeDisplay()
        {
            InitializeComponent();
        }

        public void ShowVisualTree(DependencyObject element)
        {
            // Clear the tree.
            treeElements.Items.Clear();

            // Start processing elements, begin at the root.
            ProcessElement(element, null);            
        }

        private void ProcessElement(DependencyObject element, TreeViewItem previousItem)
        {
            // Create a TreeViewItem for the current element.
            TreeViewItem item = new TreeViewItem();
            item.Header = element.GetType().Name;
            item.IsExpanded = true;

            // Check whether this item should be added to the root of the tree
            //(if it's the first item), or nested under another item.
            if (previousItem == null)
            {
                treeElements.Items.Add(item);
            }
            else
            {
                previousItem.Items.Add(item);
            }

            // Check if this element contains other elements.
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                // Process each contained element recursively.
                ProcessElement(VisualTreeHelper.GetChild(element, i), item);
            }
        }       
    }
}