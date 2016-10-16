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
using System.Printing;

namespace Printing
{
    /// <summary>
    /// Interaction logic for PrintWithoutUserIntervention.xaml
    /// </summary>

    public partial class PrintWithoutUserIntervention : System.Windows.Window
    {

        public PrintWithoutUserIntervention()
        {
            InitializeComponent();
        }

        private void cmdPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();            
            dialog.PrintQueue = LocalPrintServer.GetDefaultPrintQueue();            
            dialog.PrintVisual((Visual)sender, "Automatic Printout");
        }
    }
}