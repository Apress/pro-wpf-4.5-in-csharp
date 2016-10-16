using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;
using System.IO;
using System.IO.Packaging;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;

namespace Documents
{
    /// <summary>
    /// Interaction logic for XpsAnnotations.xaml
    /// </summary>

    public partial class XpsAnnotations : System.Windows.Window
    {

        public XpsAnnotations()
        {
            InitializeComponent();
        }

       
        private AnnotationService service;
        private XpsDocument doc;

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            doc = new XpsDocument("ch19.xps", FileAccess.ReadWrite);
            docViewer.Document = doc.GetFixedDocumentSequence();

            service = AnnotationService.GetService(docViewer);
            if (service == null)
            {
                Uri annotationUri = PackUriHelper.CreatePartUri(new Uri("AnnotationStream", UriKind.Relative));
                Package package = PackageStore.GetPackage(doc.Uri);
                PackagePart annotationPart = null;
                if (package.PartExists(annotationUri))
                {                    
                    annotationPart = package.GetPart(annotationUri);
                }
                else                
                {                    
                    annotationPart = package.CreatePart(annotationUri, "Annotations/Stream");
                }

                // Load annotations from the package.
                AnnotationStore store = new XmlStreamStore(annotationPart.GetStream());
                service = new AnnotationService(docViewer);
                service.Enable(store);
                
            }
        }
        private void window_Unloaded(object sender, RoutedEventArgs e)
        {
            if (service != null && service.IsEnabled)
            {
                // Flush annotations to stream.
                service.Store.Flush();

                // Disable annotations.
                service.Disable();
            }

            doc.Close();
        }
    }
}