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

namespace InteroperabilityWPF
{
    /// <summary>
    /// Interaction logic for HostWinFormControl.xaml
    /// </summary>

    public partial class HostWinFormControl : System.Windows.Window
    {

        public HostWinFormControl()
        {
            InitializeComponent();
        }

        private void maskedTextBox_MaskInputRejected(object sender, System.Windows.Forms.MaskInputRejectedEventArgs e)
        {
            lblErrorText.Content = "Error: " + e.RejectionHint.ToString();
        }
    }
}