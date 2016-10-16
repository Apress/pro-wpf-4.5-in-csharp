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
using System.Globalization;

namespace Commands
{
    /// <summary>
    /// Interaction logic for CustomControlWithCommand.xaml
    /// </summary>

    public partial class CustomControlWithCommand : System.Windows.Window
    {

        public CustomControlWithCommand()
        {
            InitializeComponent();
        }
        public static RoutedCommand FontUpdateCommand = new RoutedCommand();

        //The ExecutedRoutedEvent Handler
        //if the command target is the TextBox, changes the fontsize to that
        //of the value passed in through the Command Parameter
        public void SliderUpdateExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            TextBox source = sender as TextBox;

            if (source != null)
            {
                if (e.Parameter != null)
                {
                    try
                    {
                        if ((int)e.Parameter > 0 && (int)e.Parameter <= 60)
                        {
                            source.FontSize = (int)e.Parameter;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("in Command \n Parameter: " + e.Parameter);
                    }

                }
            }
        }

        //The CanExecuteRoutedEvent Handler
        //if the Command Source is a TextBox, then set CanExecute to ture;
        //otherwise, set it to false
        public void SliderUpdateCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            TextBox source = sender as TextBox;

            if (source != null)
            {
                if (source.IsReadOnly)
                {
                    e.CanExecute = false;
                }
                else
                {
                    e.CanExecute = true;
                }
            }
        }

        //if the Readonly Box is checked, we need to force the CommandManager
        //to raise the RequerySuggested event.  This will cause the Command Source
        //to query the command to see if it can execute or not.
        public void OnReadOnlyChecked(object sender, RoutedEventArgs e)
        {
            if (txtBoxTarget != null)
            {
                txtBoxTarget.IsReadOnly = true;
                CommandManager.InvalidateRequerySuggested();
            }
        }

        //if the Readonly Box is checked, we need to force the CommandManager
        //to raise the RequerySuggested event.  This will cause the Command Source
        //to query the command to see if it can execute or not.
        public void OnReadOnlyUnChecked(object sender, RoutedEventArgs e)
        {
            if (txtBoxTarget != null)
            {
                txtBoxTarget.IsReadOnly = false;
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }


    //Converter to convert the Slider value property to an int
    [ValueConversion(typeof(double), typeof(int))]
    public class FontStringValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string fontSize = (string)value;
            int intFont;

            try
            {
                intFont = Int32.Parse(fontSize);
                return intFont;
            }
            catch (FormatException e)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    //Converter to convert the Slider value property to an int
    [ValueConversion(typeof(double), typeof(int))]
    public class FontDoubleValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double fontSize = (double)value;
            return (int)fontSize;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}