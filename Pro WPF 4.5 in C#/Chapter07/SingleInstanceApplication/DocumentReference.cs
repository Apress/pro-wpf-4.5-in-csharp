using System;
using System.Collections.Generic;
using System.Text;

namespace SingleInstanceApplication
{
    // This package contains a reference to a document window and its name.
    // The purpose of this class is to make it easier to display the list
    // of window names in DocumentList through data binding.
    public class DocumentReference
    {
        private Document document;
        public Document Document
        {
            get { return document; }
            set { document = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DocumentReference(Document document, string name)
        {
            Document = document;
            Name = name;
        }
    }
}
