using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn.Pipeline;
using System.Windows;
using System.IO;

namespace AddInView
{    
    [AddInBase]
    public abstract class ImageProcessorAddInView
    {        
        public abstract FrameworkElement GetVisual(Stream imageStream);
    }
}
