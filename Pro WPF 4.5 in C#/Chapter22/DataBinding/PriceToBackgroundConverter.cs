using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;
using StoreDatabase;

namespace DataBinding
{
    public class PriceToBackgroundConverter : IValueConverter
    {
        private Brush highlightBrush;
        public Brush HighlightBrush
        {
            get { return highlightBrush; }
            set { highlightBrush = value; }
        }

        private decimal minPrice;
        public decimal MinPrice
        {
            get { return minPrice; }
            set { minPrice = value; }
        }        

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Product product = (Product)value;            
                        
            if (product.UnitCost >= MinPrice)
            {
                return HighlightBrush;
            }
            else
            {
                return Brushes.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

    }

}
