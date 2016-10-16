using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn.Pipeline;

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

        public byte[] ProcessImageBytes(byte[] pixels)
        {
            return view.ProcessImageBytes(pixels);
        }
    }
}

