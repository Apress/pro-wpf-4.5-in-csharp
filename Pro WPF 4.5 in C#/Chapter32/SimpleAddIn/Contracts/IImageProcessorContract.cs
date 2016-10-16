﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn.Pipeline;
using System.AddIn.Contract;

namespace Contract
{
    [AddInContract]
    public interface IImageProcessorContract : IContract
    {
        byte[] ProcessImageBytes(byte[] pixels);
    }
}
