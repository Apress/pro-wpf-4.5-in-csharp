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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.AddIn.Hosting;

namespace ApplicationHost
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {                     
            string path = Environment.CurrentDirectory;            
            AddInStore.Update(path);

            IList<AddInToken> tokens = AddInStore.FindAddIns(typeof(HostView.ImageProcessorHostView), path);            
            lstAddIns.ItemsSource = tokens;        
        }

        private void cmdProcessImage_Click(object sender, RoutedEventArgs e)
        {            
            BitmapSource originalSource = (BitmapSource)img.Source;
            int stride = originalSource.PixelWidth * originalSource.Format.BitsPerPixel/8;
            stride = stride + (stride % 4) * 4;
            byte[] originalPixels = new byte[stride * originalSource.PixelHeight * originalSource.Format.BitsPerPixel / 8];
            
            originalSource.CopyPixels(originalPixels, stride, 0);
            
            AddInToken token = (AddInToken)lstAddIns.SelectedItem;
            HostView.ImageProcessorHostView addin = token.Activate<HostView.ImageProcessorHostView>(AddInSecurityLevel.Internet);
            byte[] changedPixels = addin.ProcessImageBytes(originalPixels);
            
            BitmapSource newSource = BitmapSource.Create(originalSource.PixelWidth, originalSource.PixelHeight, originalSource.DpiX, originalSource.DpiY, originalSource.Format, originalSource.Palette, changedPixels, stride);
            img.Source = newSource;
        }

        private void lstAddIns_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmdProcessImage.IsEnabled = (lstAddIns.SelectedIndex != -1);
        }
    }
}
