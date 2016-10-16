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

namespace NavigationApplication
{
    /// <summary>
    /// Interaction logic for StartupWindow.xaml
    /// </summary>

    public partial class StartupWindow : System.Windows.Navigation.NavigationWindow
    {

        public StartupWindow()
        {
            InitializeComponent();

            this.Content = new Menu();
        }

    }
}