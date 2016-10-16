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
using Microsoft.Win32;

namespace Windows
{
    /// <summary>
    /// Interaction logic for OpenFileTest.xaml
    /// </summary>

    public partial class OpenFileTest : System.Windows.Window
    {

        public OpenFileTest()
        {
            InitializeComponent();
        }


        private void cmdOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();

            myDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF" +
              "|All files (*.*)|*.*";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;

            if (myDialog.ShowDialog() == true)
            {
                lstFiles.Items.Clear();
                foreach (string file in myDialog.FileNames)
                {
                    lstFiles.Items.Add(file);
                }                
            }
        }
    }
}