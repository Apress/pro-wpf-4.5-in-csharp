using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;

namespace HostView
{
    public abstract class ImageProcessorHostView
    {
        public abstract FrameworkElement GetVisual(Stream imageStream);
    }
}
