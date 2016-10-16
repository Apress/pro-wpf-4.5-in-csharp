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

namespace Controls
{
    /// <summary>
    /// Interaction logic for DateControls.xaml
    /// </summary>
    public partial class DateControls : Window
    {
        public DateControls()
        {
            InitializeComponent();
        }

        private void DatePicker_DateValidationError(object sender, DatePickerDateValidationErrorEventArgs e)
        {
            lblError.Text = "'" + e.Text +
                "' is not a valid value because " + e.Exception.Message;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check all the newly added items.
            foreach (DateTime selectedDate in e.AddedItems)
            {
                if ((selectedDate.DayOfWeek == DayOfWeek.Saturday) ||
                    (selectedDate.DayOfWeek == DayOfWeek.Sunday))
                {
                    lblError.Text = "Weekends are not allowed";

                    ((Calendar)sender).SelectedDates.Remove(selectedDate);
                }
            }

        }
    }
}
