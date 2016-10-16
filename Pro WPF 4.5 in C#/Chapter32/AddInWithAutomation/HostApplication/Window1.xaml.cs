using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.AddIn.Hosting;
using System.Windows.Threading;
using System.Threading;

namespace ApplicationHost
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {                     
            string path = Environment.CurrentDirectory;            
            AddInStore.Update(path);

            IList<AddInToken> tokens = AddInStore.FindAddIns(typeof(HostView.ImageProcessorHostView), path);            
            lstAddIns.ItemsSource = tokens;

            automationHost = new AutomationHost(progressBar);
        }

        private AutomationHost automationHost;
        
        // These variables are set on the UI thread and read on the background thread.
        // For better organization, wrap these in a custom class, and pass that an instance
        // of that class to RunBackgroundAddIn() method using the ParameterizedThreadStart
        // delegate.
        private BitmapSource originalSource;
        private int stride;
        private byte[] originalPixels;
        private HostView.ImageProcessorHostView addin;           

        private void cmdProcessImage_Click(object sender, RoutedEventArgs e)
        {
            // Get the byte array ready.
            originalSource = (BitmapSource)img.Source;
            stride = originalSource.PixelWidth * originalSource.Format.BitsPerPixel / 8;
            stride = stride + (stride % 4) * 4;
            originalPixels = new byte[stride * originalSource.PixelHeight * originalSource.Format.BitsPerPixel / 8];
            originalSource.CopyPixels(originalPixels, stride, 0);

            // Start the add-in. 
            AddInToken token = (AddInToken)lstAddIns.SelectedItem;
            addin = token.Activate<HostView.ImageProcessorHostView>(AddInSecurityLevel.Internet);
            addin.Initialize(automationHost);
            
            // Launch the image processing work on a separate thread.
            Thread thread = new Thread(RunBackgroundAddIn);
            thread.Start();
        }

        private void RunBackgroundAddIn()
        {            
            // Do the work.
            byte[] changedPixels = addin.ProcessImageBytes(originalPixels);
            
            // Update the UI on the UI thread.
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    (ThreadStart)delegate()
                    {
                        BitmapSource newSource = BitmapSource.Create(originalSource.PixelWidth,
                originalSource.PixelHeight, originalSource.DpiX, originalSource.DpiY,
                originalSource.Format, originalSource.Palette, changedPixels, stride);

                        img.Source = newSource;
                        progressBar.Value = 0;

                        // Release the add-in (it's a member variable now,
                        // so this step is explicit).
                        addin = null;
                    }
                );                            
        }

        private void lstAddIns_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmdProcessImage.IsEnabled = (lstAddIns.SelectedIndex != -1);
        }

        private class AutomationHost : HostView.HostObject
        {
            private ProgressBar progressBar;

            public AutomationHost(ProgressBar progressBar)
            {
                this.progressBar = progressBar;
            }
            public override void ReportProgress(int progressPercent)
            {
                // Update the UI on the UI thread.
                progressBar.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    (ThreadStart)delegate()
                {
                    progressBar.Value = progressPercent;
                }
                );                
            }
        }
    }

    
}
