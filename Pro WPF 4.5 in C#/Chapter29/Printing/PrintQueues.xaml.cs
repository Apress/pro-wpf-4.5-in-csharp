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
using System.Printing;

namespace Printing
{
    /// <summary>
    /// Interaction logic for PrintQueues.xaml
    /// </summary>

    public partial class PrintQueues : System.Windows.Window
    {
        
        public PrintQueues()
        {
            InitializeComponent();
        }

        // This code doesn't include any error handling in order to be as clear as possible.
        // Obviously, error handling is required when accessing a printer.
        // (For example, Windows security settings could cause an error.)        
        

        private PrintServer printServer = new PrintServer();

        private void Window_Loaded(object sender, EventArgs e)
        {                              
            lstQueues.DisplayMemberPath = "FullName";
            lstQueues.SelectedValuePath = "FullName";
            lstQueues.ItemsSource = printServer.GetPrintQueues();   
        }

        private void lstQueues_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PrintQueue queue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString());
            lblQueueStatus.Text = "Queue Status: " + queue.QueueStatus.ToString();
            lblJobStatus.Text = "";
            lstJobs.DisplayMemberPath = "JobName";
            lstJobs.SelectedValuePath = "JobIdentifier";

            lstJobs.ItemsSource = queue.GetPrintJobInfoCollection();
        }

        private void lstJobs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstJobs.SelectedValue == null)
            {
                lblJobStatus.Text = "";
            }
            else
            {
                PrintQueue queue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString());
                PrintSystemJobInfo job = queue.GetJob((int)lstJobs.SelectedValue);

                lblJobStatus.Text = "Job Status: " + job.JobStatus.ToString();
            }
        }


        private void cmdPauseQueue_Click(object sender, RoutedEventArgs e)
        {            
            if (lstQueues.SelectedValue != null)
            {
                PrintQueue queue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString());
                queue.Pause();
            }
        }
        private void cmdResumeQueue_Click(object sender, RoutedEventArgs e)
        {
            if (lstQueues.SelectedValue != null)
            {
                PrintQueue queue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString());
                queue.Resume();
            }
        }
        private void cmdRefreshQueue_Click(object sender, RoutedEventArgs e)
        {
            if (lstQueues.SelectedValue != null)
            {
                PrintQueue queue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString());
                queue.Refresh();
            }
        }
        private void cmdPurgeQueue_Click(object sender, RoutedEventArgs e)
        {
            if (lstQueues.SelectedValue != null)
            {
                PrintQueue queue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString());
                queue.Purge();
            }
        }


        private void cmdPauseJob_Click(object sender, RoutedEventArgs e)
        {
            if (lstJobs.SelectedValue != null)
            {
                PrintQueue queue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString());
                PrintSystemJobInfo job = queue.GetJob((int)lstJobs.SelectedValue);
                job.Pause();
            }
        }
        private void cmdResumeJob_Click(object sender, RoutedEventArgs e)
        {
            if (lstJobs.SelectedValue != null)
            {
                PrintQueue queue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString());
                PrintSystemJobInfo job = queue.GetJob((int)lstJobs.SelectedValue);
                job.Resume();
            }
        }
        private void cmdRefreshJob_Click(object sender, RoutedEventArgs e)
        {
            if (lstJobs.SelectedValue != null)
            {
                PrintQueue queue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString());
                PrintSystemJobInfo job = queue.GetJob((int)lstJobs.SelectedValue);
                job.Refresh();

                lstJobs_SelectionChanged(null, null);
            }
        }
        private void cmdCancelJob_Click(object sender, RoutedEventArgs e)
        {
            if (lstJobs.SelectedValue != null)
            {
                PrintQueue queue = printServer.GetPrintQueue(lstQueues.SelectedValue.ToString());
                PrintSystemJobInfo job = queue.GetJob((int)lstJobs.SelectedValue);
                job.Cancel();

                lstQueues_SelectionChanged(null, null);
            }
        }
    }
}