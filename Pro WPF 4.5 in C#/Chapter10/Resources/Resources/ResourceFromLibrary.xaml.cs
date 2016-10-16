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

namespace Resources
{
    /// <summary>
    /// Interaction logic for ResourceFromLibrary.xaml
    /// </summary>

    public partial class ResourceFromLibrary : System.Windows.Window
    {

        public ResourceFromLibrary()
        {
            InitializeComponent();

            //ResourceDictionary resourceDictionary = new ResourceDictionary();            
            //resourceDictionary.Source = new Uri("ResourceLibrary;component/themes/generic.xaml", UriKind.Relative);            
        }

    }
}