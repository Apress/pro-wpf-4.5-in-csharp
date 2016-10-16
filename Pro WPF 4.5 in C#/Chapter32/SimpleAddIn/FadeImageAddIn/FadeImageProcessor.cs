using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn;

namespace FadeImageAddIn
{
    [AddIn("Fade Image Processor", Version = "1.0.0.0", Publisher = "SupraImage",
            Description = "Darkens the picture")]
    public class FadeImageProcessor : AddInView.ImageProcessorAddInView
    {
        public override byte[] ProcessImageBytes(byte[] pixels)
        {
            Random rand = new Random();
            int offset = rand.Next(0, 10);
            for (int i = 0; i < pixels.Length - 1 - offset; i++)
            {
                if ((i + offset) % 5 == 0)
                {
                    pixels[i] = 0;
                }
            }
            return pixels;
        }
    }
}
