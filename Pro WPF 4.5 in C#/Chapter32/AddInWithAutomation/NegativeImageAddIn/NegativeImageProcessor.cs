using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn;
using System.Threading;

namespace NegativeImageAddIn
{
    [AddIn("Negative Image Processor", Version = "1.0.0.0", Publisher = "Imaginomics",
        Description = "Inverts colors to look like a photo negative")]
    public class NegativeImageProcessor : AddInView.ImageProcessorAddInView 
    {
        public override byte[] ProcessImageBytes(byte[] pixels)
        {
            int iteration = pixels.Length / 100;
                        
            for (int i = 0; i < pixels.Length - 2; i++)
            {
                pixels[i] = (byte)(255 - pixels[i]);
                pixels[i + 1] = (byte)(255 - pixels[i + 1]);
                pixels[i + 2] = (byte)(255 - pixels[i + 2]);

                if (i % iteration == 0)
                {
                    host.ReportProgress(i / iteration);
                }
            }
            return pixels;
        }

        private AddInView.HostObject host;
        public override void Initialize(AddInView.HostObject hostObj)
        {
            host = hostObj;
        }
    }
}
