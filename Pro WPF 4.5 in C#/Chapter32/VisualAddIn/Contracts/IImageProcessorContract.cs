using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn.Pipeline;
using System.AddIn.Contract;
using System.Windows;
using System.IO;

namespace Contract
{
    [AddInContract]
    public interface IImageProcessorContract : IContract
    {
        INativeHandleContract GetVisual(Stream imageStream);
    }
}
