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

        public void Initialize(Contract.IHostObjectContract hostObj)
        {            
            view.Initialize(new HostObjectContractToViewAddInAdapter(hostObj));            
        }
    }

    public class HostObjectContractToViewAddInAdapter : AddInView.HostObject
    {
        private Contract.IHostObjectContract contract;
        private ContractHandle handle;

        public HostObjectContractToViewAddInAdapter(Contract.IHostObjectContract contract)
        {
            this.contract = contract;
            this.handle = new ContractHandle(contract);            
        }
                
        public override void ReportProgress(int progressPercent)
        {
            contract.ReportProgress(progressPercent);
        }
    }
    
}

