using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace SoundAndVideo
{
    public class TimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
          System.Globalization.CultureInfo culture)
        {
            try
            {
                TimeSpan time = (TimeSpan)value;
                return time.TotalSeconds;
            }
            catch
            {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter,
          System.Globalization.CultureInfo culture)
        {
            double seconds = (double)value;
            return TimeSpan.FromSeconds(seconds);
        }
    }

}
