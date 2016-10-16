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
using System.IO;

namespace NegativeImageAddIn
{
    /// <summary>
    /// Interaction logic for ImagePreview.xaml
    /// </summary>
    public partial class ImagePreview : UserControl
    {
        public ImagePreview()
        {
            InitializeComponent();
        }

        private BitmapSource originalSource;
        private byte[] originalPixels;
        public ImagePreview(Stream imageStream)
        {
            InitializeComponent();

            BitmapImage imgSource = new BitmapImage();
            imgSource.BeginInit();
            imgSource.StreamSource = imageStream;
            imgSource.EndInit();
            img.Source = imgSource;


            originalSource = (BitmapSource)img.Source;
            int stride = originalSource.PixelWidth * originalSource.Format.BitsPerPixel / 8;
            stride = stride + (stride % 4) * 4;
            originalPixels = new byte[stride * originalSource.PixelHeight * originalSource.Format.BitsPerPixel / 8];

            originalSource.CopyPixels(originalPixels, stride, 0);
        }

        private void sliderIntensity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Cursor = Cursors.Wait;
                        
            byte[] changedPixels = ProcessImageBytes((byte[])originalPixels.Clone());

            int stride = originalSource.PixelWidth * originalSource.Format.BitsPerPixel / 8;
            BitmapSource newSource = BitmapSource.Create(originalSource.PixelWidth,
                originalSource.PixelHeight, originalSource.DpiX, originalSource.DpiY,
                originalSource.Format, originalSource.Palette, changedPixels, stride);
            img.Source = newSource;

            this.Cursor = null;
        }

        private byte[] ProcessImageBytes(byte[] pixels)
        {
            double scaleFactor = sliderIntensity.Value / sliderIntensity.Maximum;
            for (int i = 0; i < pixels.Length - 2; i++)
            {
                pixels[i] = (byte)(255*scaleFactor - pixels[i]);
                pixels[i + 1] = (byte)(255*scaleFactor - pixels[i + 1]);
                pixels[i + 2] = (byte)(255*scaleFactor - pixels[i + 2]);
            }
            return pixels;
        }
    }
}
