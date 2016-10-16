using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;

namespace SingleInstanceApplication
{
    public class Startup
    {
        [STAThread]
        public static void Main(string[] args)
        {            
            SingleInstanceApplicationWrapper wrapper = new SingleInstanceApplicationWrapper();
            wrapper.Run(args);           
        }
    }

    public class SingleInstanceApplicationWrapper : 
        Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
    {        
        public SingleInstanceApplicationWrapper()
        {
            // Enable single-instance mode.
            this.IsSingleInstance = true;
        }

        // Create the WPF application class.
        private WpfApp app;
        protected override bool OnStartup(
            Microsoft.VisualBasic.ApplicationServices.StartupEventArgs e)
        {            
            string extension = ".testDoc";
            string title = "SingleInstanceApplication";
            string extensionDescription = "A Test Document";
            // Uncomment this line to create the file registration.
            // In Windows Vista, you'll need to run the application
            // as an administrator.            
            //FileRegistrationHelper.SetFileAssociation(
            //  extension, title + "." + extensionDescription);

            app = new WpfApp();
            app.Run();

            return false;
        }

        // Direct multiple instances
        protected override void OnStartupNextInstance(
            Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs e)
        {
            if (e.CommandLine.Count > 0)
            {                
                app.ShowDocument(e.CommandLine[0]);
            }
        }
    }

    public class WpfApp : System.Windows.Application
    {
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            base.OnStartup(e);
            
            // Load the main window.
            DocumentList list = new DocumentList();
            this.MainWindow = list;
            list.Show();

            // Load the document that was specified as an argument.
            if (e.Args.Length > 0) ShowDocument(e.Args[0]);
        }

        // An ObservableCollection is a List that provides notification
        // when items are added, deleted, or removed. It's preferred for data binding.
        private ObservableCollection<DocumentReference> documents = 
            new ObservableCollection<DocumentReference>();
        public ObservableCollection<DocumentReference> Documents
        {
            get { return documents; }
            set { documents = value; }
        }        

        public void ShowDocument(string filename)
        {
            try
            {                
                Document doc = new Document();
                DocumentReference docRef = new DocumentReference(doc, filename);
                doc.LoadFile(docRef);                
                doc.Owner = this.MainWindow;
                doc.Show();
                doc.Activate();
                Documents.Add(docRef);
            }
            catch
            {
                MessageBox.Show("Could not load document.");
            }
        }
    }   
}
