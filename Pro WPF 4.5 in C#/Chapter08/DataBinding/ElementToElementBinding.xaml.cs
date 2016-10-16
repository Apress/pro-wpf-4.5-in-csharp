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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for ElementToElementBinding.xaml
    /// </summary>

    public partial class ElementToElementBinding : System.Windows.Window
    {

        public ElementToElementBinding()
        {
            InitializeComponent();
        }

        private void cmd_SetSmall(object sender, RoutedEventArgs e)
        {
            sliderFontSize.Value = 2;
        }

        private void cmd_SetNormal(object sender, RoutedEventArgs e)
        {
            sliderFontSize.Value = this.FontSize;
        }

        private void cmd_SetLarge(object sender, RoutedEventArgs e)
        {
            // Only works in two-way mode.
            lblSampleText.FontSize = 30;
             
        }

        private void cmd_GetBoundObject(object sender, RoutedEventArgs e)
        {
            Binding binding = BindingOperations.GetBinding(txtBound, TextBox.TextProperty);
            MessageBox.Show("Bound " + binding.Path.Path + " to source element " + binding.ElementName);

            BindingExpression expression = BindingOperations.GetBindingExpression(txtBound, TextBox.TextProperty);
            MessageBox.Show("Bound " + expression.ResolvedSourcePropertyName + " with data " + ((TextBlock)expression.ResolvedSource).FontSize);
        }
    }
}