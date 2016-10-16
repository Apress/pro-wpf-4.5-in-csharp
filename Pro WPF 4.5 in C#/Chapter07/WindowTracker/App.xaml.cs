using System;
using System.Windows;
using System.Collections.Generic;

namespace WindowTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        private List<Document> documents = new List<Document>();
        
        public List<Document> Documents
        {
            get { return documents; }
            set { documents = value; }
        }
    }
}