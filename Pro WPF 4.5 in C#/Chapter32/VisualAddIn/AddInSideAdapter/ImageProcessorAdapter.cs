using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn.Pipeline;
using System.Windows;
using System.IO;
using System.AddIn.Contract;

namespace AddInSideAdapter
{
    [AddInAdapter]
    public class ImageProcessorViewToContractAdapter : ContractBase, Contract.IImageProcessorContract
    {
        private AddInView.ImageProcessorAddInView view;

        public ImageProcessorViewToContractAdapter(AddInView.ImageProcessorAddInView view)
        {
            this.view = view;
        }

        public INativeHandleContract GetVisual(Stream imageStream)
        {
            return FrameworkElementAdapters.ViewToContractAdapter(view.GetVisual(imageStream));
        }
    }
}

