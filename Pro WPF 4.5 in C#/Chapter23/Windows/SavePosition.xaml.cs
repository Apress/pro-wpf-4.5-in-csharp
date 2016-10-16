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

namespace Windows
{
    /// <summary>
    /// Interaction logic for SavePosition.xaml
    /// </summary>

    public partial class SavePosition : System.Windows.Window
    {

        public SavePosition()
        {
            InitializeComponent();
        }

        private void cmdSave_Click(object sender, RoutedEventArgs e)
        {
            WindowPositionHelper.SaveSize(this);
        }

        private void cmdRestore_Click(object sender, RoutedEventArgs e)
        {
            WindowPositionHelper.SetSize(this);
        }
    }
}