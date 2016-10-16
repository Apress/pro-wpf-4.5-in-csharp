using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Globalization;

namespace DataBinding
{
    [ValueConversion(typeof(decimal), typeof(string))]
    public class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = (decimal)value;
            return price.ToString("c", culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string price = value.ToString();
            
            decimal result;
            if (Decimal.TryParse(price, System.Globalization.NumberStyles.Any, culture, out result))
            {
                return result;
            }
            return value;
        }
    }


}
