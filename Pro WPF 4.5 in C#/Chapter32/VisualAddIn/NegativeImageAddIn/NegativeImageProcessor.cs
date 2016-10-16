using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn;
using System.Windows;

namespace NegativeImageAddIn
{
    [AddIn("Negative Image Processor", Version = "1.0.0.0", Publisher = "Imaginomics",
        Description = "Inverts colors to look like a photo negative")]
    public class NegativeImageProcessor : AddInView.ImageProcessorAddInView 
    {       
        public override FrameworkElement GetVisual(System.IO.Stream imageStream)
        {
            return new ImagePreview(imageStream);
        }
    }
}
