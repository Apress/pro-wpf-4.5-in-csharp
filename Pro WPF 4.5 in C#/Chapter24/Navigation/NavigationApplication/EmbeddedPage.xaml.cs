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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NavigationApplication
{
    /// <summary>
    /// Interaction logic for EmbeddedPage.xaml
    /// </summary>

    public partial class EmbeddedPage : System.Windows.Controls.Page
    {
        public EmbeddedPage()
        {
            InitializeComponent();
        }
        private void chkOwnsJournal_Click(object sender, RoutedEventArgs e)
        {
            if (chkOwnsJournal.IsChecked == true)
                embeddedFrame.JournalOwnership = JournalOwnership.OwnsJournal;
            else
                embeddedFrame.JournalOwnership = JournalOwnership.UsesParentJournal;
        }


    }
}