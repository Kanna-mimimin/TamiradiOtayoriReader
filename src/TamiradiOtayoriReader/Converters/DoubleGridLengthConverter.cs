using System;
using System.Collections.Generic;
using System.Text;

namespace TamiradiOtayoriReader.Converters
{
    class DoubleGridLengthConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new System.Windows.GridLength((double)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var gridLength = (System.Windows.GridLength)value;
            return gridLength.Value;
        }
    }
}
