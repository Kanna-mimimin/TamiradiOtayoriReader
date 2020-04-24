using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace TamiradiOtayoriReader.Converters
{
    class ColorToSolidColorBrushValueConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null == value)
            {
                return null;
            }

            if (value is Color)
            {
                Color color = (Color)value;
                return new SolidColorBrush(color);
            }
            Type type = value.GetType();
            throw new InvalidOperationException("Unsupported type [" + type.Name + "]");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
