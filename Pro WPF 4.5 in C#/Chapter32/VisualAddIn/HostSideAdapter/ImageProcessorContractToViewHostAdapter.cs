using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.AddIn.Pipeline;
using System.Windows;
using System.IO;

namespace HostSideAdapter
{
    [HostAdapter]
    public class ImageProcessorContractToViewHostAdapter : HostView.ImageProcessorHostView
    {
        private Contract.IImageProcessorContract contract;
        private ContractHandle contractHandle;

        public ImageProcessorContractToViewHostAdapter(Contract.IImageProcessorContract contract)
        {            
            this.contract = contract;
            contractHandle = new ContractHandle(contract);
        }

        public override FrameworkElement GetVisual(Stream imageStream)
        {
            return FrameworkElementAdapters.ContractToViewAdapter(contract.GetVisual(imageStream));
        }
    }
}
