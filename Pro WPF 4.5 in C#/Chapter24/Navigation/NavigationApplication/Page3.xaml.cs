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
    /// Interaction logic for Page3.xaml
    /// </summary>

    public partial class Page3 : System.Windows.Controls.Page
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void Init(object sender, EventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            while (nav.CanGoBack)
            {
                JournalEntry obj = nav.RemoveBackEntry();
            }
        }
    }
}