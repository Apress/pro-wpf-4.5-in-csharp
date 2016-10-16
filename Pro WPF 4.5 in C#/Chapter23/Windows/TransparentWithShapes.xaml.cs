using System;
using System.Windows;
using System.Windows.Input;

namespace Windows {

    public partial class TransparentWithShapes : Window
    {

        public TransparentWithShapes()
        {
            InitializeComponent();
        }

        private void window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void cmdClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}