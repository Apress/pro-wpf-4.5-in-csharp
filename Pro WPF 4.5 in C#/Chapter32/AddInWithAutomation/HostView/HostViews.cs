using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostView
{
    public abstract class ImageProcessorHostView
    {
        public abstract byte[] ProcessImageBytes(byte[] pixels);

        public abstract void Initialize(HostObject host);
    }

    public abstract class HostObject
    {
        public abstract void ReportProgress(int progressPercent);
    }
}
