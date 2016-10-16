using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Data;
using System.Globalization;

namespace Documents
{
    public class AnnotationTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Convert 64 bit binary data into an 8 bit byte array and load
            // it into a memory buffer
            byte[] data = System.Convert.FromBase64String(value as string);
            using (MemoryStream buffer = new MemoryStream(data))
            {
                // Convert memory buffer to object and return text
                Section section = (Section)XamlReader.Load(buffer);
                TextRange range = new TextRange(section.ContentStart, section.ContentEnd);
                return range.Text;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
