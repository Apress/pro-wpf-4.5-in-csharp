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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NavigationApplication
{
    /// <summary>
    /// Interaction logic for PageFunctionCall.xaml
    /// </summary>

    public partial class PageFunctionCall : System.Windows.Controls.Page
    {
        public PageFunctionCall()
        {
            InitializeComponent();
        }
        private void cmdSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectProductPageFunction pageFunction = new SelectProductPageFunction();
            pageFunction.Return += new ReturnEventHandler<Product>(
              SelectProductPageFunction_Returned);
            this.NavigationService.Navigate(pageFunction);

        }
        private void SelectProductPageFunction_Returned(object sender,
          ReturnEventArgs<Product> e)
        {
            if (e != null) lblStatus.Content = "You chose: " + e.Result.Name;
        }

    }
}