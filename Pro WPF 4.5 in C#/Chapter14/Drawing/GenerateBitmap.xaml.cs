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
using System.Windows.Shapes;

namespace Drawing
{
    /// <summary>
    /// Interaction logic for GenerateBitmap.xaml
    /// </summary>
    public partial class GenerateBitmap : Window
    {
        public GenerateBitmap()
        {
            InitializeComponent();
        }


        private void cmdGenerate_Click(object sender, RoutedEventArgs e)
        {
            // Create the bitmap, with the dimensions of the image placeholder.
            WriteableBitmap wb = new WriteableBitmap((int)img.Width,
                (int)img.Height, 96, 96, PixelFormats.Bgra32, null);
            
            // Define the update square (which is as big as the entire image).
            Int32Rect rect = new Int32Rect(0, 0, (int)img.Width, (int)img.Height);

            byte[] pixels = new byte[(int)img.Width * (int)img.Height * wb.Format.BitsPerPixel / 8];
            Random rand = new Random();
            for (int y = 0; y < wb.PixelHeight; y++) 
            {
                for (int x = 0; x < wb.PixelWidth; x++)
                {
                    int alpha = 0;
                    int red = 0;
                    int green = 0;
                    int blue = 0;

                    // Determine the pixel's color.
                    if ((x % 5 == 0) || (y % 7 == 0))
                    {
                        red = (int)((double)y / wb.PixelHeight * 255);
                        green = rand.Next(100, 255);
                        blue = (int)((double)x / wb.PixelWidth * 255);
                        alpha = 255;
                    }
                    else
                    {
                        red = (int)((double)x / wb.PixelWidth * 255);
                        green = rand.Next(100, 255);
                        blue = (int)((double)y / wb.PixelHeight * 255);
                        alpha = 50;
                    }

                    int pixelOffset = (x + y * wb.PixelWidth) * wb.Format.BitsPerPixel/8;
                    pixels[pixelOffset] = (byte)blue;
                    pixels[pixelOffset + 1] = (byte)green;
                    pixels[pixelOffset + 2] = (byte)red;
                    pixels[pixelOffset + 3] = (byte)alpha;

                                       
                }

                int stride = (wb.PixelWidth * wb.Format.BitsPerPixel) / 8;

                wb.WritePixels(rect, pixels, stride, 0);
            }

            // Show the bitmap in an Image element.
            img.Source = wb;
        }
    


         private void cmdGenerate2_Click(object sender, RoutedEventArgs e)
        {     
             

            // Create the bitmap, with the dimensions of the image placeholder.
            WriteableBitmap wb = new WriteableBitmap((int)img.Width, 
                (int)img.Height, 96, 96, PixelFormats.Bgra32, null);
                        
            Random rand = new Random();
            for (int x = 0; x < wb.PixelWidth; x++)
            {
                for (int y = 0; y < wb.PixelHeight; y++)
                {
                    int alpha = 0;
                    int red = 0;
                    int green = 0;
                    int blue = 0;
                    
                    // Determine the pixel's color.
                    if ((x % 5 == 0) || (y % 7 == 0))
                    {
                        red = (int)((double)y / wb.PixelHeight * 255);
                        green = rand.Next(100, 255);
                        blue = (int)((double)x / wb.PixelWidth * 255);
                        alpha = 255;
                    }
                    else
                    {                        
                        red = (int)((double)x / wb.PixelWidth * 255);
                        green = rand.Next(100, 255);
                        blue = (int)((double)y / wb.PixelHeight * 255);
                        alpha = 50;
                    }

                    // Set the pixel value.                    
                    byte[] colorData = { (byte)blue, (byte)green, (byte)red, (byte)alpha }; // B G R
                    
                    Int32Rect rect = new Int32Rect(x,y, 1, 1);
                    int stride = (wb.PixelWidth * wb.Format.BitsPerPixel) / 8;
                    wb.WritePixels(rect, colorData, stride, 0);
                  
                    //wb.WritePixels(.[y * wb.PixelWidth + x] = pixelColorValue;
                }
            }
                        
            // Show the bitmap in an Image element.
            img.Source = wb;                        
        }
    
    }
}
