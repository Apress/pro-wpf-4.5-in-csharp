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
using System.Windows.Shapes;
using System.Runtime.InteropServices;

namespace WebBrowserTest
{
    /// <summary>
    /// Interaction logic for CallWpfWithJavaScript.xaml
    /// </summary>
    public partial class CallWpfWithJavaScript : Window
    {
        public CallWpfWithJavaScript()
        {
            InitializeComponent();
                        
            webBrowser.Navigate("file:///" + 
                System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ResourceAssembly.Location), "sample.htm"));
            webBrowser.ObjectForScripting = new HtmlBridge();
        }
    }

    [ComVisible(true)]
    public class HtmlBridge
    {
        public void WebClick(string source)
        {
            MessageBox.Show("Received: " + source);
        }
    }

}
