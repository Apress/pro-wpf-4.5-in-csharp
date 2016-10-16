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
    /// Interaction logic for MnemonicTest.xaml
    /// </summary>

    public partial class MnemonicTest : System.Windows.Window
    {

        public MnemonicTest()
        {
            InitializeComponent();
        }

        private void cmdClicked(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
            
        }

    }
}