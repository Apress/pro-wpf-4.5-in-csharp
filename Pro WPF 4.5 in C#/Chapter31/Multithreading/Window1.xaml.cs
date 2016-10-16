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
using System.Threading;
using System.Windows.Threading;


namespace Multithreading
{
    public partial class Window1 : System.Windows.Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        private void cmdBreakRules_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(UpdateTextWrong);
            thread.Start();
        }

        private void UpdateTextWrong()
        {
            txt.Text = "Here is some new text.";
        }

        private void cmdFollowRules_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(UpdateTextRight);
            thread.Start();
        }


        private void UpdateTextRight()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));

            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                (ThreadStart) delegate()
                {
                    txt.Text = "Here is some new text.";
                }
                );
        }

        private void cmdBackgroundWorker_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorkerTest test = new BackgroundWorkerTest();
            test.ShowDialog();
        }
    }
}