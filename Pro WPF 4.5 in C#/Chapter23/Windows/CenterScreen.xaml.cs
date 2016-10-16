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
using System.ComponentModel;

namespace Windows
{
    /// <summary>
    /// Interaction logic for CenterScreen.xaml
    /// </summary>

    public partial class CenterScreen : System.Windows.Window
    {

        public CenterScreen()
        {
            InitializeComponent();
        }

        private void cmdCenter_Click(object sender, RoutedEventArgs e)
        {            
            double height = SystemParameters.WorkArea.Height;
            double width = SystemParameters.WorkArea.Width;            
            this.Top = (height - this.Height) / 2;            
            this.Left = (width - this.Width) / 2;            
         
        }
    }
}