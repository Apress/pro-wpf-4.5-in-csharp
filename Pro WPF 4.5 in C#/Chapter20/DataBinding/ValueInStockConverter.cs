using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace DataBinding
{
    public class ValueInStockConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Return the total value of all the items in stock.
            decimal unitCost = (decimal)values[0];
            int unitsInStock = (int)values[1];
            return unitCost * unitsInStock;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
